using System.Diagnostics;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using RTSSSharedMemoryNET;

namespace rtssh
{
    internal static class RtssHandler
    {
        #region Fields
        private static Process _rtssInstance;
        private static OSD _osd;
        #endregion

        #region Properties
        // Path to RTSS
        private static string RtssPath {get;}

        // Return true if RTSS is running
        private static bool IsRunning => Process.GetProcessesByName("RTSS").Length != 0;
        #endregion

        #region Constructor
        // Initialize a new instance of the RTSSHandler class
        static RtssHandler()
        {
            RtssPath = @"C:\Program Files (x86)\RivaTuner Statistics Server\RTSS.exe";
        }
        #endregion

        #region Methods
        // Send text to RTSS
        public static void Print(string text)
        {
            if (IsRunning)
            {
                _osd?.Update(text);
            }
        }
        
        /// Launch RTSS
        public static void RunRtss()
        {
            if (_rtssInstance == null && !IsRunning)
            {
                try
                {
                    _rtssInstance = Process.Start(RtssPath);
                    Thread.Sleep(2000);
                    RunOsd();
                }
                catch
                {
                    LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                    SystemSounds.Beep.Play();
                    MessageBox.Show(@"Make sure RTSS is installed in the default location!");
                }
            }
            else
            {
                RunOsd();
            }
        }
        
        // Launches OSD
        private static void RunOsd()
        {
            if (_osd != null) return;
            try
            {
                _osd = new OSD("rtssh");
            }
            catch
            {
                LaunchForm.MainForm.ConnectionStatus = ConnectionStatus.Disconnected;
                SystemSounds.Beep.Play();
                MessageBox.Show(@"Could not start OSD!");
            }
        }
        #endregion
    }
}