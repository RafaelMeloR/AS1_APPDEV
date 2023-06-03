using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AS1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CalendarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void CalendarButton_Click_2(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show(); Close();

        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void sales_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show(); Close();
        }
    }
}
