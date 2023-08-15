using MapTracker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathOfLava
{
    public class ClientTextFileWatcher
    {
        private List<TransitionEvent> TransitionEventHistory { get; set; }
        private AutoResetEvent WaitHandle { get; set; } = new AutoResetEvent(false);
        private FileSystemWatcher FileSystemWatcher { get; set; }
        private Thread? WorkerThread { get; set; }
        private CancellationTokenSource TokenSource { get; set; } = new CancellationTokenSource();
        private bool IsTrackerRunning { get; set; } = false;
        private readonly MainForm _mainForm;

        public ClientTextFileWatcher(MainForm mainForm) 
        {
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            var clientTextFilePath = Path.GetDirectoryName(@"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt");

            if (clientTextFilePath == null)
            {
                throw new Exception("Client Text File Missing!");
            }

            FileSystemWatcher = new FileSystemWatcher(clientTextFilePath)
            {
                Filter = "Client.txt",
                EnableRaisingEvents = true
            };

            FileSystemWatcher.Changed += (s, e) => WaitHandle.Set();

            TransitionEventHistory = new List<TransitionEvent>();
        }

        public bool StartWatching()
        {
            if (!IsTrackerRunning)
            {
                TokenSource = new CancellationTokenSource();

                WorkerThread = new(
                    () => WatchClientTxt(TokenSource.Token)
                );

                WorkerThread.IsBackground = true;
                WorkerThread.Start();

                IsTrackerRunning = true;
                Console.WriteLine("Client text watcher started.\n");
            }

            return true;            
        }

        public bool StopWatching()
        {
            if (IsTrackerRunning && WorkerThread is not null)
            {
                TokenSource.Cancel();
                WorkerThread.Join();
                TokenSource.Dispose();

                IsTrackerRunning = false;
                Console.WriteLine("Client text watcher stopped.\n");
            }

            return true;
        }

        void WatchClientTxt(CancellationToken token)
        {
            Console.WriteLine($"Worker thread started.");
            var fileStream = new FileStream(@"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt",
                                FileMode.Open,
                                FileAccess.Read,
                                FileShare.ReadWrite);

            if (fileStream == null)
            {
                throw new Exception("Issue setting up the filestream");
            }

            fileStream.Position = fileStream.Length;

            using (var streamReader = new StreamReader(fileStream))
            {
                while (!token.IsCancellationRequested)
                {
                    var currentNewLine = streamReader.ReadLine();
                    if (currentNewLine != null)
                    {
                        if (currentNewLine.Contains("Generating") 
                            && (currentNewLine.Contains("Map") || 
                                currentNewLine.Contains("Hideout") || 
                                currentNewLine.Contains("HeistHub") || 
                                currentNewLine.Contains("Heist")))
                        {
                            var seed = currentNewLine.Substring(currentNewLine.IndexOf("with seed") + 9);

                            var levelStartIndex = currentNewLine.IndexOf("Generating level") + 17;
                            var spaceAfterLevelIndex = currentNewLine.IndexOf(' ', levelStartIndex);
                            var level = currentNewLine.Substring(levelStartIndex, spaceAfterLevelIndex - levelStartIndex);
                            var transitionType = TransitionType.Map;

                            string? name;
                            if (currentNewLine.Contains("Map"))
                            {
                                var nameStartIndex = currentNewLine.IndexOf("MapWorlds") + 9;
                                var quoteAfterNameIndex = currentNewLine.IndexOf("\"", nameStartIndex);
                                name = currentNewLine.Substring(nameStartIndex, quoteAfterNameIndex - nameStartIndex);
                            }
                            else if (currentNewLine.Contains("Hideout"))
                            {
                                name = "Hideout";
                                transitionType = TransitionType.Hideout;
                            }
                            else if (currentNewLine.Contains("HeistHub"))
                            {
                                name = "Rogue Harbour";
                                transitionType = TransitionType.RogueHarbour;
                            }
                            else if (currentNewLine.Contains("Heist"))
                            {
                                name = "Heist";
                                transitionType = TransitionType.Heist;
                            }
                            else
                            {
                                name = "Unknown Zone";
                                transitionType = TransitionType.Unknown;
                            }

                            var unParsedDateTime = $"{currentNewLine.Split(" ")[0]} {currentNewLine.Split(" ")[1]}";
                            var datetime = DateTime.Parse(unParsedDateTime);

                            var transitionEvent = new TransitionEvent
                            {
                                Seed = seed,
                                Level = int.Parse(level),
                                Name = name,
                                EnterTime = datetime,
                                TransitionType = transitionType
                            };

                            Console.WriteLine("New transition detected");
                            Console.WriteLine($"\tName: {transitionEvent.Name}");
                            Console.WriteLine($"\tLevel: {transitionEvent.Level}");
                            Console.WriteLine($"\tSeed: {transitionEvent.Seed}");
                            Console.WriteLine($"\tTime Entered: {transitionEvent.TransitionType}\n");

                            _mainForm.CurrentZone = transitionEvent.Name;
                            _mainForm.AddTransitionEvent(transitionEvent);
                            TransitionEventHistory.Add(transitionEvent);
                        }
                    }
                    else
                    {
                        WaitHandle.WaitOne(1000);
                    }
                }
            }

            fileStream.Close();
        }
    }
}
