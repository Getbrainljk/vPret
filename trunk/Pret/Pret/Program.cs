using System;
using System.Linq;
using System.Windows.Forms;
using log4net;
using vPret;

namespace Pret
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Program.Debug("*********************************************");
            Log.Program.Debug("Program starting...");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Vpret());
        }
    }
}