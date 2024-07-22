using BusinessObjects;
using Microsoft.IdentityModel.Tokens;
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
    /// Interaction logic for UserDetail.xaml
    /// </summary>

    public partial class UserDetail : Window
    {
        private readonly IBorrowRecordServices _borrowRecordServices;
        private readonly IUserServices _userServices;
    
        public UserDetail()
        {
            InitializeComponent();
            _borrowRecordServices = new BorrowRecordServices();
            _userServices = new UserServices();           
            LoadBorrowOfUser();
            
        }
        public void LoadBorrowOfUser()
        {
            if(!txtUserId.Text.IsNullOrEmpty()) 
            {
                try
                {
                    int id = Int32.Parse(txtUserId.Text);
                    User user = _userServices.GetUserById(id);
                    if (user.Role.Equals("Reader"))
                    {
                        txtPass.Visibility  = Visibility.Visible;
                    }
                    dgBorrow.ItemsSource = null;
                    dgBorrow.ItemsSource = _borrowRecordServices.GetBorrowRecordsByUserId(id);
                }catch(Exception ex) { }
            }
        }
        public void SetData(User user)
        {
            txtUserId.Text = user.UserId.ToString();
            txtName.Text = user.FullName.ToString();
            txtEmailAddress.Text = user.Email;
            txtCCCD.Text = user.Cccd;
            txtPhoneNumber.Text = user.PhoneNumber;           

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgBorrow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
