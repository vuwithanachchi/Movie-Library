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
    public partial class frmLogin : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession clsSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.Login objData = new clsProperties.Login(); // Class object - Data

        clsPassEncryDecry objPassEnDe = new clsPassEncryDecry(); // Class object - clsPassEncryDecry.cs

        int passShow = 0; // Variable to hold the value of the show & hide password class

        string tempPass = "";

        public frmLogin()
        {
            InitializeComponent();

            // Execute in one second after loading the form - this will make the first connection with the DB
            var tmr = new Timer();
            tmr.Interval = 1000; // 1 second
            tmr.Tick += (s, u) =>
            {
                try
                {
                    DBCon.OpenConection();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    DBCon.CloseConnection(); // Calling the method to close the DB connection
                }

                tmr.Stop();
            };
            tmr.Start();
        }

        // Log In button click event
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            objData.UsrName = txtUName.Text;
            objData.UsrPass = txtUPass.Text;

            // Confirm that the username and password are not empty
            if (objData.UsrName.Length == 0 || objData.UsrPass.Length == 0)
            {
                lblError.Text = "Username and password are required!";
            }
            else
            {
                lblError.ResetText(); // Clear the error label after filling both textboxes

                // Exception handling - MySQL
                try
                {
                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    dr = DBCon.DataReader("SELECT * FROM tbl_user WHERE user_name='" + objData.UsrName + "'");

                    if (dr.Read())
                    {
                        tempPass = (dr["user_pass"].ToString());
                    }

                    passEncryDecry(); // Decrypt password

                    if (tempPass == objData.UsrPass)
                    {
                        clsSession.SetName(objData.UsrName); // Start the session by sending the username to session class - clsSession.cs

                        frmDashboard frmDashboard = new frmDashboard();
                        frmDashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password. Please try again.", "Log In Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Form load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblError.ResetText(); // Clear the error label before loading the form
        }

        // Username textbox - KeyDown Event
        private void txtUName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
            }
        }

        // Password textbox - KeyDown Event
        private void txtUPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
            }
        }

        // Log In as Guest - click event
        private void txtLogGuest_Click(object sender, EventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        // Show & hide password by clicking on the icon
        private void txtUPass_OnIconRightClick(object sender, EventArgs e)
        {
            if (passShow == 0)
            {
                txtUPass.PasswordChar = '\0';
                txtUPass.UseSystemPasswordChar = false;
                passShow++;
            }
            else
            {
                txtUPass.PasswordChar = '*';
                txtUPass.UseSystemPasswordChar = true;
                passShow--;
            }
        }

        // Decrypt password
        private void passEncryDecry()
        {
            tempPass = objPassEnDe.PassDecrypt(tempPass);
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}