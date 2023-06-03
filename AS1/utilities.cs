using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AS1
{
    public static class utilities
    {

        public static class AS1
        {
            public static void show(DataGrid grid)
            {
                string query = "Select * from Products";
                DataTable dt;
                dt = utilities.sql.Get(query);
                dt.Columns[0].ColumnName = "Id";
                dt.Columns[1].ColumnName = "Name";
                dt.Columns[2].ColumnName = "Amount";
                dt.Columns[3].ColumnName = "Price";
                grid.ItemsSource = dt.DefaultView;
            }

            public static void copyToTextBox(Object ob, DataRowView selected_row)
            {
                Admin objAdmin = new Admin();
                Sales objSales=new Sales();
                dynamic obj=null;
                if (objAdmin.GetType() == ob.GetType())
                {
                    obj = (Admin)ob;
                }
                else if (objSales.GetType() == ob.GetType())
                {
                    obj = (Sales)ob;
                }

                if (selected_row != null)
                {
                    obj.ProductId.Text = selected_row[0].ToString();
                    obj.producName.Text = selected_row[1].ToString();
                    obj.Amount.Text = selected_row[2].ToString();
                    obj.Price.Text = selected_row[3].ToString();
                }

            }
        }
        public static class tools
        {
            public static Boolean numberValidation(TextCompositionEventArgs e)
            {

                e.Handled = new Regex("[^0-9.]+").IsMatch(e.Text);
                return e.Handled;
            }

        }
        public static  class sql
        {
            private static string getConnnectionString()
            {

                string connectionString = "Server=localhost;Database=FarmersMarket;Trusted_Connection=True; encrypt=false;";
                return connectionString;
            }
            private static SqlConnection con;
            private static SqlCommand cmd;

            private static  void establishConnection()
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

            //Threading for handling database operations
            public static async 
            //Threading for handling database operations
            Task
            Set(string query)
            {
                try
                {
                    establishConnection();
                    if (con.State != ConnectionState.Open)
                    {
                        await con.OpenAsync();
                    }
                    using (cmd = new SqlCommand(query, con))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
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
