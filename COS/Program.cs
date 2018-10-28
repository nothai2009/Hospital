using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace CSWinFormSingleInstanceApp
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
            SingleInstanceAppStarter.Start(new MainForm(), StartNewInstance);
        }

        // The handler when attempting to start another instance of this application
        // We can customize the logic here for which form to activate in different
        // conditions. Like in this sample, we will be selectively activate the LoginForm
        // or MainForm based on the login state of the user.
        private static void StartNewInstance(object sender, StartupNextInstanceEventArgs e)
        {
            FormCollection forms = Application.OpenForms;
            if (forms["LoginForm"] != null)
            {
                forms["MainForm"].Hide();
                forms["LoginForm"].Activate();
            }
            else if (forms["LoginForm"] == null && GlobleData.IsUserLoggedIn == false)
            {
                MessageBox.Show("22");
                LoginForm f = new LoginForm();
                if (!(f.ShowDialog() == DialogResult.OK))
                {
                    forms["MainForm"].WindowState = FormWindowState.Maximized;
                    forms["MainForm"].Show();
                }
                else
                {
                    forms["MainForm"].Close();
                }
            }
            else if (forms["MainForm"] == null && GlobleData.IsUserLoggedIn == true)
            {
                MessageBox.Show("23");
                LoginForm f = new LoginForm();
                if (!(f.ShowDialog() == DialogResult.Cancel))
                {
                    forms["LoginForm"].Show();
                }
            }
            else if (forms["MainForm"] != null && GlobleData.IsUserLoggedIn == false)
            {
                LoginForm f = new LoginForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    forms["MainForm"].WindowState = FormWindowState.Maximized;
                    forms["MainForm"].Show();
                }
            }
            else if (forms["MainForm"] != null && GlobleData.IsUserLoggedIn == true)
            {
                LoginForm f = new LoginForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    forms["MainForm"].Show();
                    forms["MainForm"].WindowState = FormWindowState.Maximized;
                }
            }
            else if (forms["MainForm"] != null && GlobleData.IsUserLoggedIn == true && forms["MainForm"].WindowState == FormWindowState.Minimized)
            {
                MessageBox.Show("4");
                LoginForm f = new LoginForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    forms["MainForm"].WindowState = FormWindowState.Maximized;
                    forms["MainForm"].Show();
                }
            }
            else if (forms["MainForm"] != null && GlobleData.IsUserLoggedIn == true && forms["MainForm"].WindowState == FormWindowState.Maximized)
            {
                MessageBox.Show("5");
                LoginForm f = new LoginForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    forms["MainForm"].WindowState = FormWindowState.Maximized;
                    forms["MainForm"].Show();
                }
            }
            else
            {
                MessageBox.Show("6");
            }
        }
    }
}