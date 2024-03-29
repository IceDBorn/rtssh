﻿using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace rtssh
{
    public enum ConnectionStatus { Disconnected, Connecting, Connected }
    public partial class MainForm : Form
    {
        #region Fields
        
        private Thread _thread;
        private const string RunRegKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private readonly string _executablePath = "\"" + Application.ExecutablePath + "\"";
        private const string AppName = "rtssh";
        private readonly string[] _args;
        
        #endregion

        #region Constructor
        
        public MainForm(string[] args)
        {
            InitializeComponent();
            _args = args;
        }
        
        #endregion

        #region Getters/Setters
        
        public string JsonPathTextBox { set => jsonPathTextBox.Text = value; }

        private ConnectionStatus _connectionStatus;
        public ConnectionStatus ConnectionStatus
        {
            get => _connectionStatus;
            set
            {
                switch (value)
                {
                    case ConnectionStatus.Disconnected:
                    {
                        connectionStatusLabel.Text = @"Disconnected";
                        connectionStatusLabel.ForeColor = Color.Red;
                        break;
                    }
                    case ConnectionStatus.Connecting:
                    {
                        connectionStatusLabel.Text = @"Connecting";
                        connectionStatusLabel.ForeColor = Color.Orange;
                        break;
                    }
                    case ConnectionStatus.Connected:
                    {
                        connectionStatusLabel.Text = @"Connected";
                        connectionStatusLabel.ForeColor = Color.Green;
                        break;
                    }
                    default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                    }
                }

                _connectionStatus = value;
            }
        }

        #endregion

        #region Events
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeValues();
        }
        
        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadKiller();
        }

        private void keyBrowserButton_Click(object sender, EventArgs e)
        {
            fileBrowser.FileName = "";
            fileBrowser.Title = @"Select private key file";
            fileBrowser.Filter = @"All files (*.*)|*.*";
            fileBrowser.ShowDialog();
            
            if (string.IsNullOrEmpty(fileBrowser.FileName)) return;
            keyTextBox.Text = fileBrowser.FileName;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BringToForeground();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            MinimizeToTray();
        }

        private void saveSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (saveSettingsCheckBox.Checked) return;
            Settings.Clear();
        }

        private void startupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startupCheckBox.Checked)
            {
                AddToStartup();
            }
            else
            {
                RemoveFromStartup();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (_args == null || _args.Length <= 0) return;
            if (_args[0].Equals("-silent"))
            {
                MinimizeToTray();
            }
        }
        
        private void showStripMenuItem_Click(object sender, EventArgs e)
        {
            BringToForeground();
        }
        
        private void exitStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void jsonBrowserButton_Click(object sender, EventArgs e)
        {
            fileBrowser.FileName = "";
            fileBrowser.Title = @"Select JSON file";
            fileBrowser.Filter = @"json files (*.json)|*.json";
            fileBrowser.ShowDialog();
            
            if (string.IsNullOrEmpty(fileBrowser.FileName)) return;
            var treeViewJson = new TreeViewJson(fileBrowser.FileName);
            treeViewJson.ShowDialog();
        }
        
        #endregion

        #region  Methods

        private void InitializeValues()
        {
            // Initialize all textboxes and checkboxes
            usernameTextBox.Text = Properties.Settings.Default.username;
            hostTextBox.Text = Properties.Settings.Default.host;
            portTextBox.Text = Properties.Settings.Default.port;
            keyTextBox.Text = Properties.Settings.Default.key;
            jsonPathTextBox.Text = Properties.Settings.Default.jsonPath;
            tempTextBox.Text = Properties.Settings.Default.tempText;
            freqTextBox.Text = Properties.Settings.Default.freqText;
            autoConnectCheckBox.Checked = Properties.Settings.Default.autoConnect;
            saveSettingsCheckBox.Checked = Properties.Settings.Default.saveSettings;
            spaceRadioButton.Checked = Properties.Settings.Default.separatorSpace;
            RefreshIntervalNumeric.Text = Properties.Settings.Default.refreshInterval;
            startupCheckBox.Checked = Properties.Settings.Default.startup;

            if (!spaceRadioButton.Checked)
            {
                newLineRadioButton.Checked = true;
            }

            switch (Properties.Settings.Default.displayToggle)
            {
                // temp
                case 0:
                {
                    tempRadioButton.Checked = true;
                    break;
                }
                // freq
                case 1:
                {
                    freqRadioButton.Checked = true;
                    break;
                }
                // both
                case 2:
                {
                    bothRadioButton.Checked = true;
                    break;
                }
            }

            // Connect if Auto Connect is enabled
            if (usernameTextBox.Text.Length <= 0 || hostTextBox.Text.Length <= 0 || portTextBox.Text.Length <= 0 ||
                keyTextBox.Text.Length <= 0 || jsonPathTextBox.Text.Length <= 0 || !autoConnectCheckBox.Checked) return;
            Connect();
        }

        private void Connect()
        {
            ThreadKiller();

            switch (usernameTextBox.Text.Length > 0)
            {
                case true when hostTextBox.Text.Length > 0 && portTextBox.Text.Length > 0 &&
                               keyTextBox.Text.Length > 0 && jsonPathTextBox.Text.Length > 0:
                case true when hostTextBox.Text.Length > 0 && portTextBox.Text.Length > 0 &&
                               keyTextBox.Text.Length > 0 && freqRadioButton.Checked:
                    ThreadMaker();
                    break;
                default:
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show(freqRadioButton.Checked
                        ? @"Fill all connection fields"
                        : @"Fill all connection fields and JSON Path");
                    break;
                }
            }
        }

        private void ThreadKiller()
        {
            // Check if a thread is running and kill it 
            try
            {
                if (_thread.IsAlive)
                {
                    _thread.Abort();
                }
            }
            catch
            {
                // ignored
            }
        }

        private void ThreadMaker()
        {
            var displayToggle = DisplayToggle();

            // Start new ssh connection thread
            _thread = new Thread(() => SshStream.Start(
                usernameTextBox.Text,
                hostTextBox.Text,
                int.Parse(portTextBox.Text),
                keyTextBox.Text,
                jsonPathTextBox.Text,
                tempTextBox.Text,
                freqTextBox.Text,
                spaceRadioButton.Checked,
                displayToggle,
                RefreshIntervalNumeric.Text
            ));
            _thread.Start();

            SaveSettings(displayToggle);
        }

        private int DisplayToggle()
        {
            int displayToggle;
            if (tempRadioButton.Checked)
            {
                displayToggle = 0;
            }
            else if (freqRadioButton.Checked)
            {
                displayToggle = 1;
            }
            //both
            else
            {
                displayToggle = 2;
            }

            return displayToggle;
        }

        private void SaveSettings(int displayToggle)
        {
            // Save or clear settings
            if (saveSettingsCheckBox.Checked)
            {
                Settings.Save(usernameTextBox.Text,
                    hostTextBox.Text,
                    portTextBox.Text,
                    keyTextBox.Text,
                    jsonPathTextBox.Text,
                    autoConnectCheckBox.Checked,
                    tempTextBox.Text,
                    freqTextBox.Text,
                    spaceRadioButton.Checked,
                    displayToggle,
                    RefreshIntervalNumeric.Text,
                    startupCheckBox.Checked);
            }
        }

        private void AddToStartup()
        {
            // Add key to startup
            if (IsInStartup()) return;
            using (var key = Registry.CurrentUser.OpenSubKey(RunRegKey, true))
            {
                key?.SetValue(AppName, _executablePath + " -silent");
            }
        }

        private void RemoveFromStartup()
        {
            // Remove key from startup
            if (!IsInStartup()) return;
            using (var key = Registry.CurrentUser.OpenSubKey(RunRegKey, true))
            {
                key?.DeleteValue(AppName, false);
            }
        }

        private bool IsInStartup()
        {
            // Check if key exists
            using (var key = Registry.CurrentUser.OpenSubKey(RunRegKey, true))
            {
                var value = key?.GetValue(AppName);
                return value is string startValue && startValue.StartsWith(_executablePath);
            }
        }

        private void MinimizeToTray()
        {
            // Hide form
            Hide();

            // Show tray icon
            trayIcon.Visible = true;
        }

        private void BringToForeground()
        {
            Show();
            // Bring form foreground
            WindowState = FormWindowState.Normal;

            // Hide tray icon
            trayIcon.Visible = false;
        }
        
        #endregion
    }
}