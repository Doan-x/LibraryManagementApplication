using BusinessObjects;
using Microsoft.VisualBasic.ApplicationServices;
using Services;
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
    /// Interaction logic for UserManagementWindow.xaml
    /// </summary>
    public partial class UserManagementWindow : Window
    {
        private readonly IUserServices _userServices;
        private readonly IBorrowRecordServices _borrowRecordServices;
        public UserManagementWindow()
        {
            InitializeComponent();
            _userServices = new UserServices();
            _borrowRecordServices = new BorrowRecordServices();
            LoadUsers();
        }
        public void LoadUsers()
        {
            dgUsers.ItemsSource = null;
            List<BusinessObjects.User> listUser = _userServices.GetUserList();

            var dataSource = from item in listUser
                             where item != null && item.UserId != null
                             select new
                             {
                                 user = item,
                                 borrowing = CountNumberOfBorrowedBook(item.UserId),
                                 borrowed = CountNumberOfBorrowingBook(item.UserId),
                                 returnedLate = _borrowRecordServices.GetReturnedBooksLateByUserId(item.UserId)
                             };

            dgUsers.ItemsSource = dataSource.ToList();
        }
        private int CountNumberOfBorrowingBook(int userId)
        {
           if(_borrowRecordServices.GetBorrowRecordsByUserId(userId) != null)
            {
                return _borrowRecordServices.GetBorrowRecordsByUserId(userId).Count();
            }
            else
            {
                return 0;
            }
        }
        private int CountNumberOfBorrowedBook(int userId)
        {
            List<BorrowRecord> borrowRecords = _borrowRecordServices.GetBorrowRecordsByUserId(userId);
            int count = 0;
            foreach(var item in  borrowRecords)
            {
                if(item.BorrowStatus == 0 && item.BorrowStatus != null)
                {
                    count++;
                }
            }
            return count;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = null;
            List<BusinessObjects.User> listUser = _userServices.SearchUser(txtSearch.Text);

            var dataSource = from item in listUser
                             where item != null && item.UserId != null
                             select new
                             {
                                 user = item,
                                 borrowing = CountNumberOfBorrowedBook(item.UserId),
                                 borrowed = CountNumberOfBorrowingBook(item.UserId),
                                 returnedLate = _borrowRecordServices.GetReturnedBooksLateByUserId(item.UserId)
                             };

            dgUsers.ItemsSource = dataSource.ToList();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsers.SelectedItem != null) 
            {
                var selectedItem = dgUsers.SelectedItem as dynamic;
                if(selectedItem != null)
                {
                    BusinessObjects.User user = selectedItem.user;
                    if(user != null)
                    {
                        if(CountNumberOfBorrowingBook(user.UserId) >0)
                        {
                            MessageBox.Show("It is not possible to delete a user who has not returned all the books");
                            return;
                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show("Confirm delete this user", "confirm", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                _userServices.DeleteUser(user.UserId);
                                LoadUsers();
                            }
                        }                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Choice the user want to delete");
                return;
            }
            
        }
    }
}
