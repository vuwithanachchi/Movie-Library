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
    public partial class frmManageGenres : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.ManageGenres objData = new clsProperties.ManageGenres(); // Class object - Data

        string lastID = ""; // Varible for hold last ID
        string newID = ""; // Variable for hold new ID
        int tempID; // Temp variable for hold last two digits of the ID as a INT

        public frmManageGenres()
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

            // Call genre ID function
            NewGenID();

            // Disable manage user button
            if (objSession.GetName() != "admin")
            {
                btnManageUsr.Enabled = false;
            }
        }

        // Create new Genre ID
        private void NewGenID()
        {
            FetchLastGenID();
            newID = lastID.Substring(lastID.Length - 2);
            tempID = Int32.Parse(newID) + 1;
            newID = "CIN-G" + tempID.ToString("D" + newID.Length);
            txtGenID.Text = newID;
        }

        // Function - LoadDataGridView
        private void LoadDataGridView()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dgvGenres.DataSource = DBCon.ShowDataInGridView("SELECT genre_id AS 'ID', genre_name AS 'Name' FROM tbl_genre");
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
            txtGenID.Clear();
            txtGenName.Clear();
        }

        // Clear User - click event
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtClear(); // Calling the function - Clear fields

            NewGenID(); // Call genre ID function
        }

        // Fetch last genre ID
        private void FetchLastGenID()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                string checkQry = "SELECT MAX(genre_id) FROM tbl_genre;";
                dr = DBCon.DataReader(checkQry);

                while (dr.Read())
                {
                    lastID = (dr["MAX(genre_id)"].ToString());
                }

                DBCon.CloseConnection(); // Calling the method to close the DB connection
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

        // Button - Manage Users
        private void btnManageUsr_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.Show();
            this.Hide();
        }

        // Button add - click event
        private void btnGenAdd_Click(object sender, EventArgs e)
        {
            objData.GenID = txtGenID.Text;
            objData.GenName = txtGenName.Text;

            // Confirm that fields are not empty
            if (objData.GenID.Length == 0 || objData.GenName.Length == 0)
            {
                string message = "Fields cannot be empty!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                string dupCheck = ""; // Varible for check duplicate entries

                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    string checkQry = "SELECT * FROM tbl_genre WHERE genre_name = '" + objData.GenName + "'";
                    dr = DBCon.DataReader(checkQry);

                    while (dr.Read())
                    {
                        dupCheck = (dr["genre_name"].ToString());
                    }

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    // Check duplicate entries
                    if (objData.GenName == dupCheck)
                    {
                        string message = "This genre is already in the system!";
                        string title = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection

                        string instQry = "INSERT INTO tbl_genre VALUES ('" + objData.GenID + "','" + objData.GenName + "')";
                        DBCon.ExecuteQueries(instQry);

                        string message = "Genre added successfully!";
                        string title = "Success";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                        txtClear();

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        dgvGenres.DataSource = DBCon.ShowDataInGridView("SELECT genre_id AS 'ID', genre_name AS 'Name' FROM tbl_genre");
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

                NewGenID(); // Call genre ID function
            }
        }

        // Button update - click event
        private void btnGenUpdate_Click(object sender, EventArgs e)
        {
            objData.GenID = txtGenID.Text;
            objData.GenName = txtGenName.Text;

            // Confirm that fields are not empty
            if (objData.GenID.Length == 0 || objData.GenName.Length == 0)
            {
                string message = "Please select the genre, first!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection

                    string updQry = "UPDATE tbl_genre SET genre_name = '" + objData.GenName + "' WHERE genre_id = '" + objData.GenID + "'";
                    DBCon.ExecuteQueries(updQry);

                    string message = "Genre updated successfully!";
                    string title = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    txtClear();

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    dgvGenres.DataSource = DBCon.ShowDataInGridView("SELECT genre_id AS 'ID', genre_name AS 'Name' FROM tbl_genre");
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

                NewGenID(); // Call genre ID function
            }
        }

        // Button delete - click event
        private void btnGenDelete_Click(object sender, EventArgs e)
        {
            objData.GenID = txtGenID.Text;
            objData.GenName = txtGenName.Text;

            // Confirm the selection
            if (objData.GenID.Length == 0 || objData.GenName.Length == 0)
            {
                string message = "Please select the genre, first!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string usrCheck = ""; // Varible for check existing records

                    try
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection
                        string checkQry = "SELECT * FROM tbl_genre WHERE genre_id = '" + objData.GenID + "'";
                        dr = DBCon.DataReader(checkQry);

                        while (dr.Read())
                        {
                            usrCheck = (dr["genre_id"].ToString());
                        }

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        // Check --> inserted genre is already there or not
                        if (objData.GenID == usrCheck)
                        {
                            DBCon.OpenConection(); // Calling the method to open the DB connection

                            string delQry = "DELETE FROM tbl_genre WHERE genre_id = '" + objData.GenID + "'";
                            DBCon.ExecuteQueries(delQry);

                            string message = "Genre deleted successfully!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                            txtClear();

                            DBCon.CloseConnection(); // Calling the method to close the DB connection

                            dgvGenres.DataSource = DBCon.ShowDataInGridView("SELECT genre_id AS 'ID', genre_name AS 'Name' FROM tbl_genre");
                        }
                        else
                        {
                            string message = "This genre does not exist!";
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

                    NewGenID(); // Call genre ID function
                }
            }
        }

        // Genre add - KeyDown event
        private void txtGenName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenAdd.PerformClick();
            }
        }

        // Button manage actors
        private void btnManageActors_Click(object sender, EventArgs e)
        {
            frmManageActors frmManageActors = new frmManageActors();
            frmManageActors.Show();
            this.Hide();
        }

        // Load data to text fields using DataGridView
        private void dgvGenres_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtGenID.Text = dgvGenres.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtGenName.Text = dgvGenres.Rows[e.RowIndex].Cells[1].Value.ToString();
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

            }
        }

        // Genre delete - KeyDown event
        private void dgvGenres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnGenDelete.PerformClick();
            }
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

        private void frmManageGenres_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}