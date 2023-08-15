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
            Zone = new DataGridViewTextBoxColumn();
            Level = new DataGridViewTextBoxColumn();
            TimeEntered = new DataGridViewTextBoxColumn();
            statsTab = new TabPage();
            statsTabPanel = new Panel();
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exportAsCSVToolStripMenuItem = new ToolStripMenuItem();
            exportAsJSONToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            lmaoToolStripMenuItem = new ToolStripMenuItem();
            mainPanel.SuspendLayout();
            tabContainer.SuspendLayout();
            homeTab.SuspendLayout();
            homeTabPanel.SuspendLayout();
            rawEventsTab.SuspendLayout();
            historyTabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyDataGrid).BeginInit();
            statsTab.SuspendLayout();
            mainMenu.SuspendLayout();
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
            mainPanel.Size = new Size(385, 469);
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
            tabContainer.Size = new Size(385, 445);
            tabContainer.TabIndex = 1;
            // 
            // homeTab
            // 
            homeTab.Controls.Add(homeTabPanel);
            homeTab.Location = new Point(4, 24);
            homeTab.Name = "homeTab";
            homeTab.Padding = new Padding(3);
            homeTab.Size = new Size(377, 417);
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
            homeTabPanel.Size = new Size(371, 411);
            homeTabPanel.TabIndex = 0;
            // 
            // currentZoneTextBox
            // 
            currentZoneTextBox.Enabled = false;
            currentZoneTextBox.Location = new Point(116, 7);
            currentZoneTextBox.Name = "currentZoneTextBox";
            currentZoneTextBox.Size = new Size(250, 23);
            currentZoneTextBox.TabIndex = 2;
            // 
            // currentZoneLabel
            // 
            currentZoneLabel.AutoSize = true;
            currentZoneLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentZoneLabel.Location = new Point(5, 9);
            currentZoneLabel.Name = "currentZoneLabel";
            currentZoneLabel.Size = new Size(105, 21);
            currentZoneLabel.TabIndex = 1;
            currentZoneLabel.Text = "Current Zone:";
            // 
            // startStopButton
            // 
            startStopButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            startStopButton.Location = new Point(22, 343);
            startStopButton.Name = "startStopButton";
            startStopButton.Size = new Size(327, 56);
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
            rawEventsTab.Size = new Size(377, 417);
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
            historyTabPanel.Size = new Size(371, 411);
            historyTabPanel.TabIndex = 0;
            // 
            // historyDataGrid
            // 
            historyDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyDataGrid.Columns.AddRange(new DataGridViewColumn[] { Zone, Level, TimeEntered });
            historyDataGrid.Location = new Point(3, 8);
            historyDataGrid.Name = "historyDataGrid";
            historyDataGrid.RowTemplate.Height = 25;
            historyDataGrid.Size = new Size(364, 398);
            historyDataGrid.TabIndex = 0;
            // 
            // Zone
            // 
            Zone.HeaderText = "Zone";
            Zone.Name = "Zone";
            // 
            // Level
            // 
            Level.HeaderText = "Level";
            Level.Name = "Level";
            // 
            // TimeEntered
            // 
            TimeEntered.HeaderText = "Time Entered";
            TimeEntered.Name = "TimeEntered";
            // 
            // statsTab
            // 
            statsTab.Controls.Add(statsTabPanel);
            statsTab.Location = new Point(4, 24);
            statsTab.Name = "statsTab";
            statsTab.Size = new Size(377, 417);
            statsTab.TabIndex = 2;
            statsTab.Text = "Stats";
            statsTab.UseVisualStyleBackColor = true;
            // 
            // statsTabPanel
            // 
            statsTabPanel.Dock = DockStyle.Fill;
            statsTabPanel.Location = new Point(0, 0);
            statsTabPanel.Name = "statsTabPanel";
            statsTabPanel.Size = new Size(377, 417);
            statsTabPanel.TabIndex = 0;
            // 
            // mainMenu
            // 
            mainMenu.BackColor = Color.White;
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(385, 24);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, exportAsCSVToolStripMenuItem, exportAsJSONToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(153, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // exportAsCSVToolStripMenuItem
            // 
            exportAsCSVToolStripMenuItem.Name = "exportAsCSVToolStripMenuItem";
            exportAsCSVToolStripMenuItem.Size = new Size(153, 22);
            exportAsCSVToolStripMenuItem.Text = "Export as CSV";
            // 
            // exportAsJSONToolStripMenuItem
            // 
            exportAsJSONToolStripMenuItem.Name = "exportAsJSONToolStripMenuItem";
            exportAsJSONToolStripMenuItem.Size = new Size(153, 22);
            exportAsJSONToolStripMenuItem.Text = "Export as JSON";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 469);
            Controls.Add(mainPanel);
            MainMenuStrip = mainMenu;
            MinimumSize = new Size(401, 0);
            Name = "MainForm";
            Text = "Path of Lava";
            TopMost = true;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exportAsCSVToolStripMenuItem;
        private ToolStripMenuItem exportAsJSONToolStripMenuItem;
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
        private DataGridViewTextBoxColumn Zone;
        private DataGridViewTextBoxColumn Level;
        private DataGridViewTextBoxColumn TimeEntered;
    }
}