using System;
using System.Windows.Forms;

namespace rtssh
{
    internal static class LaunchForm
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}