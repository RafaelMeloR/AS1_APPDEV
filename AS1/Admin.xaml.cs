using AS1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
            utilities.AS1.show(grid);
        }
      
     

        private void clean()
        {
            producName.Text = "";
            Amount.Text = "";
            Price.Text = "";
            ProductId.Text = "";
        }

        private void createBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO [dbo].[Products] VALUES ('"+producName.Text+"','"+Amount.Text+"','"+Price.Text+"')";
            utilities.sql.Set(query);
            utilities.AS1.show(grid);
            clean();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductId.Text == "")
            {
                MessageBox.Show("You must select and Product from the data grid");
            }
            else
            {
                string query = "Update [dbo].[Products] Set [name] = '" + producName.Text + "',[Amount] ='" + Amount.Text + "',[price] ='" + Price.Text + "' Where [Id]=" + ProductId.Text + "";
                utilities.sql.Set(query);
                utilities.AS1.show(grid);
                clean();
            }
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
                utilities.AS1.show(grid);
                delete = false;
            }


            utilities.AS1.show(grid);
            clean();
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView selected_row = grid.SelectedItem as DataRowView;
            if (selected_row != null)
            {
                utilities.AS1.copyToTextBox(this,selected_row);
                delete = true;
            }
           
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CalendarButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           utilities.tools.numberValidation(e);
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            utilities.tools.numberValidation(e);
        }
    }
}
