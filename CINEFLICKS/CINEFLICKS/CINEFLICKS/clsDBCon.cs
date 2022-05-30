using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CINEFLICKS
{
    public class clsDBCon
    {
        // Varriable string for saving the connection string and MySqlConnection object
        MySqlConnection conn;
        string connString;

        // Method to open the connection
        public void OpenConection()
        {
            connString = "Server=cineflicksdb.mysql.database.azure.com; Port=3306; Database=cineflicksdb; Uid=bimbiave_cineUsr@cineflicksdb; Pwd=z2puCEfU7AGnFwcf; SslMode=Preferred;";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }

        // Method to close the connection
        public void CloseConnection()
        {
            conn.Close();
        }

        // Method to execute quries
        public void ExecuteQueries(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, conn);
            cmd.ExecuteNonQuery();
        }

        public int ExecuteScalar(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, conn);
            Int32 value = Convert.ToInt32(cmd.ExecuteScalar());
            return value;
        }

        // Method for MySqlDataReader
        public MySqlDataReader DataReader(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        // DataInGridView
        public object ShowDataInGridView(string Query_)
        {
            MySqlDataAdapter dr = new MySqlDataAdapter(Query_, conn);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
    }
}