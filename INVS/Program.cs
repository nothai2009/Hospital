using CSWinFormSingleInstanceApp;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace INVS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceAppStarter.Start(new fmMain(), StartNewInstance);
        }

        private static void StartNewInstance(object sender, StartupNextInstanceEventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            if (forms["fmMain"] != null)
            {
                forms["fmMain"].WindowState = FormWindowState.Maximized;
                forms["fmMain"].Activate();
            }
        }
    }
}