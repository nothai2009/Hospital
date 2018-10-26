using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace CSWinFormSingleInstanceApp
{
    // We need to add Microsoft.VisualBasic reference to use
    // WindowsFormsApplicationBase type.
    internal class SingleInstanceApp : WindowsFormsApplicationBase
    {
        public SingleInstanceApp()
        {
        }

        public SingleInstanceApp(Form f)
        {
            // Set IsSingleInstance property to true to make the application
            base.IsSingleInstance = true;
            // Set MainForm of the application.
            this.MainForm = f;
        }
    }
}