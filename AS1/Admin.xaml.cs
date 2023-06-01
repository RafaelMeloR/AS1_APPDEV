using AS1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AS1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        static Boolean delete=false;
        public Admin()
        {
            InitializeComponent();
            show();
        }

        public void show()
        {
            string query = "Select * from Products";
            DataTable dt;
            dt= utilities.sql.Get(query);
            grid.ItemsSource = dt.DefaultView;
        }

        private void createBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO [dbo].[Products] VALUES ('"+producName.Text+"','"+Amount.Text+"','"+Price.Text+"')";
            utilities.sql.Set(query);
            show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string query = "Update [dbo].[Products] Set [name] = '" + producName.Text + "',[Amount] ='" + Amount.Text + "',[price] ='" + Price.Text + "' Where [Id]="+ProductId.Text+"";
            utilities.sql.Set(query);
            show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (delete == false)
            {
                MessageBox.Show("You must select a Product to delete from the data grid");
            }
            else
            {
                string query = "Delete From [dbo].[Products] Where [Id]=" + ProductId.Text + "";
                utilities.sql.Set(query);
                show();
                delete = false;
            }

            
            show();
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView selected_row = grid.SelectedItem as DataRowView;
            if (selected_row != null)
            {
                ProductId.Text = selected_row[0].ToString();
                producName.Text = selected_row[1].ToString();
                Amount.Text = selected_row[2].ToString();
                Price.Text = selected_row[3].ToString();
                delete = true;
            }
           
        }
    }
}
