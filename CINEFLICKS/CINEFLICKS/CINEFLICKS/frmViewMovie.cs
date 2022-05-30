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
    public partial class frmViewMovie : Form
    {
        clsDBCon DBCon = new clsDBCon(); // Class object - clsDBcon.cs
        MySqlDataReader dr; // MySqlDataReader object

        clsProperties.ManageMovies objData = new clsProperties.ManageMovies(); // Class object - Data

        string coverImg;
        string genList, actList;

        public frmViewMovie()
        {
            InitializeComponent();

            FetchAndLoadData();
        }

        private void frmViewMovie_Load(object sender, EventArgs e)
        {
            // Execute in 0.1 second after loading the form
            var tmr = new Timer();
            tmr.Interval = 100; // 0.1 second
            tmr.Tick += (s, u) =>
            {
                imgMovCover.Load(coverImg);
                //imgMovCover.ImageLocation = coverImg;

                tmr.Stop();
            };
            tmr.Start();
        }

        // Button - Close
        private void btnVMovClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Access data which are in the property class and pass them into the lables
        public void FetchAndLoadData()
        {
            try
            {
                DBCon.OpenConection(); // Calling the method to open the DB connection
                dr = DBCon.DataReader("SELECT * FROM tbl_movie WHERE mov_id = '" + objData.MovID + "'");

                if (dr.Read())
                {
                    // Movie name
                    lblMovName.Text = (dr["mov_name"].ToString());

                    // Release year
                    string tempDate = (dr["mov_release_date"].ToString());
                    tempDate = tempDate.Remove(tempDate.Length - 12);
                    tempDate = tempDate.Substring(tempDate.Length - 4);
                    lblMovReleaseYear.Text = tempDate;

                    // Movie type
                    lblMovType.Text = (dr["mov_type"].ToString());

                    // Rating
                    ratingMov.Value = ((int)dr["mov_rating"]);

                    // Director
                    lblMovDirector.Text = (dr["mov_director"].ToString());

                    // Production company
                    lblMovPCompany.Text = (dr["mov_prod_company"].ToString());

                    // Release Date
                    tempDate = (dr["mov_release_date"].ToString());
                    tempDate = tempDate.Remove(tempDate.Length - 12);
                    lblMovInRelease.Text = tempDate;

                    // Duration
                    lblMovDuration.Text = (dr["mov_duration"].ToString());

                    // Country
                    lblMovCountry.Text = (dr["mov_country"].ToString());

                    // Language
                    lblMovLnaguage.Text = (dr["mov_language"].ToString());

                    // Budget
                    lblMovBudget.Text = (dr["mov_budget"].ToString());

                    // Plot
                    lblMovPlot.Text = (dr["mov_plot"].ToString());

                    // Cover image
                    coverImg = (dr["mov_cover_img"].ToString());
                }
                else
                {
                    string message = "The movie does not exist";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                }

                DBCon.CloseConnection(); // Calling the method to close the DB connection

                /*-----------------------------------------------------------------------------------------------------*/

                DBCon.OpenConection(); // Calling the method to open the DB connection

                dtvTempAct.DataSource = DBCon.ShowDataInGridView("SELECT * FROM tbl_movie_actor WHERE mov_id = '" + objData.MovID + "'");
                dtvTempGen.DataSource = DBCon.ShowDataInGridView("SELECT * FROM tbl_movie_genre WHERE mov_id = '" + objData.MovID + "'");

                DBCon.CloseConnection(); // Calling the method to close the DB connection

                // Fetch genres
                for (int row = 0; row < dtvTempGen.Rows.Count; row++)
                {
                    genList += dtvTempGen.Rows[row].Cells[1].Value.ToString() + " , ";
                }
                genList = genList.Remove(genList.Length - 3); // Remove last 3 characters from the string

                // Fetch actors
                for (int row = 0; row < dtvTempAct.Rows.Count; row++)
                {
                    actList += dtvTempAct.Rows[row].Cells[1].Value.ToString() + " , ";
                }
                actList = actList.Remove(actList.Length - 3); // Remove last 3 characters from the string

                lblMovGenre.Text = genList;
                lblMovCast.Text = actList;
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
    }
}