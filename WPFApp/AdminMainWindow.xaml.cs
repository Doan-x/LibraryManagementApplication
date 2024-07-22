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
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }


        private void ManageBooks_Click(object sender, RoutedEventArgs e)
        {
            BookManagement bookManagement = new BookManagement();
            bookManagement.ShowDialog();
        }

        private void BorrowRecords_Click(object sender, RoutedEventArgs e)
        {
            BorrowRecorded borrowRecord = new BorrowRecorded();
            borrowRecord.ShowDialog();
        }

        private void Reservations_Click_1(object sender, RoutedEventArgs e)
        {
            BrowseReservations browseReservations = new BrowseReservations();
            browseReservations.ShowDialog();
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManagementWindow usersManagement = new UserManagementWindow();
            usersManagement.ShowDialog();
        }
    }
}
