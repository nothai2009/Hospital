using CSWinFormSingleInstanceApp;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace PDrugCount
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
            // Start the message loop and pass in the main form reference.
            SingleInstanceAppStarter.Start(new fmMain(), StartNewInstance);
        }

        private static void StartNewInstance(object sender, StartupNextInstanceEventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            if (forms["fmMain"] != null)
            {
                forms["fmMain"].Activate();
            }

           
        }
    }
}
