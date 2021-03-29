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
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(124, 12);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(124, 45);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(100, 20);
            this.hostTextBox.TabIndex = 1;
            this.hostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(124, 82);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Text = "22";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(124, 117);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(100, 20);
            this.keyTextBox.TabIndex = 3;
            this.keyTextBox.Text = "id_rsa";
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(138, 190);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(66, 15);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(32, 17);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "User:";
            // 
            // hostLabel
            // 
            this.hostLabel.Location = new System.Drawing.Point(66, 50);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(33, 23);
            this.hostLabel.TabIndex = 6;
            this.hostLabel.Text = "Host:";
            // 
            // portLabel
            // 
            this.portLabel.Location = new System.Drawing.Point(69, 85);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(30, 23);
            this.portLabel.TabIndex = 7;
            this.portLabel.Text = "Port:";
            // 
            // keyLabel
            // 
            this.keyLabel.Location = new System.Drawing.Point(70, 120);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(29, 23);
            this.keyLabel.TabIndex = 8;
            this.keyLabel.Text = "Key:";
            // 
            // autoConnectCheckBox
            // 
            this.autoConnectCheckBox.Location = new System.Drawing.Point(246, 10);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.Size = new System.Drawing.Size(93, 24);
            this.autoConnectCheckBox.TabIndex = 9;
            this.autoConnectCheckBox.Text = "Auto-connect";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsCheckBox
            // 
            this.saveSettingsCheckBox.Location = new System.Drawing.Point(246, 45);
            this.saveSettingsCheckBox.Name = "saveSettingsCheckBox";
            this.saveSettingsCheckBox.Size = new System.Drawing.Size(93, 24);
            this.saveSettingsCheckBox.TabIndex = 10;
            this.saveSettingsCheckBox.Text = "Save settings";
            this.saveSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // jsonPathTextBox
            // 
            this.jsonPathTextBox.Location = new System.Drawing.Point(124, 152);
            this.jsonPathTextBox.Name = "jsonPathTextBox";
            this.jsonPathTextBox.Size = new System.Drawing.Size(100, 20);
            this.jsonPathTextBox.TabIndex = 11;
            this.jsonPathTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // jsonPathLabel
            // 
            this.jsonPathLabel.Location = new System.Drawing.Point(59, 155);
            this.jsonPathLabel.Name = "jsonPathLabel";
            this.jsonPathLabel.Size = new System.Drawing.Size(40, 12);
            this.jsonPathLabel.TabIndex = 12;
            this.jsonPathLabel.Text = "JSON:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(341, 225);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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