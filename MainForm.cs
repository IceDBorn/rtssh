using System;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace rtssh
{
    public partial class MainForm : Form
    {
        private Thread _thread;
        private const string RunRegKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private readonly string _executablePath = "\"" + Application.ExecutablePath + "\"";
        private const string AppName = "rtssh";
        private readonly string[] _args;

        public MainForm(string[] args)
        {
            InitializeComponent();
            InitializeValues();
            _args = args;
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
            keyBrowser.ShowDialog();
            if (keyBrowser.FileName.Length > 0)
            {
                keyTextBox.Text = keyBrowser.FileName;
            }
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

        //Methods

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
            commaRadioButton.Checked = Properties.Settings.Default.separatorComma;
            RefreshIntervalNumeric.Text = Properties.Settings.Default.refreshInterval;
            startupCheckBox.Checked = Properties.Settings.Default.startup;

            if (!commaRadioButton.Checked)
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
                        ? @"Fill in all values except JSON"
                        : @"Fill in all values");

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
            _thread = new Thread(() => SSHStream.Start(
                usernameTextBox.Text,
                hostTextBox.Text,
                int.Parse(portTextBox.Text),
                keyTextBox.Text,
                jsonPathTextBox.Text,
                tempTextBox.Text,
                freqTextBox.Text,
                commaRadioButton.Checked,
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
                    commaRadioButton.Checked,
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
    }
}