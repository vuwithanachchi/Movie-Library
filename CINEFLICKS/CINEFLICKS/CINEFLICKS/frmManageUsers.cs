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
    public partial class frmManageUsers : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.ManageUsr objData = new clsProperties.ManageUsr(); // Class object - Data

        clsPassEncryDecry objPassEnDe = new clsPassEncryDecry(); // Class object - clsPassEncryDecry.cs

        int passShow = 0; // Variable to hold the value of the show & hide password class

        public frmManageUsers()
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
        }

        // Function - LoadDataGridView
        private void LoadDataGridView()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dgvUsers.DataSource = DBCon.ShowDataInGridView("SELECT user_name AS 'Username', user_pass AS 'Password', display_name AS 'Display Name' FROM tbl_user");
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
            if(DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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

        // Show & hide password by clicking on the icon
        private void txtUsrPass_OnIconRightClick(object sender, EventArgs e)
        {
            if (passShow == 0)
            {
                txtUsrPass.PasswordChar = '\0';
                txtUsrPass.UseSystemPasswordChar = false;
                passShow++;
            }
            else
            {
                txtUsrPass.PasswordChar = '*';
                txtUsrPass.UseSystemPasswordChar = true;
                passShow--;
            }
        }

        // Button Search - click event
        private void btnUsrSearch_Click(object sender, EventArgs e)
        {
            txtUsrPass.Clear();
            txtDisName.Clear();

            objData.UsrName = txtUsrName.Text;

            // Confirm that the username field is not empty
            if (objData.UsrName.Length == 0)
            {
                string message = "Please enter the username, first!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    dr = DBCon.DataReader("SELECT * FROM tbl_user WHERE user_name = '" + objData.UsrName + "'");

                    if (dr.Read())
                    {
                        txtUsrName.Text = (dr["user_name"].ToString());
                        txtUsrPass.Text = (dr["user_pass"].ToString());
                        txtDisName.Text = (dr["display_name"].ToString());
                    }
                    else
                    {
                        string message = "User ID does not exist";
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

        // Function - Clear fields
        private void txtClear()
        {
            txtUsrName.Clear();
            txtUsrPass.Clear();
            txtDisName.Clear();
        }

        // Clear User - click event
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtClear(); // Calling the function - Clear fields
        }

        // Username textbox - KeyDown Event
        private void txtUsrName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUsrSearch.PerformClick();
            }
        }

        // Button add - click event
        private void btnUsrAdd_Click(object sender, EventArgs e)
        {
            objData.UsrName = txtUsrName.Text;
            objData.UsrPass = txtUsrPass.Text;
            objData.DisName = txtDisName.Text;

            // Confirm that fields are not empty
            if (objData.UsrName.Length == 0 || objData.UsrPass.Length == 0 || objData.DisName.Length == 0)
            {
                string message = "Fields cannot be empty!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else if (objData.UsrPass.Length < 6)
            {
                string message = "Your password must be at least 6 characters long";
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
                    string checkQry = "SELECT * FROM tbl_user WHERE user_name = '" + objData.UsrName + "'";
                    dr = DBCon.DataReader(checkQry);

                    while (dr.Read())
                    {
                        dupCheck = (dr["user_name"].ToString());
                    }

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    // Check duplicate entries
                    if (objData.UsrName == dupCheck)
                    {
                        string message = "The user is already in the system!";
                        string title = "Warning";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection

                        passEncryDecry();

                        string instQry = "INSERT INTO tbl_user (user_name, user_pass, display_name) VALUES ('" + objData.UsrName + "','" + objData.UsrPass + "','" + objData.DisName + "')";
                        DBCon.ExecuteQueries(instQry);

                        string message = "User added successfully!";
                        string title = "Success";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                        txtClear();

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        dgvUsers.DataSource = DBCon.ShowDataInGridView("SELECT user_name AS 'Username', user_pass AS 'Password', display_name AS 'Display Name' FROM tbl_user");
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

        // Add User - KeyDown Event
        private void txtDisName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUsrAdd.PerformClick();
            }
        }

        // Button update - click event
        private void btnUsrUpdate_Click(object sender, EventArgs e)
        {
            objData.UsrName = txtUsrName.Text;
            objData.UsrPass = txtUsrPass.Text;
            objData.DisName = txtDisName.Text;

            // Confirm that fields are not empty
            if (objData.UsrName.Length == 0 || objData.UsrPass.Length == 0 || objData.DisName.Length == 0)
            {
                string message = "Fields cannot be empty!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else if (objData.UsrPass.Length < 6)
            {
                string message = "Your password must be at least 6 characters long";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                string usrCheck = ""; // Varible for check duplicate entries

                try
                {
                    passEncryDecry();

                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    string checkQry = "SELECT * FROM tbl_user WHERE user_name = '" + objData.UsrName + "'";
                    dr = DBCon.DataReader(checkQry);

                    while (dr.Read())
                    {
                        usrCheck = (dr["user_name"].ToString());
                    }

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    // Check --> inserted user is already in the system or not
                    if (objData.UsrName == usrCheck)
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection

                        string updQry = "UPDATE tbl_user SET user_name = '" + objData.UsrName + "', user_pass = '" + objData.UsrPass + "', display_name = '" + objData.DisName + "' WHERE user_name = '" + objData.UsrName + "'";
                        DBCon.ExecuteQueries(updQry);

                        string message = "User updated successfully!";
                        string title = "Success";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                        txtClear();

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        dgvUsers.DataSource = DBCon.ShowDataInGridView("SELECT user_name AS 'Username', user_pass AS 'Password', display_name AS 'Display Name' FROM tbl_user");
                    }
                    else
                    {
                        string message = "Sorry, the username cannot be changed. Instead, you can delete the existing user and create a new one.";
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

        // Button delete - click event
        private void btnUsrDelete_Click(object sender, EventArgs e)
        {
            objData.UsrName = txtUsrName.Text;
            objData.UsrPass = txtUsrPass.Text;
            objData.DisName = txtDisName.Text;

            // Confirm that fields are not empty
            if (objData.UsrName.Length == 0 || objData.UsrPass.Length == 0 || objData.DisName.Length == 0)
            {
                string message = "Please seach the user, first!";
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
                        string checkQry = "SELECT * FROM tbl_user WHERE user_name = '" + objData.UsrName + "'";
                        dr = DBCon.DataReader(checkQry);

                        while (dr.Read())
                        {
                            usrCheck = (dr["user_name"].ToString());
                        }

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        // Check --> inserted user is already there or not
                        if (objData.UsrName == usrCheck)
                        {
                            DBCon.OpenConection(); // Calling the method to open the DB connection

                            string delQry = "DELETE FROM tbl_user WHERE user_name = '" + objData.UsrName + "'";
                            DBCon.ExecuteQueries(delQry);

                            string message = "User deleted successfully!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                            txtClear();

                            DBCon.CloseConnection(); // Calling the method to close the DB connection

                            dgvUsers.DataSource = DBCon.ShowDataInGridView("SELECT user_name AS 'Username', user_pass AS 'Password', display_name AS 'Display Name' FROM tbl_user");
                        }
                        else
                        {
                            string message = "The user does not exist!";
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
        }

        // Load data to text fields using DataGridView
        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    txtUsrName.Text = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string enPass = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtUsrPass.Text = objPassEnDe.PassDecrypt(enPass); // Show password by decrypting in realtime
                    txtDisName.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
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

        // Button manage genre
        private void btnManageGenre_Click(object sender, EventArgs e)
        {
            frmManageGenres frmManageGenres = new frmManageGenres();
            frmManageGenres.Show();
            this.Hide();
        }

        // Button manage actors
        private void btnManageActors_Click(object sender, EventArgs e)
        {
            frmManageActors frmManageActors = new frmManageActors();
            frmManageActors.Show();
            this.Hide();
        }

        // User delete - KeyDown event
        private void dgvUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnUsrDelete.PerformClick();
            }
        }

        // Encrypt password
        private void passEncryDecry()
        {
            objData.UsrPass = objPassEnDe.PassEncrypt(objData.UsrPass);
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

        private void frmManageUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}