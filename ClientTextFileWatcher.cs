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
        private readonly AutoResetEvent _waitHandle = new(false);
        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly MainForm _mainFormInstance;
        private Thread? _workerThread;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private bool _isTrackerRunning = false;

        public ClientTextFileWatcher(MainForm mainForm) 
        {
            _mainFormInstance = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            var clientTextFilePath = Path.GetDirectoryName(@"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt");

            if (clientTextFilePath == null)
            {
                throw new Exception("Client Text File Missing!");
            }

            _fileSystemWatcher = new FileSystemWatcher(clientTextFilePath)
            {
                Filter = "Client.txt",
                EnableRaisingEvents = true
            };

            _fileSystemWatcher.Changed += (s, e) => _waitHandle.Set();
        }

        public bool StartWatching()
        {
            if (!_isTrackerRunning)
            {
                _tokenSource = new CancellationTokenSource();

                _workerThread = new(
                    () => WatchClientTxt(_tokenSource.Token)
                );

                _workerThread.IsBackground = true;
                _workerThread.Start();

                _isTrackerRunning = true;
                Console.WriteLine("Client text watcher started.\n");
            }

            return true;            
        }

        public bool StopWatching()
        {
            if (_isTrackerRunning && _workerThread is not null)
            {
                _tokenSource.Cancel();
                _workerThread.Join();
                _tokenSource.Dispose();

                _isTrackerRunning = false;
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

                            _mainFormInstance.CurrentZone = transitionEvent.Name;
                            _mainFormInstance.AddTransitionEvent(transitionEvent);
                        }
                    }
                    else
                    {
                        _waitHandle.WaitOne(1000);
                    }
                }
            }

            fileStream.Close();
        }
    }
}
