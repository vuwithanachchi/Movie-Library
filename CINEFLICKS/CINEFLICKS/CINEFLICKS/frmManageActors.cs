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
    public partial class frmManageActors : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.ManageActors objData = new clsProperties.ManageActors(); // Class object - Data

        string lastID = ""; // Varible for hold last ID
        string newID = ""; // Variable for hold new ID
        int tempID; // Temp variable for hold last two digits of the ID as a INT

        public frmManageActors()
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

            // Call actor ID function
            NewActID();

            // Disable manage user button
            if (objSession.GetName() != "admin")
            {
                btnManageUsr.Enabled = false;
            }
        }

        // Create new actor ID
        private void NewActID()
        {
            FetchLastActID();
            newID = lastID.Substring(lastID.Length - 3);
            tempID = Int32.Parse(newID) + 1;
            newID = "CIN-A" + tempID.ToString("D" + newID.Length);
            txtActID.Text = newID;
        }

        // Function - LoadDataGridView
        private void LoadDataGridView()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dgvActors.DataSource = DBCon.ShowDataInGridView("SELECT actor_id AS 'ID', actor_name AS 'Name' FROM tbl_actor");
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
            txtActID.Clear();
            txtActName.Clear();
        }

        // Clear User - click event
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtClear(); // Calling the function - Clear fields

            NewActID(); // Call actor ID function
        }

        // Fetch last actor ID
        private void FetchLastActID()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                string checkQry = "SELECT MAX(actor_id) FROM tbl_actor;";
                dr = DBCon.DataReader(checkQry);

                while (dr.Read())
                {
                    lastID = (dr["MAX(actor_id)"].ToString());
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
        private void btnActAdd_Click(object sender, EventArgs e)
        {
            objData.ActID = txtActID.Text;
            objData.ActName = txtActName.Text;

            // Confirm that fields are not empty
            if (objData.ActID.Length == 0 || objData.ActName.Length == 0)
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
                    string checkQry = "SELECT * FROM tbl_actor WHERE actor_name = '" + objData.ActName + "'";
                    dr = DBCon.DataReader(checkQry);

                    while (dr.Read())
                    {
                        dupCheck = (dr["actor_name"].ToString());
                    }

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    // Check duplicate entries
                    if (objData.ActName == dupCheck)
                    {
                        string message = "This actor is already in the system!";
                        string title = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection

                        string instQry = "INSERT INTO tbl_actor VALUES ('" + objData.ActID + "','" + objData.ActName + "')";
                        DBCon.ExecuteQueries(instQry);

                        string message = "Actor added successfully!";
                        string title = "Success";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                        txtClear();

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        dgvActors.DataSource = DBCon.ShowDataInGridView("SELECT actor_id AS 'ID', actor_name AS 'Name' FROM tbl_actor");
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

                NewActID(); // Call actor ID function
            }
        }

        // Button update - click event
        private void btnActUpdate_Click(object sender, EventArgs e)
        {
            objData.ActID = txtActID.Text;
            objData.ActName = txtActName.Text;

            // Confirm that fields are not empty
            if (objData.ActID.Length == 0 || objData.ActName.Length == 0)
            {
                string message = "Please select the actor, first!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection

                    string updQry = "UPDATE tbl_actor SET actor_name = '" + objData.ActName + "' WHERE actor_id = '" + objData.ActID + "'";
                    DBCon.ExecuteQueries(updQry);

                    string message = "Actor updated successfully!";
                    string title = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    txtClear();

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    dgvActors.DataSource = DBCon.ShowDataInGridView("SELECT actor_id AS 'ID', actor_name AS 'Name' FROM tbl_actor");
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

                NewActID(); // Call actor ID function
            }
        }

        // Button delete - click event
        private void btnActDelete_Click(object sender, EventArgs e)
        {
            objData.ActID = txtActID.Text;
            objData.ActName = txtActName.Text;

            // Confirm the selection
            if (objData.ActID.Length == 0 || objData.ActName.Length == 0)
            {
                string message = "Please select the actor, first!";
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
                        string checkQry = "SELECT * FROM tbl_actor WHERE actor_id = '" + objData.ActID + "'";
                        dr = DBCon.DataReader(checkQry);

                        while (dr.Read())
                        {
                            usrCheck = (dr["actor_id"].ToString());
                        }

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        // Check --> inserted actor is already there or not
                        if (objData.ActID == usrCheck)
                        {
                            DBCon.OpenConection(); // Calling the method to open the DB connection

                            string delQry = "DELETE FROM tbl_actor WHERE actor_id = '" + objData.ActID + "'";
                            DBCon.ExecuteQueries(delQry);

                            string message = "Actor deleted successfully!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                            txtClear();

                            DBCon.CloseConnection(); // Calling the method to close the DB connection

                            dgvActors.DataSource = DBCon.ShowDataInGridView("SELECT actor_id AS 'ID', actor_name AS 'Name' FROM tbl_actor");
                        }
                        else
                        {
                            string message = "This actor does not exist!";
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

                    NewActID(); // Call actor ID function
                }
            }
        }

        // Actor add KeyDown event
        private void txtActName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnActAdd.PerformClick();
            }
        }

        // Button - Manage Genre
        private void btnManageGenre_Click(object sender, EventArgs e)
        {
            frmManageGenres frmManageGenres = new frmManageGenres();
            frmManageGenres.Show();
            this.Hide();
        }

        // Load data to text fields using DataGridView
        private void dgvActors_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtActID.Text = dgvActors.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtActName.Text = dgvActors.Rows[e.RowIndex].Cells[1].Value.ToString();
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

        // Actor delete KeyDown event
        private void dgvActors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnActDelete.PerformClick();
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

        private void frmManageActors_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}