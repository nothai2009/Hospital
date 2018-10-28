using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace CSWinFormSingleInstanceApp
{
    public class SingleInstanceAppStarter
    {
        private static SingleInstanceApp app = null;

        // Construct SingleInstanceApp object, and invoke its run method.
        public static void Start(Form f, StartupNextInstanceEventHandler handler)
        {
            if (app == null && f != null)
                app = new SingleInstanceApp(f);

            // Wire up StartupNextInstance event handler.
            app.StartupNextInstance += handler;
            app.Run(Environment.GetCommandLineArgs());
        }
    }
}