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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
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
            this.commaRadioButton = new System.Windows.Forms.RadioButton();
            this.newLineRadioButton = new System.Windows.Forms.RadioButton();
            this.seperatorGroupBox = new System.Windows.Forms.GroupBox();
            this.displayGroupBox = new System.Windows.Forms.GroupBox();
            this.bothRadioButton = new System.Windows.Forms.RadioButton();
            this.tempRadioButton = new System.Windows.Forms.RadioButton();
            this.freqRadioButton = new System.Windows.Forms.RadioButton();
            this.refreshIntervalTextBox = new System.Windows.Forms.TextBox();
            this.refreshIntervalLabel = new System.Windows.Forms.Label();
            this.seperatorGroupBox.SuspendLayout();
            this.displayGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(76, 15);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(76, 48);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(100, 20);
            this.hostTextBox.TabIndex = 1;
            this.hostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(76, 85);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(76, 120);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(100, 20);
            this.keyTextBox.TabIndex = 3;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(90, 193);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(18, 18);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(32, 17);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "User:";
            // 
            // hostLabel
            // 
            this.hostLabel.Location = new System.Drawing.Point(18, 53);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(33, 23);
            this.hostLabel.TabIndex = 6;
            this.hostLabel.Text = "Host:";
            // 
            // portLabel
            // 
            this.portLabel.Location = new System.Drawing.Point(21, 88);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(30, 23);
            this.portLabel.TabIndex = 7;
            this.portLabel.Text = "Port:";
            // 
            // keyLabel
            // 
            this.keyLabel.Location = new System.Drawing.Point(22, 123);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(29, 23);
            this.keyLabel.TabIndex = 8;
            this.keyLabel.Text = "Key:";
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.Location = new System.Drawing.Point(191, 13);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(95, 24);
            this.autoConnectCheckBox.TabIndex = 9;
            this.autoConnectCheckBox.Text = "Auto-connect";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsCheckBox
            // 
            this.saveSettingsCheckBox.Location = new System.Drawing.Point(191, 34);
            this.saveSettingsCheckBox.Name = "saveSettingsCheckBox";
            this.saveSettingsCheckBox.Size = new System.Drawing.Size(95, 24);
            this.saveSettingsCheckBox.TabIndex = 10;
            this.saveSettingsCheckBox.Text = "Save settings";
            this.saveSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // jsonPathTextBox
            // 
            this.jsonPathTextBox.Location = new System.Drawing.Point(76, 155);
            this.jsonPathTextBox.Name = "jsonPathTextBox";
            this.jsonPathTextBox.Size = new System.Drawing.Size(100, 20);
            this.jsonPathTextBox.TabIndex = 11;
            this.jsonPathTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // jsonPathLabel
            // 
            this.jsonPathLabel.Location = new System.Drawing.Point(11, 158);
            this.jsonPathLabel.Name = "jsonPathLabel";
            this.jsonPathLabel.Size = new System.Drawing.Size(40, 12);
            this.jsonPathLabel.TabIndex = 12;
            this.jsonPathLabel.Text = "JSON:";
            // 
            // tempTextBox
            // 
            this.tempTextBox.Location = new System.Drawing.Point(191, 155);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.Size = new System.Drawing.Size(100, 20);
            this.tempTextBox.TabIndex = 13;
            // 
            // freqTextBox
            // 
            this.freqTextBox.Location = new System.Drawing.Point(191, 198);
            this.freqTextBox.Name = "freqTextBox";
            this.freqTextBox.Size = new System.Drawing.Size(100, 20);
            this.freqTextBox.TabIndex = 14;
            // 
            // freqLabel
            // 
            this.freqLabel.Location = new System.Drawing.Point(203, 178);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(80, 17);
            this.freqLabel.TabIndex = 15;
            this.freqLabel.Text = "Frequency text:";
            // 
            // tempLabel
            // 
            this.tempLabel.Location = new System.Drawing.Point(196, 135);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(92, 17);
            this.tempLabel.TabIndex = 16;
            this.tempLabel.Text = "Temperature text:";
            // 
            // commaRadioButton
            // 
            this.commaRadioButton.Location = new System.Drawing.Point(6, 12);
            this.commaRadioButton.Name = "commaRadioButton";
            this.commaRadioButton.Size = new System.Drawing.Size(64, 24);
            this.commaRadioButton.TabIndex = 20;
            this.commaRadioButton.TabStop = true;
            this.commaRadioButton.Text = "comma";
            this.commaRadioButton.UseVisualStyleBackColor = true;
            // 
            // newLineRadioButton
            // 
            this.newLineRadioButton.Location = new System.Drawing.Point(6, 32);
            this.newLineRadioButton.Name = "newLineRadioButton";
            this.newLineRadioButton.Size = new System.Drawing.Size(64, 24);
            this.newLineRadioButton.TabIndex = 21;
            this.newLineRadioButton.TabStop = true;
            this.newLineRadioButton.Text = "new line";
            this.newLineRadioButton.UseVisualStyleBackColor = true;
            // 
            // seperatorGroupBox
            // 
            this.seperatorGroupBox.Controls.Add(this.commaRadioButton);
            this.seperatorGroupBox.Controls.Add(this.newLineRadioButton);
            this.seperatorGroupBox.Location = new System.Drawing.Point(191, 64);
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
            this.displayGroupBox.Location = new System.Drawing.Point(305, 64);
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
            this.bothRadioButton.TabIndex = 22;
            this.bothRadioButton.TabStop = true;
            this.bothRadioButton.Text = "both";
            this.bothRadioButton.UseVisualStyleBackColor = true;
            // 
            // tempRadioButton
            // 
            this.tempRadioButton.Location = new System.Drawing.Point(6, 12);
            this.tempRadioButton.Name = "tempRadioButton";
            this.tempRadioButton.Size = new System.Drawing.Size(85, 24);
            this.tempRadioButton.TabIndex = 20;
            this.tempRadioButton.TabStop = true;
            this.tempRadioButton.Text = "temperature";
            this.tempRadioButton.UseVisualStyleBackColor = true;
            // 
            // freqRadioButton
            // 
            this.freqRadioButton.Location = new System.Drawing.Point(6, 32);
            this.freqRadioButton.Name = "freqRadioButton";
            this.freqRadioButton.Size = new System.Drawing.Size(76, 24);
            this.freqRadioButton.TabIndex = 21;
            this.freqRadioButton.TabStop = true;
            this.freqRadioButton.Text = "frequency";
            this.freqRadioButton.UseVisualStyleBackColor = true;
            // 
            // refreshIntervalTextBox
            // 
            this.refreshIntervalTextBox.Location = new System.Drawing.Point(305, 175);
            this.refreshIntervalTextBox.Name = "refreshIntervalTextBox";
            this.refreshIntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.refreshIntervalTextBox.TabIndex = 25;
            // 
            // refreshIntervalLabel
            // 
            this.refreshIntervalLabel.Location = new System.Drawing.Point(305, 155);
            this.refreshIntervalLabel.Name = "refreshIntervalLabel";
            this.refreshIntervalLabel.Size = new System.Drawing.Size(85, 13);
            this.refreshIntervalLabel.TabIndex = 26;
            this.refreshIntervalLabel.Text = "Refresh Interval:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(421, 230);
            this.Controls.Add(this.refreshIntervalLabel);
            this.Controls.Add(this.refreshIntervalTextBox);
            this.Controls.Add(this.displayGroupBox);
            this.Controls.Add(this.seperatorGroupBox);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.freqTextBox);
            this.Controls.Add(this.tempTextBox);
            this.Controls.Add(this.jsonPathLabel);
            this.Controls.Add(this.jsonPathTextBox);
            this.Controls.Add(this.saveSettingsCheckBox);
            this.Controls.Add(this.autoConnectCheckBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rtssh";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.seperatorGroupBox.ResumeLayout(false);
            this.displayGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label refreshIntervalLabel;
        private System.Windows.Forms.TextBox refreshIntervalTextBox;

        private System.Windows.Forms.GroupBox displayGroupBox;
        private System.Windows.Forms.RadioButton tempRadioButton;
        private System.Windows.Forms.RadioButton freqRadioButton;
        private System.Windows.Forms.RadioButton bothRadioButton;

        private System.Windows.Forms.GroupBox seperatorGroupBox;

        private System.Windows.Forms.RadioButton commaRadioButton;
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
        private System.Windows.Forms.TextBox keyTextBox;

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox portTextBox;

        #endregion
    }
}