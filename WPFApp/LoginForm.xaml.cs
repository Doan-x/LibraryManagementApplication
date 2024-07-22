using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private readonly IUserServices _userServices;
        public LoginForm()
        {
            InitializeComponent();
            _userServices = new UserServices();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                string email = txtEmail.Text;
                User user = _userServices.GetUserByEmail(email);
                if (isValidLogin(email, txtPass.Password))
                {
                    AdminMainWindow adminWindow = new AdminMainWindow();
                    adminWindow.Show();
                    this.Close();

                }
                else
                {
                    if (user != null && user.Password == txtPass.Password)
                    {

                        UserMainWindow userWindow = new UserMainWindow();
                        userWindow.email = email;
                        userWindow.SetData(email);
                        userWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Please check your email and password and try again");
                    }
                }

            }
        }
        private bool isValidLogin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true).Build();

            var adminEmail = config["DefaultAdmin:Email"];
            var adminPass = config["DefaultAdmin:Password"];
            if (adminEmail == email && adminPass == password)
            {
                return true;
            }
            return false;
        }
        private bool Validate()
        {
            if (txtEmail.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Email is Empty");
                return false;
            }
            /* if (ValidateEmail(txtEmail.Text))
             {
                 MessageBox.Show("Email is valid");
                 return false;
             }*/
            if (txtPass.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Password is Empty");
                return false;
            }
            return true;
        }
        public bool ValidateEmail(string email)
        {
            // Regex pattern for basic email validation
            string pattern = @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
