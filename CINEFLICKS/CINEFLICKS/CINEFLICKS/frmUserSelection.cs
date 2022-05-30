using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEFLICKS
{
    public partial class frmUserSelection : Form
    {
        public frmUserSelection()
        {
            InitializeComponent();
        }

        private void btnUsrAdmin_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void txtUsrAdmin_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnUsrGuest_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void txtUsrGuest_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void frmUserSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}