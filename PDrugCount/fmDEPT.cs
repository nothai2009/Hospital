using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDrugCount
{
    public partial class fmDEPT : Form
    {
        public fmDEPT()
        {
            InitializeComponent();
        }

        private void fmDEPT_Load(object sender, EventArgs e)
        {
            var sql = "SELECT [deptCode],[deptDesc],[hos_id] FROM[UDON2].[dbo].[DEPT]";
        }
    }
}
