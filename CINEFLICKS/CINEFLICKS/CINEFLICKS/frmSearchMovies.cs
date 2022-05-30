using Bunifu.UI.WinForms.BunifuAnimatorNS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEFLICKS
{
    public partial class frmSearchMovies : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.ManageMovies objData = new clsProperties.ManageMovies(); // Class object - Data

        string[] genArray; // Genre array
        string[] actArray; // Actor array

        string genList = "";
        string actList = "";

        public frmSearchMovies()
        {
            InitializeComponent();
        }

        // Event - Form load
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Get current DateTime - DateTime object
            DateTime aDate = DateTime.Now;
            lblDate.Text = aDate.ToString("MMMM dd");

            tmrTime.Start(); // Timer - For the time

            // Fetch data and load to DataGridView at the beginning
            LoadDataGridView();

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

            rdMovie.Checked = false;
            rdTVShow.Checked = false;
            ddmRating.Text = "--Please select--";
            ddmRelease.Text = "--Year--";
            ddmCountry.Text = "--Please select--";
            ddmLanguage.Text = "--Please select--";
        }

       

        // Button - Log state
        private void btnLogState_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                frmUserSelection frmUserSelection = new frmUserSelection();
                frmUserSelection.Show();
                this.Hide();
            }


            objSession.SetName(""); // Clear the session
        }

        // Function - LoadDataGridView
        private void LoadDataGridView()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dgvMovies.DataSource = DBCon.ShowDataInGridView("SELECT mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration', mov_language AS Language FROM tbl_movie");
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
        }

        // Funtion - LoadGenreToField
        public void LoadGenreToField()
        {
            txtMovGenre.Text = objData.GetGenList();
        }

        // Funtion - LoadActToField
        public void LoadActToField()
        {
            txtMovCast.Text = objData.GetActList();
        }

        // Button - About
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
                string message = ex.Message;
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        // Timer - Time
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            DateTime atime = DateTime.Now;
            this.lblTime.Text = atime.ToString("hh:mm tt");
        }

        // Button - Dashboard
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        // Function - Clear fields
        private void txtClear()
        {
            txtMovName.Clear();
            txtMovGenre.Clear();
            txtMovCast.Clear();
            ddmRating.Text = "--Please select--";
            rdMovie.Checked = false;
            rdTVShow.Checked = false;
            ddmRelease.Text = "--Year--";
            ddmCountry.Text = "--Please select--";
            ddmLanguage.Text = "--Please select--";

            objData.MovName = "";
            objData.MovType = "";
            objData.MovRating = 0;
            objData.MovInRelease = "";
            objData.MovCountry = "";
            objData.MovLanguage = "";
        }

        // Clear User - click event
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtClear(); // Calling the function - Clear fields

            LoadDataGridView();
        }

        // Button - Manage Users
        private void btnManageUsr_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
            this.Hide();
        }

        // Button - Manage Genre
        private void btnManageGenre_Click(object sender, EventArgs e)
        {
            frmManageGenres frmManageGenres = new frmManageGenres();
            frmManageGenres.Show();
            this.Hide();
        }

        // Button - Manage actors
        private void btnManageActors_Click(object sender, EventArgs e)
        {
            frmManageActors frmManageActors = new frmManageActors();
            frmManageActors.Show();
            this.Hide();
        }

        // Get filter data from user and pass them to data class
        private void GetFiltersFromUsr()
        {
            if (txtMovName.Text != "")
            {
                objData.MovName = txtMovName.Text;
            }
            /*----------------------------------------------*/
            if (rdMovie.Checked)
            {
                objData.MovType = "Movie";
            }
            else if (rdTVShow.Checked)
            {
                objData.MovType = "TV-Show";
            }
            /*----------------------------------------------*/
            if (ddmRating.Text == "2+ Star Rating")
            {
                objData.MovRating = 2;
            }
            else if (ddmRating.Text == "4+ Star Rating")
            {
                objData.MovRating = 4;
            }
            else if (ddmRating.Text == "6+ Star Rating")
            {
                objData.MovRating = 6;
            }
            else if (ddmRating.Text == "8+ Star Rating")
            {
                objData.MovRating = 8;
            }
            else
            {
                objData.MovRating = 10;
            }
            /*----------------------------------------------*/
            if (ddmRelease.Text != "--Year--")
            {
                objData.MovInRelease = ddmRelease.Text;
            }
            /*----------------------------------------------*/
            if (ddmCountry.Text != "--Please select--")
            {
                objData.MovCountry = ddmCountry.Text;
            }
            /*----------------------------------------------*/
            if (ddmLanguage.Text != "--Please select--")
            {
                objData.MovLanguage = ddmLanguage.Text;
            }
        }

        // Split genre string into an array
        public void StringGenToArray()
        {
            // Replace spaces and pipes with a single pipe  
            string genList = txtMovGenre.Text;
            genList = genList.Replace(" | ", "|");

            // Split genres separated by a pipe
            genArray = genList.Split('|');
        }

        // Split actor string into an array
        public void StringActToArray()
        {
            // Replace spaces and pipes with a single pipe  
            string actList = txtMovCast.Text;
            actList = actList.Replace(" | ", "|");

            // Split actors separated by a pipe
            actArray = actList.Split('|');
        }


        // Button - Genre Pop-Up
        private void txtMovGenre_MouseClick_1(object sender, MouseEventArgs e)
        {
            frmSelectGenrePopUp frmSelectGenrePopUp = new frmSelectGenrePopUp();
            frmSelectGenrePopUp.ShowDialog();
        }

        // Button - Actor Pop-Up
        private void txtMovCast_MouseClick(object sender, MouseEventArgs e)
        {
            frmSelectActorPopUp frmSelectActorPopUp = new frmSelectActorPopUp();
            frmSelectActorPopUp.ShowDialog();
        }

        // Button - Manage movies
        private void btnManageMov_Click(object sender, EventArgs e)
        {
            frmManageMovies frmManageMovies = new frmManageMovies();
            frmManageMovies.Show();
            this.Hide();
        }

        // Search movie using the movie name
        private void txtMovName_TextChange(object sender, EventArgs e)
        {
            (dgvMovies.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("Name LIKE '%{0}%'", txtMovName.Text);
        }

        // Button - Search Movie
        private void btnMovSearch_Click(object sender, EventArgs e)
        {
            if (txtMovName.Text != "" || rdMovie.Checked || rdTVShow.Checked || ddmRating.Text != "--Please select--" || ddmRelease.Text != "--Year--" || ddmCountry.Text != "--Please select--" || ddmLanguage.Text != "--Please select--")
            {
                GetFiltersFromUsr();

                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection

                    string query = "SELECT mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration', mov_language AS Language FROM tbl_movie WHERE ";
                    /*-----------------------------------------------------------------*/
                    if (txtMovName.Text != "")
                    {
                        query += "mov_name LIKE '%" + objData.MovName + "%' AND ";
                    }
                    /*-----------------------------------------------------------------*/
                    if (rdMovie.Checked || rdTVShow.Checked)
                    {
                        query += "mov_type = '" + objData.MovType + "' AND ";
                    }
                    /*-----------------------------------------------------------------*/
                    if (ddmRating.Text != "--Please select--")
                    {
                        if (objData.MovType == "2")
                        {
                            query += "mov_rating >= '" + objData.MovRating + "' AND ";
                        }
                        else if (objData.MovType == "4")
                        {
                            query += "mov_rating >= '" + objData.MovRating + "' AND ";
                        }
                        else if (objData.MovType == "6")
                        {
                            query += "mov_rating >= '" + objData.MovRating + "' AND ";
                        }
                        else if (objData.MovType == "8")
                        {
                            query += "mov_rating >= '" + objData.MovRating + "' AND ";
                        }
                        else
                        {
                            query += "mov_rating >= '" + objData.MovRating + "' AND ";
                        }
                    }
                    /*-----------------------------------------------------------------*/
                    if (ddmRelease.Text != "--Year--")
                    {
                        query += "year(mov_release_date) = '" + objData.MovInRelease + "' AND ";
                    }
                    /*-----------------------------------------------------------------*/
                    if (ddmCountry.Text != "--Please select--")
                    {
                        query += "mov_country = '" + objData.MovCountry + "' AND ";
                    }
                    /*-----------------------------------------------------------------*/
                    if (ddmLanguage.Text != "--Please select--")
                    {
                        query += "mov_language = '" + objData.MovLanguage + "' AND ";
                    }

                    query = query.Remove(query.Length - 5); // Remove last 5 characters from the string
                    query += ";";

                    dgvMovies.DataSource = DBCon.ShowDataInGridView(query);
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
            }
            else
            {
                string message = "Please type the movie name or select at least one filter";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

        // Movie PopUp funtion
        private void dgvMovies_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tempMovName = dgvMovies.Rows[e.RowIndex].Cells[0].Value.ToString();
                int tempMovInRating = (int)dgvMovies.Rows[e.RowIndex].Cells[2].Value;
                string tempMovPrCompany = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();

                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    dr = DBCon.DataReader("SELECT mov_id FROM tbl_movie WHERE mov_name = '" + tempMovName + "' AND mov_rating = '" + tempMovInRating + "' AND mov_prod_company = '" + tempMovPrCompany + "'");

                    if (dr.Read())
                    {
                        objData.MovID = (dr["mov_id"].ToString());

                        Form formBackground = new Form();
                        try
                        {
                            using (frmViewMovie uu = new frmViewMovie())
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
                            string message = ex.Message;
                            string title = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            formBackground.Dispose();
                        }

                    }
                    else
                    {
                        string message = "The movie does not exist";
                        string title = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                }
                catch (MySqlException ex)
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
            }
        }

        private void frmSearchMovies_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Search movie - KeyDown Event
        private void txtMovName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMovSearch.PerformClick();
            }
        }
    }
}