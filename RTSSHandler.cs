using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using RTSSSharedMemoryNET;

namespace rtssh
{
    internal static class RTSSHandler
    {
        #region Fields
        private static Process _rtssInstance;
        private static OSD _osd;
        #endregion

        #region Properties
        // Path to RTSS
        private static string RTSSPath {get;}

        // Return true if RTSS is running
        private static bool IsRunning => Process.GetProcessesByName("RTSS").Length != 0;
        #endregion

        #region Constructor
        // Initialize a new instance of the RTSSHandler class
        static RTSSHandler()
        {
            RTSSPath = @"C:\Program Files (x86)\RivaTuner Statistics Server\RTSS.exe";
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
        public static void RunRTSS()
        {
            if (_rtssInstance == null && !IsRunning && File.Exists(RTSSPath))
            {
                try
                {
                    _rtssInstance = Process.Start(RTSSPath);
                    Thread.Sleep(2000);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(@"Could not start RTSS");
                }

                RunOSD();
            }
            else
            {
                RunOSD();
            }
        }
        
        // Launches OSD
        private static void RunOSD()
        {
            if (_osd != null) return;
            try
            {
                _osd = new OSD("rtssh");
            }
            catch (Exception exc)
            {
                MessageBox.Show(@"Could not start OSD");
            }
        }
        #endregion
    }
}