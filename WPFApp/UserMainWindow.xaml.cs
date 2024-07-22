using BusinessObjects;
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
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private readonly IUserServices _userServices;
        private readonly IBorrowRecordServices _borrowRecordServices;
        public string email = null;
        public UserMainWindow()
        {
            InitializeComponent();
            _borrowRecordServices = new BorrowRecordServices();
            _userServices = new UserServices();
           

        }
        private void LoadBorrow(int userID)

        {

                    dgBorrow.ItemsSource = null;
                    List<BorrowRecord> list = _borrowRecordServices.GetBorrowRecordsByUserId(userID);
                    dgBorrow.ItemsSource = from item in list
                                           select new
                                           {
                                               borrow = item,
                                               status = GetStatus(item.BorrowStatus)
                                           };

        }
        private string GetStatus(int? status)
        {
            if (status == 0)
            {
                return "Borrowing";
            }
            if (status == 1)
            {
                return "Borrowed";
            }
            if (status == -1)
            {
                return "Reservation";
            }
            else
            {
                return null;
            }
        }
        public void SetData(string email)
        {
            BusinessObjects.User user = _userServices.GetUserByEmail(email);
            txtUserId.Text = user.UserId.ToString();
            txtName.Text = user.FullName;
            txtCCCD.Text = user.Cccd;
            txtEmailAddress.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtPass.Text = user.Password;
            dpEnrrolTime.SelectedDate = user.DateJoined.Value.ToDateTime(TimeOnly.MinValue);
            LoadBorrow(user.UserId);

        }
        private void btnUserInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.email = email;
            reservation.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text.ToLower();
            List<BusinessObjects.BorrowRecord> results = new List<BusinessObjects.BorrowRecord>();
            try
            {
                Int32 id = Int32.Parse(txtUserId.Text);
                foreach (var record in _borrowRecordServices.GetBorrowRecordsByUserId(id))
                {
                    if (record.Book.Title.ToLower().Contains(key)
                        || record.Book.Author.ToLower().Contains(key))
                    {
                        results.Add(record);
                    }

                }
                dgBorrow.ItemsSource = null;
                dgBorrow.ItemsSource = from item in results
                                       select new
                                       {
                                           borrow = item,
                                           status = GetStatus(item.BorrowStatus)
                                       };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BusinessObjects.User user = new BusinessObjects.User();
            user.FullName = txtName.Text;
            user.Cccd = txtCCCD.Text;
            user.Email = txtEmailAddress.Text;
            user.PhoneNumber = txtPhoneNumber.Text;
            user.Password = txtPass.Text;
            user.UserId = Int32.Parse(txtUserId.Text);
            user.DateJoined = DateOnly.FromDateTime(dpEnrrolTime.SelectedDate.Value);
            _userServices.UpdateUsers(user);
            SetData(txtEmailAddress.Text);
            MessageBox.Show("Update successful");
        }

        private void dgBorrow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
