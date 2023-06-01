using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AS1
{
    public static class utilities
    {
        public static class sql
        {
            private static string getConnnectionString()
            {

                string connectionString = "Server=localhost;Database=FarmersMarket;Trusted_Connection=True; encrypt=false;";
                return connectionString;
            }
            private static SqlConnection con;
            private static SqlCommand cmd;

            private static void establishConnection()
            {
                try
                {
                    con = new SqlConnection(getConnnectionString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            public static void Set(string query)
            {
                try
                {
                    establishConnection();
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Executed Successfully");
                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public static DataTable Get(string query)
            {
                DataTable dt = new DataTable();
                try
                {
                    establishConnection();
                    con.Open();
                    cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dt);
                    con.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return dt;
            }
        }
    }

}
