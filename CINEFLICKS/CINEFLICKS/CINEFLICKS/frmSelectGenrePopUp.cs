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
    public partial class frmSelectGenrePopUp : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        frmManageMovies objFrmMM = new frmManageMovies(); // Class object - Form manage movies

        clsProperties.ManageMovies objData = new clsProperties.ManageMovies(); // Class object - Data

        int arrLen = 0; // To hold array length
        string gen = ""; // To hold a single genre
        int j = 0; // Genre array index
        string genreList = ""; // To hold genres

        public frmSelectGenrePopUp()
        {
            InitializeComponent();
        }

        // Form Load
        private void frmSelectGenrePopUp_Load(object sender, EventArgs e)
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
                dgvSelectGenre.DataSource = DBCon.ShowDataInGridView("SELECT genre_name AS 'Name' FROM tbl_genre");
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
        private void btnGenreCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button - Add
        private void btnGenreAdd_Click(object sender, EventArgs e)
        {
            genreList = string.Empty;
            arrLen = 0;
            j = 0;

            try
            {
                // Run and count the number of selected rows
                for (int i = 0; i < dgvSelectGenre.Rows.Count; i++)
                {
                    bool isCellChecked = Convert.ToBoolean(dgvSelectGenre.Rows[i].Cells[0].Value);
                    if (isCellChecked == true)
                    {
                        arrLen += 1;
                    }
                }

                // Selections validation
                if (arrLen != 0)
                {
                    string[] genArr = new string[arrLen]; // Genre array

                    // Run and fetch the selected rows and add the values into the array
                    for (int i = 0; i < dgvSelectGenre.Rows.Count; i++)
                    {
                        bool isCellChecked = Convert.ToBoolean(dgvSelectGenre.Rows[i].Cells[0].Value);
                        if (isCellChecked == true)
                        {
                            gen = (string)dgvSelectGenre.Rows[i].Cells[1].Value;
                            genArr[j] = gen;
                            j += 1;
                        }
                    }

                    // Transfer array values into the string variable with a pipe
                    for (int k = 0; k < arrLen; k++)
                    {
                        genreList = genreList + genArr[k] + " | ";
                    }

                    genreList = genreList.Remove(genreList.Length - 3); // Remove last 3 characters from the list

                    //MessageBox.Show(genreList);
                    objData.SetGenList(genreList); // Pass genres to the data variable

                    // Call the LoadGenreToField function which is located at the frmManagaMovies
                    var mainForm = Application.OpenForms.OfType<frmManageMovies>().Last();
                    mainForm.LoadGenreToField();

                    this.Close();
                }
                else
                {
                    string message = "Genre cannot be empty! Select at least one item.";
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
    }
}