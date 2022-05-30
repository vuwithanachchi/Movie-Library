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
    public partial class frmSelectActorPopUp : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        frmManageMovies objFrmMM = new frmManageMovies(); // Class object - Form manage movies

        clsProperties.ManageMovies objData = new clsProperties.ManageMovies(); // Class object - Data

        int arrLen = 0; // To hold array length
        string gen = ""; // To hold a single genre
        int j = 0; // Genre array index
        string actList = ""; // To hold genres

        public frmSelectActorPopUp()
        {
            InitializeComponent();
        }

        // Form Load
        private void frmSelectActorPopUp_Load(object sender, EventArgs e)
        {
            // Fetch data and load to DataGridView at the beginning
            LoadDataGridView();
        }

        // Function - LoadDataGridView
        private void LoadDataGridView()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dgvSelectActor.DataSource = DBCon.ShowDataInGridView("SELECT actor_name AS 'Name' FROM tbl_actor");
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

        // Button - Cancel
        private void btnActCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button - Add
        private void btnActAdd_Click(object sender, EventArgs e)
        {
            actList = string.Empty;
            arrLen = 0;
            j = 0;

            try
            {
                // Run and count the number of selected rows
                for (int i = 0; i < dgvSelectActor.Rows.Count; i++)
                {
                    bool isCellChecked = Convert.ToBoolean(dgvSelectActor.Rows[i].Cells[0].Value);
                    if (isCellChecked == true)
                    {
                        arrLen += 1;
                    }
                }

                // Selections validation
                if (arrLen != 0)
                {
                    string[] actArr = new string[arrLen]; // Genre array

                    // Run and fetch the selected rows and add the values into the array
                    for (int i = 0; i < dgvSelectActor.Rows.Count; i++)
                    {
                        bool isCellChecked = Convert.ToBoolean(dgvSelectActor.Rows[i].Cells[0].Value);
                        if (isCellChecked == true)
                        {
                            gen = (string)dgvSelectActor.Rows[i].Cells[1].Value;
                            actArr[j] = gen;
                            j += 1;
                        }
                    }

                    // Transfer array values into the string variable with a pipe
                    for (int k = 0; k < arrLen; k++)
                    {
                        actList = actList + actArr[k] + " | ";
                    }

                    actList = actList.Remove(actList.Length - 3); // Remove last 3 characters from the list

                    //MessageBox.Show(actList);
                    objData.SetActList(actList); // Pass genres to the data variable

                    // Call the LoadActToField function which is located at the frmManagaMovies
                    var mainForm = Application.OpenForms.OfType<frmManageMovies>().Last();
                    mainForm.LoadActToField();

                    this.Close();
                }
                else
                {
                    string message = "Cast cannot be empty! Select at least one item.";
                    string title = "Warning";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }

        }

        // Live search event
        private void txtActSearch_TextChange(object sender, EventArgs e)
        {
            (dgvSelectActor.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("Name LIKE '%{0}%'", txtActSearch.Text);
        }
    }
}