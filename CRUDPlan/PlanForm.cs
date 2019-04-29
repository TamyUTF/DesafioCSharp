using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPlan
{
    public partial class PlanForm : Form
    {
        public PlanForm()
        {
            InitializeComponent();
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
