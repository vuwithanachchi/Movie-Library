using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEFLICKS
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            if (proBarLoading.Value != 100)
            {
                proBarLoading.Value += 10;
            }

            if (proBarLoading.Value == 100)
            {
                tmrLoading.Stop();
                this.Close();
            }
        }
    }
}
