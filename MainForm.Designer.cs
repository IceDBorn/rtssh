namespace rtssh
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.autoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.jsonPathTextBox = new System.Windows.Forms.TextBox();
            this.jsonPathLabel = new System.Windows.Forms.Label();
            this.tempTextBox = new System.Windows.Forms.TextBox();
            this.freqTextBox = new System.Windows.Forms.TextBox();
            this.freqLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.spaceRadioButton = new System.Windows.Forms.RadioButton();
            this.newLineRadioButton = new System.Windows.Forms.RadioButton();
            this.seperatorGroupBox = new System.Windows.Forms.GroupBox();
            this.displayGroupBox = new System.Windows.Forms.GroupBox();
            this.bothRadioButton = new System.Windows.Forms.RadioButton();
            this.tempRadioButton = new System.Windows.Forms.RadioButton();
            this.freqRadioButton = new System.Windows.Forms.RadioButton();
            this.refreshIntervalLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.keyBrowser = new System.Windows.Forms.OpenFileDialog();
            this.keyBrowserButton = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.seperatorGroupBox.SuspendLayout();
            this.displayGroupBox.SuspendLayout();
            this.trayIconContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.RefreshIntervalNumeric)).BeginInit();
            this.connectionGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(58, 21);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(180, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(58, 54);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(180, 20);
            this.hostTextBox.TabIndex = 1;
            this.hostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(58, 91);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(180, 20);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.connectButton.Location = new System.Drawing.Point(12, 215);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(246, 33);
            this.connectButton.TabIndex = 17;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(8, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(32, 17);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "User:";
            // 
            // hostLabel
            // 
            this.hostLabel.Location = new System.Drawing.Point(8, 59);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(33, 23);
            this.hostLabel.TabIndex = 6;
            this.hostLabel.Text = "Host:";
            // 
            // portLabel
            // 
            this.portLabel.Location = new System.Drawing.Point(10, 94);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(30, 23);
            this.portLabel.TabIndex = 7;
            this.portLabel.Text = "Port:";
            // 
            // keyLabel
            // 
            this.keyLabel.Location = new System.Drawing.Point(11, 129);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(29, 23);
            this.keyLabel.TabIndex = 8;
            this.keyLabel.Text = "Key:";
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.Location = new System.Drawing.Point(12, 18);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(95, 24);
            this.autoConnectCheckBox.TabIndex = 5;
            this.autoConnectCheckBox.Text = "Auto-connect";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsCheckBox
            // 
            this.saveSettingsCheckBox.Location = new System.Drawing.Point(12, 39);
            this.saveSettingsCheckBox.Name = "saveSettingsCheckBox";
            this.saveSettingsCheckBox.Size = new System.Drawing.Size(95, 24);
            this.saveSettingsCheckBox.TabIndex = 6;
            this.saveSettingsCheckBox.Text = "Save settings";
            this.saveSettingsCheckBox.UseVisualStyleBackColor = true;
            this.saveSettingsCheckBox.CheckedChanged += new System.EventHandler(this.saveSettingsCheckBox_CheckedChanged);
            // 
            // jsonPathTextBox
            // 
            this.jsonPathTextBox.Location = new System.Drawing.Point(7, 115);
            this.jsonPathTextBox.Name = "jsonPathTextBox";
            this.jsonPathTextBox.Size = new System.Drawing.Size(180, 20);
            this.jsonPathTextBox.TabIndex = 8;
            this.jsonPathTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // jsonPathLabel
            // 
            this.jsonPathLabel.Location = new System.Drawing.Point(7, 100);
            this.jsonPathLabel.Name = "jsonPathLabel";
            this.jsonPathLabel.Size = new System.Drawing.Size(180, 12);
            this.jsonPathLabel.TabIndex = 12;
            this.jsonPathLabel.Text = "JSON Path:";
            this.jsonPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempTextBox
            // 
            this.tempTextBox.Location = new System.Drawing.Point(7, 157);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.Size = new System.Drawing.Size(180, 20);
            this.tempTextBox.TabIndex = 9;
            this.tempTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // freqTextBox
            // 
            this.freqTextBox.Location = new System.Drawing.Point(7, 200);
            this.freqTextBox.Name = "freqTextBox";
            this.freqTextBox.Size = new System.Drawing.Size(180, 20);
            this.freqTextBox.TabIndex = 10;
            this.freqTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // freqLabel
            // 
            this.freqLabel.Location = new System.Drawing.Point(7, 180);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(180, 17);
            this.freqLabel.TabIndex = 15;
            this.freqLabel.Text = "Frequency text:";
            this.freqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempLabel
            // 
            this.tempLabel.Location = new System.Drawing.Point(7, 138);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(180, 17);
            this.tempLabel.TabIndex = 16;
            this.tempLabel.Text = "Temperature text:";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spaceRadioButton
            // 
            this.spaceRadioButton.Location = new System.Drawing.Point(6, 12);
            this.spaceRadioButton.Name = "spaceRadioButton";
            this.spaceRadioButton.Size = new System.Drawing.Size(64, 24);
            this.spaceRadioButton.TabIndex = 14;
            this.spaceRadioButton.TabStop = true;
            this.spaceRadioButton.Text = "space";
            this.spaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // newLineRadioButton
            // 
            this.newLineRadioButton.Location = new System.Drawing.Point(6, 32);
            this.newLineRadioButton.Name = "newLineRadioButton";
            this.newLineRadioButton.Size = new System.Drawing.Size(64, 24);
            this.newLineRadioButton.TabIndex = 15;
            this.newLineRadioButton.TabStop = true;
            this.newLineRadioButton.Text = "new line";
            this.newLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // seperatorGroupBox
            // 
            this.seperatorGroupBox.Controls.Add(this.spaceRadioButton);
            this.seperatorGroupBox.Controls.Add(this.newLineRadioButton);
            this.seperatorGroupBox.Location = new System.Drawing.Point(198, 102);
            this.seperatorGroupBox.Name = "seperatorGroupBox";
            this.seperatorGroupBox.Size = new System.Drawing.Size(100, 62);
            this.seperatorGroupBox.TabIndex = 23;
            this.seperatorGroupBox.TabStop = false;
            this.seperatorGroupBox.Text = "Seperate with";
            // 
            // displayGroupBox
            // 
            this.displayGroupBox.Controls.Add(this.bothRadioButton);
            this.displayGroupBox.Controls.Add(this.tempRadioButton);
            this.displayGroupBox.Controls.Add(this.freqRadioButton);
            this.displayGroupBox.Location = new System.Drawing.Point(198, 18);
            this.displayGroupBox.Name = "displayGroupBox";
            this.displayGroupBox.Size = new System.Drawing.Size(100, 78);
            this.displayGroupBox.TabIndex = 24;
            this.displayGroupBox.TabStop = false;
            this.displayGroupBox.Text = "Display";
            // 
            // bothRadioButton
            // 
            this.bothRadioButton.Location = new System.Drawing.Point(6, 52);
            this.bothRadioButton.Name = "bothRadioButton";
            this.bothRadioButton.Size = new System.Drawing.Size(64, 24);
            this.bothRadioButton.TabIndex = 13;
            this.bothRadioButton.TabStop = true;
            this.bothRadioButton.Text = "both";
            this.bothRadioButton.UseVisualStyleBackColor = true;
            // 
            // tempRadioButton
            // 
            this.tempRadioButton.Location = new System.Drawing.Point(6, 12);
            this.tempRadioButton.Name = "tempRadioButton";
            this.tempRadioButton.Size = new System.Drawing.Size(85, 24);
            this.tempRadioButton.TabIndex = 11;
            this.tempRadioButton.TabStop = true;
            this.tempRadioButton.Text = "temperature";
            this.tempRadioButton.UseVisualStyleBackColor = true;
            // 
            // freqRadioButton
            // 
            this.freqRadioButton.Location = new System.Drawing.Point(6, 32);
            this.freqRadioButton.Name = "freqRadioButton";
            this.freqRadioButton.Size = new System.Drawing.Size(76, 24);
            this.freqRadioButton.TabIndex = 12;
            this.freqRadioButton.TabStop = true;
            this.freqRadioButton.Text = "frequency";
            this.freqRadioButton.UseVisualStyleBackColor = true;
            // 
            // refreshIntervalLabel
            // 
            this.refreshIntervalLabel.Location = new System.Drawing.Point(198, 171);
            this.refreshIntervalLabel.Name = "refreshIntervalLabel";
            this.refreshIntervalLabel.Size = new System.Drawing.Size(100, 13);
            this.refreshIntervalLabel.TabIndex = 26;
            this.refreshIntervalLabel.Text = "Refresh Interval:";
            this.refreshIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(58, 126);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.ReadOnly = true;
            this.keyTextBox.Size = new System.Drawing.Size(180, 20);
            this.keyTextBox.TabIndex = 3;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyBrowserButton
            // 
            this.keyBrowserButton.Location = new System.Drawing.Point(111, 157);
            this.keyBrowserButton.Name = "keyBrowserButton";
            this.keyBrowserButton.Size = new System.Drawing.Size(75, 23);
            this.keyBrowserButton.TabIndex = 4;
            this.keyBrowserButton.Text = "Browse";
            this.keyBrowserButton.UseVisualStyleBackColor = true;
            this.keyBrowserButton.Click += new System.EventHandler(this.keyBrowserButton_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon) (resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "rtssh";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.showStripMenuItem, this.exitStripMenuItem});
            this.trayIconContextMenu.Name = "trayIconContextMenu";
            this.trayIconContextMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showStripMenuItem
            // 
            this.showStripMenuItem.Name = "showStripMenuItem";
            this.showStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showStripMenuItem.Text = "Show";
            this.showStripMenuItem.Click += new System.EventHandler(this.showStripMenuItem_Click);
            // 
            // exitStripMenuItem
            // 
            this.exitStripMenuItem.Name = "exitStripMenuItem";
            this.exitStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitStripMenuItem.Text = "Exit";
            this.exitStripMenuItem.Click += new System.EventHandler(this.exitStripMenuItem_Click);
            // 
            // RefreshIntervalNumeric
            // 
            this.RefreshIntervalNumeric.Location = new System.Drawing.Point(198, 187);
            this.RefreshIntervalNumeric.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.RefreshIntervalNumeric.Name = "RefreshIntervalNumeric";
            this.RefreshIntervalNumeric.Size = new System.Drawing.Size(100, 20);
            this.RefreshIntervalNumeric.TabIndex = 16;
            this.RefreshIntervalNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefreshIntervalNumeric.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.Location = new System.Drawing.Point(12, 58);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(104, 24);
            this.startupCheckBox.TabIndex = 7;
            this.startupCheckBox.Text = "Add to startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            this.startupCheckBox.CheckedChanged += new System.EventHandler(this.startupCheckBox_CheckedChanged);
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Controls.Add(this.usernameLabel);
            this.connectionGroupBox.Controls.Add(this.usernameTextBox);
            this.connectionGroupBox.Controls.Add(this.hostTextBox);
            this.connectionGroupBox.Controls.Add(this.portTextBox);
            this.connectionGroupBox.Controls.Add(this.keyBrowserButton);
            this.connectionGroupBox.Controls.Add(this.keyTextBox);
            this.connectionGroupBox.Controls.Add(this.hostLabel);
            this.connectionGroupBox.Controls.Add(this.portLabel);
            this.connectionGroupBox.Controls.Add(this.keyLabel);
            this.connectionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(246, 197);
            this.connectionGroupBox.TabIndex = 30;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "Connection";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.displayGroupBox);
            this.settingsGroupBox.Controls.Add(this.autoConnectCheckBox);
            this.settingsGroupBox.Controls.Add(this.saveSettingsCheckBox);
            this.settingsGroupBox.Controls.Add(this.RefreshIntervalNumeric);
            this.settingsGroupBox.Controls.Add(this.startupCheckBox);
            this.settingsGroupBox.Controls.Add(this.tempTextBox);
            this.settingsGroupBox.Controls.Add(this.freqTextBox);
            this.settingsGroupBox.Controls.Add(this.refreshIntervalLabel);
            this.settingsGroupBox.Controls.Add(this.freqLabel);
            this.settingsGroupBox.Controls.Add(this.jsonPathTextBox);
            this.settingsGroupBox.Controls.Add(this.jsonPathLabel);
            this.settingsGroupBox.Controls.Add(this.tempLabel);
            this.settingsGroupBox.Controls.Add(this.seperatorGroupBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(264, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(307, 236);
            this.settingsGroupBox.TabIndex = 31;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(579, 261);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.connectionGroupBox);
            this.Controls.Add(this.connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.seperatorGroupBox.ResumeLayout(false);
            this.displayGroupBox.ResumeLayout(false);
            this.trayIconContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.RefreshIntervalNumeric)).EndInit();
            this.connectionGroupBox.ResumeLayout(false);
            this.connectionGroupBox.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;

        private System.Windows.Forms.ToolStripMenuItem exitStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem showStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;

        private System.Windows.Forms.CheckBox startupCheckBox;

        private System.Windows.Forms.NumericUpDown RefreshIntervalNumeric;

        private System.Windows.Forms.NotifyIcon trayIcon;

        private System.Windows.Forms.Button keyBrowserButton;

        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.OpenFileDialog keyBrowser;

        private System.Windows.Forms.Label refreshIntervalLabel;

        private System.Windows.Forms.GroupBox displayGroupBox;
        private System.Windows.Forms.RadioButton tempRadioButton;
        private System.Windows.Forms.RadioButton freqRadioButton;
        private System.Windows.Forms.RadioButton bothRadioButton;

        private System.Windows.Forms.GroupBox seperatorGroupBox;

        private System.Windows.Forms.RadioButton spaceRadioButton;
        private System.Windows.Forms.RadioButton newLineRadioButton;

        private System.Windows.Forms.Label freqLabel;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.TextBox tempTextBox;
        private System.Windows.Forms.TextBox freqTextBox;

        private System.Windows.Forms.Label jsonPathLabel;

        private System.Windows.Forms.TextBox jsonPathTextBox;

        private System.Windows.Forms.CheckBox autoConnectCheckBox;
        private System.Windows.Forms.CheckBox saveSettingsCheckBox;

        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label usernameLabel;

        private System.Windows.Forms.Button connectButton;

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox portTextBox;

        #endregion
    }
}