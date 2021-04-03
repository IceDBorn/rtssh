using System;
using System.Threading;
using System.Windows.Forms;

namespace rtssh
{
    public partial class MainForm : Form
    {
        private Thread _thread;

        public MainForm()
        {
            InitializeComponent();
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
            refreshIntervalTextBox.Text = Properties.Settings.Default.refreshInterval;
            
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

        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop the ssh connection when the form is closed
            try
            {
                _thread.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Methods
        private void Connect()
        {
            if (usernameTextBox.Text.Length > 0 && hostTextBox.Text.Length > 0 && portTextBox.Text.Length > 0 &&
                keyTextBox.Text.Length > 0 && jsonPathTextBox.Text.Length > 0)
            {
                // Check if a thread is running and kill it 
                try
                {
                    if (_thread.IsAlive)
                    {
                        _thread.Abort();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

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
                    refreshIntervalTextBox.Text
                ));
                _thread.Start();

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
                        refreshIntervalTextBox.Text);
                }
                else
                {
                    Settings.Clear();
                }
            }
            else
            {
                MessageBox.Show(@"Fill in all values");
            }
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
            Show();
            // Bring form foreground
            WindowState = FormWindowState.Normal;
            
            // Hide tray icon
            trayIcon.Visible = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) return;
            
            // Hide form
            Hide();
                
            // Show tray icon
            trayIcon.Visible = true;
        }
    }
}