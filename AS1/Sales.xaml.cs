using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace AS1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        double total = 0;
        public Sales()
        {
            InitializeComponent();
            utilities.AS1.show(grid);
        }
        private void clean()
        {
            producName.Text = string.Empty;
            Amount.Text = string.Empty;
            Price.Text = string.Empty;
            ProductId.Text = string.Empty;
            quantity.Text = string.Empty;
        }
        private void createBtn_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (quantity.Text != "")
            {
                gridBuy.Items.Add(new
                {
                    ProductId = ProductId.Text,
                    producName = producName.Text,
                    Amount = Amount.Text,
                    Price = Price.Text,
                    quantity = quantity.Text

                });
                total=total+double.Parse(quantity.Text)*double.Parse(Price.Text);
                totalT.Text =Convert.ToString( total);
                clean();
            }
            else
            {
                MessageBox.Show("You must type the desired quantity ");
            }
        }
        private void CalendarButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataRowView selected_row = grid.SelectedItem as DataRowView;
            if (selected_row != null)
            {
                utilities.AS1.copyToTextBox(this, selected_row);
            }
        }

        private void quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            utilities.tools.numberValidation(e);
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            dynamic selected = gridBuy.SelectedItem;
            double itemPrice = double.Parse(selected.Price);
            double itemQuantity = double.Parse(selected.quantity);
            total = total - (itemPrice * itemQuantity);
            totalT.Text=Convert.ToString(total);

            Button deleteButton = (Button)sender;
                dynamic selectedItem = deleteButton.Tag;

                if (selectedItem != null)
                {
                    gridBuy.Items.Remove(selectedItem);
                }
                
            
        }

        private void buyBtn_Click(object sender, RoutedEventArgs e)
        {
                double total = 0;
                String query = "";
                foreach (var item in gridBuy.Items)
                {
                    query = "update [dbo].[Products] set Amount=(select Amount from [dbo].[Products] where id=" + ((dynamic)item).ProductId + ")-(" + ((dynamic)item).quantity + ") where id=" + ((dynamic)item).ProductId + "";
                    utilities.sql.Set(query);
                    total += double.Parse(((dynamic)item).Price) * double.Parse(((dynamic)item).quantity);
                }
                MessageBox.Show(Convert.ToString("Total amount to pay is:" + total));
                clean();
                totalT.Text = string.Empty;
                utilities.AS1.show(grid);
        }
    }
}
