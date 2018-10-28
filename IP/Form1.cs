using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //IP Computer
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == AddressFamily.InterNetwork).ToArray();
            lbIP.Text = "IP : "+addresses[0].ToString();
        }
    }
}
