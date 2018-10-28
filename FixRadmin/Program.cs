using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixRadmin
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathProgram = @"\\192.168.0.9\homc\2 - Setup Programs\Remote Admin_V3.4_P2\install.bat";
            ProcessStartInfo info = new ProcessStartInfo(pathProgram);
            info.UseShellExecute = true;
            info.Verb = "runas";
            Process.Start(info);
        }
    }
}
