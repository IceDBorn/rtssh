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
            usernameTextBox.Text = Properties.Settings.Default.Username;
            hostTextBox.Text = Properties.Settings.Default.Host;
            portTextBox.Text = Properties.Settings.Default.Port;
            keyTextBox.Text = Properties.Settings.Default.Key;
            autoConnectCheckBox.Checked = Properties.Settings.Default.autoConnect;
            saveSettingsCheckBox.Checked = Properties.Settings.Default.saveSettings;
            
            // Connect if Auto Connect is enabled
            if (autoConnectCheckBox.Checked)
            {
                Connect();
            }
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
            // Check if a thread is running and then kill it 
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
            
            // Start new ssh connection thread
            _thread = new Thread(() => SSHStream.Start(
                usernameTextBox.Text, 
                hostTextBox.Text, 
                int.Parse(portTextBox.Text), 
                keyTextBox.Text
            ));
            _thread.Start();
            
            // Save or clear settings
            if (saveSettingsCheckBox.Checked)
            {
                Settings.Save(usernameTextBox.Text, 
                    hostTextBox.Text, 
                    portTextBox.Text, 
                    keyTextBox.Text,
                    autoConnectCheckBox.Checked);
            }
            else
            {
                Settings.Clear();
            }
        }
    }
}