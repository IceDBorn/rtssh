using System;
using System.Windows.Forms;

namespace rtssh
{
    internal static class LaunchForm
    {
        #region Contructor
        
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm(args);
            Application.Run(MainForm);
        }
        
        #endregion

        #region Getters/Setters
        
        public static MainForm MainForm{ get; private set; }
        
        #endregion
    }
}