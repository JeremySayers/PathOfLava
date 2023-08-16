using MapTracker;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.TimeZoneInfo;
using System.Reflection.Emit;
using System.Xml.Linq;
using System;

namespace PathOfLava
{
    public partial class MainForm : Form
    {
        private readonly ClientTextFileWatcher _clientTextFileWatcher;
        private List<TransitionEvent> _transitionEvents;
        private bool trackerRunning = false;
        private string _saveFileLocation = string.Empty;
        private bool _isDirty = false;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        private static readonly object _transitionEventsLock = new object();

        public MainForm()
        {
            InitializeComponent();

            _clientTextFileWatcher = new ClientTextFileWatcher(this);
            _transitionEvents = new List<TransitionEvent>();

            Console.WriteLine("Form loaded.\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            if (string.IsNullOrEmpty(_saveFileLocation))
            {
                startStopButton.Enabled = false;
                startStopButton.Text = "Open an existing .pol file or create a new one.";
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            startStopButton.Enabled = false;

            if (trackerRunning)
            {
                trackerRunning = false;
                startStopButton.Text = "Start";
                _clientTextFileWatcher.StopWatching();

                var transitionEvent = new TransitionEvent
                {
                    Seed = "NA",
                    Level = 0,
                    Name = "Stopped Playing",
                    EnterTime = DateTime.Now,
                    TransitionType = TransitionType.StoppedPlaying
                };

                AddTransitionEvent(transitionEvent);
            }
            else
            {
                trackerRunning = true;
                startStopButton.Text = "Stop";
                _clientTextFileWatcher.StartWatching();

                var transitionEvent = new TransitionEvent
                {
                    Seed = "NA",
                    Level = 0,
                    Name = "Started Playing",
                    EnterTime = DateTime.Now,
                    TransitionType = TransitionType.StartedPlaying
                };

                AddTransitionEvent(transitionEvent);
            }

            startStopButton.Enabled = true;
        }

        public string CurrentZone
        {
            get { return currentZoneTextBox.Text; }
            set { currentZoneTextBox.UpdateControlText(value); }
        }

        public void AddTransitionEvent(TransitionEvent transitionEvent)
        {
            lock (_transitionEventsLock)
            {
                _transitionEvents.Add(transitionEvent);
            }

            AddDataGridRow(transitionEvent);

            _isDirty = true;
        }

        private void AddDataGridRow(TransitionEvent transitionEvent)
        {
            historyDataGrid.Invoke(new Action(delegate ()
            {
                historyDataGrid.Rows.Add(
                    transitionEvent.Level,
                    transitionEvent.Name,
                    transitionEvent.TransitionType,
                    transitionEvent.EnterTime);
            }));
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Path of Lava|*.pol";
            saveFileDialog1.Title = "Open Path of Lava file";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                using (FileStream fs = File.Create(saveFileDialog1.FileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    fs.Write(info, 0, info.Length);
                }

                _saveFileLocation = saveFileDialog1.FileName;
                startStopButton.Enabled = true;
                startStopButton.Text = "Start";
                statusLabel.Text = _saveFileLocation;
            }

            _isDirty = false;
        }

        public async Task<bool> Save()
        {
            if (string.IsNullOrEmpty(_saveFileLocation))
            {
                MessageBox.Show("No active POL file, Create a new one or open an existing one.", "Warning", MessageBoxButtons.OK);

                return false;
            }

            statusLabel.Text = "Saving...";

            List<TransitionEvent> transitionEventsToSave;

            lock (_transitionEventsLock)
            {
                transitionEventsToSave = new List<TransitionEvent>(_transitionEvents);
            }

            var linesToSave = new List<string>();

            foreach (var transitionEvent in transitionEventsToSave)
            {
                linesToSave.Add($"{transitionEvent.EnterTime}, {transitionEvent.Name}, {transitionEvent.Level}, {transitionEvent.TransitionType}, {transitionEvent.Seed}");
            }

            await File.WriteAllLinesAsync(_saveFileLocation, linesToSave);

            statusLabel.Text = _saveFileLocation;
            _isDirty = false;

            return true;
        }

        public bool Open()
        {
            if (trackerRunning)
            {
                MessageBox.Show("Stop the tracker to open a new file.", "Error", MessageBoxButtons.OK);

                return false;
            }

            if (_isDirty)
            {
                MessageBox.Show("Save before opening a new file.", "Error", MessageBoxButtons.OK);

                return false;
            }

            statusLabel.Text = "Opening...";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Path of Lava|*.pol";
            openFileDialog.Title = "Open Path of Lava file";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (openFileDialog.FileName != "")
            {
                var filePath = openFileDialog.FileName;
                var transitionEventsFile = File.ReadLines(filePath);
                var transtionEventsToLoad = new List<TransitionEvent>();
                historyDataGrid.Rows.Clear();

                foreach (var transitionEventString in transitionEventsFile)
                {
                    var parts = transitionEventString.Split(',');

                    var transitionEvent = new TransitionEvent
                    {
                        EnterTime = DateTime.Parse(parts[0]),
                        Name = parts[1],
                        Level = int.Parse(parts[2]),
                        TransitionType = Enum.Parse<TransitionType>(parts[3]),
                        Seed = parts[4]
                    };

                    transtionEventsToLoad.Add(transitionEvent);
                    AddDataGridRow(transitionEvent);
                }

                lock (_transitionEventsLock)
                {
                    _transitionEvents.Clear();
                    _transitionEvents.AddRange(transtionEventsToLoad);
                }

                _saveFileLocation = filePath;
                statusLabel.Text = _saveFileLocation;
                startStopButton.Enabled = true;
                startStopButton.Text = "Start";
            }

            return true;
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trackerRunning || _isDirty)
            {
                if (DialogResult.No == MessageBox.Show("Are you sure you want to close without stopping and saving? This will probably break your save.", "Close Path of Lava", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    // Cancel the Closing event
                    e.Cancel = true;
                }
            }
        }

        private async void exportMapListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.Title = "Export CSV";
            saveFileDialog.ShowDialog();

            if (string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                return;
            }

            var maps = GenerateContentList(TransitionType.Map);

            var linesToSave = new List<string>();

            foreach (var map in maps)
            {
                linesToSave.Add($"{map.Name}, {map.Level}, {map.TotalTime}");
            }

            await File.WriteAllLinesAsync(saveFileDialog.FileName, linesToSave);
        }

        private List<Map> GenerateContentList(TransitionType transitionType)
        {
            List<TransitionEvent> transitionEventsToExport;
            var maps = new Dictionary<string, Map>();

            lock (_transitionEventsLock)
            {
                transitionEventsToExport = new List<TransitionEvent>(_transitionEvents);
            }

            for (int i = 0; i < transitionEventsToExport.Count; i++)
            {
                if (transitionEventsToExport[i].TransitionType != transitionType)
                {
                    continue;
                }

                var totalMapTime = TimeSpan.FromSeconds(0);

                if (i+1 <= transitionEventsToExport.Count)
                {
                    totalMapTime = transitionEventsToExport[i+1].EnterTime - transitionEventsToExport[i].EnterTime;
                }

                if (maps.ContainsKey(transitionEventsToExport[i].Seed))
                {
                    var updatedMap = maps[transitionEventsToExport[i].Seed];
                    updatedMap.TotalTime = updatedMap.TotalTime + totalMapTime;
                }
                else
                {
                    maps.Add(transitionEventsToExport[i].Seed, new Map
                    {
                        Name = transitionEventsToExport[i].Name,
                        Level = transitionEventsToExport[i].Level.ToString(),
                        TotalTime = totalMapTime
                    });
                }
            }

            return maps.Values.ToList();
        }

        private async void exportContractListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.Title = "Export CSV";
            saveFileDialog.ShowDialog();

            if (string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                return;
            }

            var maps = GenerateContentList(TransitionType.Heist);

            var linesToSave = new List<string>();

            foreach (var map in maps)
            {
                linesToSave.Add($"{map.Name}, {map.Level}, {map.TotalTime}");
            }

            await File.WriteAllLinesAsync(saveFileDialog.FileName, linesToSave);
        }
    }
}