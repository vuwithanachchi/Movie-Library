using Bunifu.UI.WinForms.BunifuAnimatorNS;
using MySql.Data.MySqlClient;
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
    public partial class frmDashboard : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        public frmDashboard()
        {
            InitializeComponent();
        }
        
        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            // Get current DateTime - DateTime object
            DateTime aDate = DateTime.Now;
            lblDate.Text = aDate.ToString("MMMM dd");

            tmrTime.Start();

            string uName = objSession.GetName();
            if (uName != "")
            {
                btnLogState.Text = "Log Out";
            }
            else
            {
                btnLogState.Text = "Log In";
            }

            // Disable buttons for guest users
            if (uName == "")
            {
                btnManageMov.Enabled = false;
                btnManageActors.Enabled = false;
                btnManageGenre.Enabled = false;
            }

            // Disable manage user button
            if (uName != "admin")
            {
                btnManageUsr.Enabled = false;
            }

            // Movie and TV show count
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                string checkQry = "SELECT COUNT(mov_name) FROM cineflicksdb.tbl_movie WHERE mov_type = 'Movie';";
                int mCount = DBCon.ExecuteScalar(checkQry);

                lblMovCount.Text = mCount.ToString();

                checkQry = "SELECT COUNT(mov_name) FROM cineflicksdb.tbl_movie WHERE mov_type = 'TV-Show';";
                int tvCount = DBCon.ExecuteScalar(checkQry);

                lblTVCount.Text = tvCount.ToString();
            }
            catch (MySqlException ex)
            {
                string message = ex.Message;
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
            finally
            {
                DBCon.CloseConnection(); // Calling the method to close the DB connection
            }

            // Bunifu card transitions
            await Task.Delay(500);
            bunifuTransition1.ShowSync(bunifuCards1, false, Animation.Mosaic);
            bunifuTransition1.ShowSync(bunifuCards2, false, Animation.Mosaic);
        }

        private void btnLogState_Click(object sender, EventArgs e)
        {
            if (btnLogState.Text == "Log In")
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Hide();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    frmUserSelection frmUserSelection = new frmUserSelection();
                    frmUserSelection.Show();
                    this.Hide();

                    objSession.SetName("");
                }
            }
        }

        private void panelMain_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (frmAbout uu = new frmAbout())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();

                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            DateTime atime = DateTime.Now;
            this.lblTime.Text = atime.ToString("hh:mm tt");
        }

        private void btnManageUsr_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
            this.Hide();
        }

        private void btnManageGenre_Click(object sender, EventArgs e)
        {
            frmManageGenres frmManageGenres = new frmManageGenres();
            frmManageGenres.Show();
            this.Hide();
        }

        private void btnManageActors_Click(object sender, EventArgs e)
        {
            frmManageActors frmManageActors = new frmManageActors();
            frmManageActors.Show();
            this.Hide();
        }

        private void btnManageMov_Click(object sender, EventArgs e)
        {
            frmManageMovies frmManageMovies = new frmManageMovies();
            frmManageMovies.Show();
            this.Hide();
        }

        // Button - Search Movies
        private void btnSearchMov_Click(object sender, EventArgs e)
        {
            frmSearchMovies frmSearchMovies = new frmSearchMovies();
            frmSearchMovies.Show();
            this.Hide();
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}