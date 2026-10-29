using System;
using System.Windows.Forms;
using SmartAgri.UI;

namespace SmartAgri.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}