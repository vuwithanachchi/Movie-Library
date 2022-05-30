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
    public partial class frmManageMovies : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsSession objSession = new clsSession(); // Class object - clsSession.cs

        clsProperties.ManageMovies objData = new clsProperties.ManageMovies(); // Class object - Data

        string lastID = ""; // Varible for hold last ID
        string newID = ""; // Variable for hold new ID
        int tempID; // Temp variable for hold last two digits of the ID as a INT

        string[] genArray; // Genre array
        string[] actArray; // Actor array

        string genList = "";
        string actList = "";

        public frmManageMovies()
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

            // Call movie ID function
            NewMovID();

            // Disable manage user button
            if (objSession.GetName() != "admin")
            {
                btnManageUsr.Enabled = false;
            }

            rdMovie.Checked = true;
            rdTVShow.Checked = false;
            ddmCountry.Text = "--Please select--";
            ddmLanguage.Text = "--Please select--";
        }

        // Create new movie ID
        private void NewMovID()
        {
            FetchLastMovID();
            newID = lastID.Substring(lastID.Length - 3);
            tempID = Int32.Parse(newID) + 1;
            newID = "CIN-M" + tempID.ToString("D" + newID.Length);
            objData.MovID = newID;
        }

        // Fetch last movie ID
        private void FetchLastMovID()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                string checkQry = "SELECT MAX(mov_id) FROM tbl_movie;";
                dr = DBCon.DataReader(checkQry);

                while (dr.Read())
                {
                    lastID = (dr["MAX(mov_id)"].ToString());
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
                dgvMovies.DataSource = DBCon.ShowDataInGridView("SELECT mov_id AS 'ID', mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration' FROM tbl_movie");
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
            txtMovDirector.Clear();
            txtProdCompany.Clear();
            txtMovCast.Clear();
            txtMovDuration.Clear();
            txtMovBudget.Clear();
            txtMovPlot.Clear();
            movRating.Value = 0;
            rdMovie.Checked = true;
            rdTVShow.Checked = false;
            ddmCountry.Text = "--Please select--";
            ddmLanguage.Text = "--Please select--";
            txtMovCover.Clear();
            dtpReleaseDate.ResetText();

            objData.MovID = string.Empty;
            objData.MovName = string.Empty;
            objData.MovType = string.Empty;
            objData.MovCover = string.Empty;
            objData.MovDirector = string.Empty;
            objData.MovPCompany = string.Empty;
            objData.MovInRelease = string.Empty;
            objData.MovDuration = string.Empty;
            objData.MovCountry = string.Empty;
            objData.MovLanguage = string.Empty;
            objData.MovBudget = string.Empty;
            objData.MovPlot = string.Empty;
            objData.SetGenList(string.Empty);
            objData.SetActList(string.Empty);

            objData.MovRating = 0;
        }

        // Clear User - click event
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtClear(); // Calling the function - Clear fields

            NewMovID(); // Call movie ID function
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

        // Get data from user and pass them to data class
        private void GetDataFromUsr()
        {
            objData.MovName = txtMovName.Text;

            if (rdMovie.Checked)
            {
                objData.MovType = "Movie";
            }
            else if (rdTVShow.Checked)
            {
                objData.MovType = "TV-Show";
            }
            
            objData.MovCover = txtMovCover.Text;
            objData.MovRating = movRating.Value;
            objData.MovDirector = txtMovDirector.Text;
            objData.MovPCompany = txtProdCompany.Text;
            objData.MovInRelease = dtpReleaseDate.Text;
            objData.MovDuration = txtMovDuration.Text;
            objData.MovCountry = ddmCountry.Text;
            objData.MovLanguage = ddmLanguage.Text;
            objData.MovBudget = txtMovBudget.Text;
            objData.MovPlot = txtMovPlot.Text;

            StringGenToArray();
            StringActToArray();
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

        // Button - Add movie
        private void btnMovAdd_Click(object sender, EventArgs e)
        {
            GetDataFromUsr();

            // Confirm that fields are not empty
            if (objData.MovName.Length == 0 || objData.MovType.Length == 0 || txtMovGenre.Text == "" || objData.MovCover.Length == 0 || objData.MovDirector.Length == 0 || objData.MovPCompany.Length == 0 || txtMovCast.Text == "" || objData.MovCountry == "--Please select--" || objData.MovLanguage == "--Please select--")
            {
                string message = "Required fields cannot be empty!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    frmLoading frmLoading = new frmLoading();
                    frmLoading.ShowDialog();

                    DBCon.OpenConection(); // Calling the method to open the DB connection

                    string instQry = "INSERT INTO tbl_movie VALUES ('" + objData.MovID + "','" + objData.MovName + "','" + objData.MovType + "','" + objData.MovCover + "','" + objData.MovRating + "','" + objData.MovDirector + "','" + objData.MovPCompany + "','" + objData.MovInRelease + "','" + objData.MovDuration + "','" + objData.MovCountry + "','" + objData.MovLanguage + "','" + objData.MovBudget + "','" + objData.MovPlot + "')";
                    DBCon.ExecuteQueries(instQry);

                        
                    // Store genres
                    foreach(string i in genArray)
                    {
                        string instQry1 = "INSERT INTO tbl_movie_genre VALUES ('" + objData.MovID + "','" + i + "')";
                        DBCon.ExecuteQueries(instQry1);
                    }

                    // Store actors
                    foreach (string i in actArray)
                    {
                        string instQry2 = "INSERT INTO tbl_movie_actor VALUES ('" + objData.MovID + "','" + i + "')";
                        DBCon.ExecuteQueries(instQry2);
                    }


                    string message = "Movie added successfully!";
                    string title = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    txtClear();

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    dgvMovies.DataSource = DBCon.ShowDataInGridView("SELECT mov_id AS 'ID', mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration' FROM tbl_movie");
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

                NewMovID(); // Call movie ID function
            }
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

        // Load data to text fields using DataGridView
        private void dgvMovies_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            genList = string.Empty;
            actList = string.Empty;
            lblClear_Click(sender, e);

            try
            {
                if (e.RowIndex >= 0)
                {
                    objData.MovID = dgvMovies.Rows[e.RowIndex].Cells[0].Value.ToString();


                    DBCon.OpenConection(); // Calling the method to open the DB connection
                    string checkQry = "SELECT * FROM tbl_movie WHERE mov_id = '" + objData.MovID + "'";
                    dr = DBCon.DataReader(checkQry);

                    while (dr.Read())
                    {
                        txtMovName.Text = (dr["mov_name"].ToString());
                        string mType = (dr["mov_type"].ToString());

                        if (mType == "Movie")
                        {
                            rdMovie.Checked = true;
                            rdTVShow.Checked = false;
                        }
                        else
                        {
                            rdMovie.Checked = false;
                            rdTVShow.Checked = true;
                        }

                        txtMovCover.Text = (dr["mov_cover_img"].ToString());
                        movRating.Value = ((int)dr["mov_rating"]);
                        txtMovDirector.Text = (dr["mov_director"].ToString());
                        txtProdCompany.Text = (dr["mov_prod_company"].ToString());
                        dtpReleaseDate.Text = (dr["mov_release_date"].ToString());
                        txtMovDuration.Text = (dr["mov_duration"].ToString());
                        ddmCountry.Text = (dr["mov_country"].ToString());
                        ddmLanguage.Text = (dr["mov_language"].ToString());
                        txtMovBudget.Text = (dr["mov_budget"].ToString());
                        txtMovPlot.Text = (dr["mov_plot"].ToString());
                    }

                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    /*----------------------------------------------------------------------------------------------------------------------------*/

                    MySqlConnection conn;
                    string connString;

                    connString = "Server=cineflicksdb.mysql.database.azure.com; Port=3306; Database=cineflicksdb; Uid=bimbiave_cineUsr@cineflicksdb; Pwd=z2puCEfU7AGnFwcf; SslMode=Preferred;";
                    conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open(); // Open the DB connection

                    string query1 = "SELECT genre_name FROM tbl_movie_genre WHERE mov_id = '" + objData.MovID + "'";

                    MySqlDataAdapter dr1 = new MySqlDataAdapter(query1, conn);
                    DataSet ds = new DataSet();
                    dr1.Fill(ds);

                    // Genre array
                    genArray = new string[ds.Tables[0].Rows.Count];

                    //loopcounter
                    for (int loopcounter = 0; loopcounter < ds.Tables[0].Rows.Count; loopcounter++)
                    {
                        //assign dataset values to array
                        genArray[loopcounter] = ds.Tables[0].Rows[loopcounter]["genre_name"].ToString();
                    }

                    conn.Close(); // Close the DB connection

                    // Transfer array values into the string variable with a pipe
                    for (int k = 0; k < genArray.Length; k++)
                    {
                        genList = genList + genArray[k] + " | ";
                    }

                    // Remove last 3 characters from the list
                    genList = genList.Remove(genList.Length - 3);

                    // Send values to txtMovGenre text field
                    txtMovGenre.Text = genList;



                    conn.Open(); // Open the DB connection

                    string query2 = "SELECT actor_name FROM tbl_movie_actor WHERE mov_id = '" + objData.MovID + "'";

                    MySqlDataAdapter dr2 = new MySqlDataAdapter(query2, conn);
                    DataSet ds2 = new DataSet();
                    dr2.Fill(ds2);

                    // Actor array
                    actArray = new string[ds2.Tables[0].Rows.Count];

                    //loopcounter
                    for (int loopcounter = 0; loopcounter < ds2.Tables[0].Rows.Count; loopcounter++)
                    {
                        //assign dataset values to array
                        actArray[loopcounter] = ds2.Tables[0].Rows[loopcounter]["actor_name"].ToString();
                    }

                    conn.Close(); // Close the DB connection

                    // Transfer array values into the string variable with a pipe
                    for (int k = 0; k < actArray.Length; k++)
                    {
                        actList = actList + actArray[k] + " | ";
                    }

                    // Remove last 3 characters from the list
                    actList = actList.Remove(actList.Length - 3);

                    // Send values to txtMovGenre text field
                    txtMovCast.Text = actList;

                }
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

            }
        }

        // Button delete - click event
        private void btnMovDelete_Click(object sender, EventArgs e)
        {
            // Confirm the selection
            if (objData.MovID.Length == 0 || txtMovName.Text == "")
            {
                string message = "Please select the movie, first!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string movCheck = ""; // Varible for check existing records

                    try
                    {
                        DBCon.OpenConection(); // Calling the method to open the DB connection
                        string checkQry = "SELECT * FROM tbl_movie WHERE mov_id = '" + objData.MovID + "'";
                        dr = DBCon.DataReader(checkQry);

                        while (dr.Read())
                        {
                            checkQry = (dr["mov_id"].ToString());
                        }

                        DBCon.CloseConnection(); // Calling the method to close the DB connection

                        // Check --> inserted movie is already there or not
                        if (objData.MovID == checkQry)
                        {
                            DBCon.OpenConection(); // Calling the method to open the DB connection

                            string delQry = "DELETE FROM tbl_movie WHERE mov_id = '" + objData.MovID + "';";
                            delQry += "DELETE FROM tbl_movie_genre WHERE mov_id = '" + objData.MovID + "';";
                            delQry += "DELETE FROM tbl_movie_actor WHERE mov_id = '" + objData.MovID + "';";
                            DBCon.ExecuteQueries(delQry);

                            string message = "Move deleted successfully!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                            txtClear();

                            DBCon.CloseConnection(); // Calling the method to close the DB connection

                            dgvMovies.DataSource = DBCon.ShowDataInGridView("SELECT mov_id AS 'ID', mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration' FROM tbl_movie");
                        }
                        else
                        {
                            string message = "This movie does not exist!";
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

                    NewMovID(); // Call movie ID function
                }
            }
        }

        // Movie delete KeyDown event
        private void dgvMovies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnMovDelete.PerformClick();
            }
        }

        // Button update - click event
        private void btnMovUpdate_Click(object sender, EventArgs e)
        {
            GetDataFromUsr();

            // Confirm that fields are not empty
            if (objData.MovID.Length == 0 || objData.MovName.Length == 0 || objData.MovType.Length == 0 || txtMovGenre.Text == "" || objData.MovCover.Length == 0 || objData.MovDirector.Length == 0 || objData.MovPCompany.Length == 0 || txtMovCast.Text == "" || objData.MovCountry == "--Please select--" || objData.MovLanguage == "--Please select--")
            {
                string message = "Required fields cannot be empty!";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    frmLoading frmLoading = new frmLoading();
                    frmLoading.ShowDialog();

                    DBCon.OpenConection(); // Calling the method to open the DB connection

                    string updQry = "UPDATE tbl_movie SET mov_name = '" + objData.MovName + "', mov_type = '" + objData.MovType + "', mov_cover_img = '" + objData.MovCover + "', mov_rating = '" + objData.MovRating + "', mov_director = '" + objData.MovDirector + "', mov_prod_company = '" + objData.MovPCompany + "', mov_release_date = '" + objData.MovInRelease + "', mov_duration = '" + objData.MovDuration + "', mov_country = '" + objData.MovCountry + "', mov_language = '" + objData.MovLanguage + "', mov_budget = '" + objData.MovBudget + "', mov_plot = '" + objData.MovPlot + "' WHERE mov_id = '" + objData.MovID + "'";
                    DBCon.ExecuteQueries(updQry);

                    /*---------------------------------------------------------------*/

                    // Delete the existing values
                    string delQry = "DELETE FROM tbl_movie_genre WHERE mov_id = '" + objData.MovID + "';";
                    delQry += "DELETE FROM tbl_movie_actor WHERE mov_id = '" + objData.MovID + "';";
                    DBCon.ExecuteQueries(delQry);

                    // Store genres
                    foreach (string i in genArray)
                    {
                        string instQry1 = "INSERT INTO tbl_movie_genre VALUES ('" + objData.MovID + "','" + i + "')";
                        DBCon.ExecuteQueries(instQry1);
                    }

                    // Store actors
                    foreach (string i in actArray)
                    {
                        string instQry2 = "INSERT INTO tbl_movie_actor VALUES ('" + objData.MovID + "','" + i + "')";
                        DBCon.ExecuteQueries(instQry2);
                    }


                    DBCon.CloseConnection(); // Calling the method to close the DB connection

                    string message = "Movie updated successfully!";
                    string title = "Success";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    txtClear();


                    dgvMovies.DataSource = DBCon.ShowDataInGridView("SELECT mov_id AS 'ID', mov_name AS 'Name', mov_type AS 'Type', mov_rating AS 'Rating', mov_prod_company AS 'Prod. Company', mov_release_date AS 'Release Date', mov_duration AS 'Duration' FROM tbl_movie");
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

                NewMovID(); // Call actor ID function
            }
        }

        // Button - Search Movies
        private void btnSearchMov_Click(object sender, EventArgs e)
        {
            frmSearchMovies frmSearchMovies = new frmSearchMovies();
            frmSearchMovies.Show();
            this.Hide();
        }

        private void frmManageMovies_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}