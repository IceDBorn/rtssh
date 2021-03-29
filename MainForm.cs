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
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            _thread = new Thread(() => SSHStream.Start(
                usernameTextBox.Text, 
                hostTextBox.Text, 
                int.Parse(portTextBox.Text), 
                keyTextBox.Text
            ));
            _thread.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _thread.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}