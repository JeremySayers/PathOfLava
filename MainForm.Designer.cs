namespace PathOfLava
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            tabContainer = new TabControl();
            homeTab = new TabPage();
            homeTabPanel = new Panel();
            currentZoneTextBox = new TextBox();
            currentZoneLabel = new Label();
            startStopButton = new Button();
            rawEventsTab = new TabPage();
            historyTabPanel = new Panel();
            historyDataGrid = new DataGridView();
            Level = new DataGridViewTextBoxColumn();
            Zone = new DataGridViewTextBoxColumn();
            EventType = new DataGridViewTextBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            statsTab = new TabPage();
            statsTabPanel = new Panel();
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exportMapListToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            lmaoToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            exportContractListToolStripMenuItem = new ToolStripMenuItem();
            mainPanel.SuspendLayout();
            tabContainer.SuspendLayout();
            homeTab.SuspendLayout();
            homeTabPanel.SuspendLayout();
            rawEventsTab.SuspendLayout();
            historyTabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyDataGrid).BeginInit();
            statsTab.SuspendLayout();
            mainMenu.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = SystemColors.Control;
            mainPanel.Controls.Add(tabContainer);
            mainPanel.Controls.Add(mainMenu);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(483, 471);
            mainPanel.TabIndex = 0;
            // 
            // tabContainer
            // 
            tabContainer.Controls.Add(homeTab);
            tabContainer.Controls.Add(rawEventsTab);
            tabContainer.Controls.Add(statsTab);
            tabContainer.Dock = DockStyle.Fill;
            tabContainer.Location = new Point(0, 24);
            tabContainer.Margin = new Padding(5);
            tabContainer.Multiline = true;
            tabContainer.Name = "tabContainer";
            tabContainer.Padding = new Point(45, 3);
            tabContainer.SelectedIndex = 0;
            tabContainer.Size = new Size(483, 447);
            tabContainer.TabIndex = 1;
            // 
            // homeTab
            // 
            homeTab.Controls.Add(homeTabPanel);
            homeTab.Location = new Point(4, 24);
            homeTab.Name = "homeTab";
            homeTab.Padding = new Padding(3);
            homeTab.Size = new Size(475, 419);
            homeTab.TabIndex = 0;
            homeTab.Text = "Home";
            homeTab.UseVisualStyleBackColor = true;
            // 
            // homeTabPanel
            // 
            homeTabPanel.Controls.Add(currentZoneTextBox);
            homeTabPanel.Controls.Add(currentZoneLabel);
            homeTabPanel.Controls.Add(startStopButton);
            homeTabPanel.Dock = DockStyle.Fill;
            homeTabPanel.Location = new Point(3, 3);
            homeTabPanel.Name = "homeTabPanel";
            homeTabPanel.Size = new Size(469, 413);
            homeTabPanel.TabIndex = 0;
            // 
            // currentZoneTextBox
            // 
            currentZoneTextBox.Enabled = false;
            currentZoneTextBox.Location = new Point(165, 23);
            currentZoneTextBox.Name = "currentZoneTextBox";
            currentZoneTextBox.Size = new Size(250, 23);
            currentZoneTextBox.TabIndex = 2;
            // 
            // currentZoneLabel
            // 
            currentZoneLabel.AutoSize = true;
            currentZoneLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentZoneLabel.Location = new Point(54, 23);
            currentZoneLabel.Name = "currentZoneLabel";
            currentZoneLabel.Size = new Size(105, 21);
            currentZoneLabel.TabIndex = 1;
            currentZoneLabel.Text = "Current Zone:";
            // 
            // startStopButton
            // 
            startStopButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            startStopButton.Location = new Point(22, 330);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(425, 56);
            startStopButton.TabIndex = 0;
            startStopButton.Text = "Start";
            startStopButton.UseVisualStyleBackColor = true;
            startStopButton.Click += startStopButton_Click;
            // 
            // rawEventsTab
            // 
            rawEventsTab.Controls.Add(historyTabPanel);
            rawEventsTab.Location = new Point(4, 24);
            rawEventsTab.Name = "rawEventsTab";
            rawEventsTab.Padding = new Padding(3);
            rawEventsTab.Size = new Size(475, 419);
            rawEventsTab.TabIndex = 1;
            rawEventsTab.Text = "History";
            rawEventsTab.UseVisualStyleBackColor = true;
            // 
            // historyTabPanel
            // 
            historyTabPanel.Controls.Add(historyDataGrid);
            historyTabPanel.Dock = DockStyle.Fill;
            historyTabPanel.Location = new Point(3, 3);
            historyTabPanel.Name = "historyTabPanel";
            historyTabPanel.Size = new Size(469, 413);
            historyTabPanel.TabIndex = 0;
            // 
            // historyDataGrid
            // 
            historyDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyDataGrid.Columns.AddRange(new DataGridViewColumn[] { Level, Zone, EventType, Time });
            historyDataGrid.Dock = DockStyle.Fill;
            historyDataGrid.Location = new Point(0, 0);
            historyDataGrid.Name = "historyDataGrid";
            historyDataGrid.ReadOnly = true;
            historyDataGrid.RowHeadersVisible = false;
            historyDataGrid.RowTemplate.Height = 25;
            historyDataGrid.Size = new Size(469, 413);
            historyDataGrid.TabIndex = 0;
            // 
            // Level
            // 
            Level.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Level.HeaderText = "Level";
            Level.Name = "Level";
            Level.ReadOnly = true;
            Level.Width = 59;
            // 
            // Zone
            // 
            Zone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Zone.HeaderText = "Zone";
            Zone.Name = "Zone";
            Zone.ReadOnly = true;
            Zone.Width = 59;
            // 
            // EventType
            // 
            EventType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EventType.HeaderText = "Event";
            EventType.Name = "EventType";
            EventType.ReadOnly = true;
            EventType.Width = 61;
            // 
            // Time
            // 
            Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Time.HeaderText = "Time";
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Width = 58;
            // 
            // statsTab
            // 
            statsTab.Controls.Add(statsTabPanel);
            statsTab.Location = new Point(4, 24);
            statsTab.Name = "statsTab";
            statsTab.Size = new Size(475, 419);
            statsTab.TabIndex = 2;
            statsTab.Text = "Stats";
            statsTab.UseVisualStyleBackColor = true;
            // 
            // statsTabPanel
            // 
            statsTabPanel.Dock = DockStyle.Fill;
            statsTabPanel.Location = new Point(0, 0);
            statsTabPanel.Name = "statsTabPanel";
            statsTabPanel.Size = new Size(475, 419);
            statsTabPanel.TabIndex = 0;
            // 
            // mainMenu
            // 
            mainMenu.BackColor = Color.White;
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(483, 24);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, exportMapListToolStripMenuItem, exportContractListToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // exportMapListToolStripMenuItem
            // 
            exportMapListToolStripMenuItem.Name = "exportMapListToolStripMenuItem";
            exportMapListToolStripMenuItem.Size = new Size(180, 22);
            exportMapListToolStripMenuItem.Text = "Export Map List";
            exportMapListToolStripMenuItem.Click += exportMapListToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lmaoToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // lmaoToolStripMenuItem
            // 
            lmaoToolStripMenuItem.Name = "lmaoToolStripMenuItem";
            lmaoToolStripMenuItem.Size = new Size(104, 22);
            lmaoToolStripMenuItem.Text = "Lmao";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 449);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(483, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(81, 17);
            statusLabel.Text = "No file loaded";
            // 
            // exportContractListToolStripMenuItem
            // 
            exportContractListToolStripMenuItem.Name = "exportContractListToolStripMenuItem";
            exportContractListToolStripMenuItem.Size = new Size(180, 22);
            exportContractListToolStripMenuItem.Text = "Export Contract List";
            exportContractListToolStripMenuItem.Click += exportContractListToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 471);
            Controls.Add(statusStrip1);
            Controls.Add(mainPanel);
            MainMenuStrip = mainMenu;
            MinimumSize = new Size(401, 0);
            Name = "MainForm";
            Text = "Path of Lava";
            TopMost = true;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            tabContainer.ResumeLayout(false);
            homeTab.ResumeLayout(false);
            homeTabPanel.ResumeLayout(false);
            homeTabPanel.PerformLayout();
            rawEventsTab.ResumeLayout(false);
            historyTabPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)historyDataGrid).EndInit();
            statsTab.ResumeLayout(false);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem lmaoToolStripMenuItem;
        private TabControl tabContainer;
        private TabPage homeTab;
        private TabPage rawEventsTab;
        private TabPage statsTab;
        private Panel homeTabPanel;
        private Panel historyTabPanel;
        private Panel statsTabPanel;
        private Button startStopButton;
        private Label currentZoneLabel;
        private TextBox currentZoneTextBox;
        private DataGridView historyDataGrid;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn Zone;
        private DataGridViewTextBoxColumn EventType;
        private DataGridViewTextBoxColumn Time;
        private ToolStripMenuItem newToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripMenuItem exportMapListToolStripMenuItem;
        private ToolStripMenuItem exportContractListToolStripMenuItem;
    }
}