using MapTracker;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PathOfLava
{
    public partial class MainForm : Form
    {
        private bool trackerRunning = false;

        private readonly ClientTextFileWatcher clientTextFileWatcher;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public MainForm()
        {
            InitializeComponent();

            clientTextFileWatcher = new ClientTextFileWatcher(this);

            Console.WriteLine("Form loaded.\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (trackerRunning)
            {
                trackerRunning = false;
                startStopButton.Text = "Start";
                clientTextFileWatcher.StopWatching();
            }
            else
            {
                trackerRunning = true;
                startStopButton.Text = "Stop";
                clientTextFileWatcher.StartWatching();
            }
        }

        public string CurrentZone
        {
            get { return currentZoneTextBox.Text; }
            set { currentZoneTextBox.UpdateControlText(value); }
        }

        public void AddTransitionEvent(TransitionEvent transitionEvent)
        {
            historyDataGrid.Invoke(new Action(delegate ()
            {
                historyDataGrid.Rows.Add(transitionEvent.Name, transitionEvent.Level, transitionEvent.EnterTime);
            }));
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }
}