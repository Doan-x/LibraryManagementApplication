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
    /// Interaction logic for BorrowRecordDetail.xaml
    /// </summary>
    public partial class BorrowRecordDetail : Window
    {
        private readonly IBookServices _bookServices;
        private readonly IBorrowRecordServices _borrowRecordServices;
        private readonly IUserServices _userServices;
        public BorrowRecordDetail()
        {
            InitializeComponent();
            _bookServices = new BookServices();
            _borrowRecordServices = new BorrowRecordServices();
            _userServices = new UserServices();
            LoadBook();
        }
        public void LoadBook()
        {
            dgBook.ItemsSource = null;
            List<Book> books = _bookServices.GetAll();
            dgBook.ItemsSource = from item in books
                                 select new
                                 {
                                     book = item,
                                     remaining = (item.Quantity
                                 - _borrowRecordServices.GetBorrowingByBookId(item.BookId).Count)
                                 };
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text;

            List<Book> books = _bookServices.SearchBook(key);
            dgBook.ItemsSource = null;
            if (books.Count > 0)
            {
                dgBook.ItemsSource = from item in books
                                     select new
                                     {
                                         book = item,
                                         remaining = (item.Quantity
                                     - _borrowRecordServices.GetBorrowingByBookId(item.BookId).Count)
                                     };
            }

        }

        private void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                var selectedItem = dataGrid.SelectedItem as dynamic;
                if (selectedItem != null)
                {
                    if (selectedItem.remaining > 0)
                    {
                        Book bookSelected = selectedItem.book;
                        SetDataBook(bookSelected);
                        dpStartDate.SelectedDate = DateTime.Now;

                    }
                    else
                    {
                        MessageBox.Show("This book has been borrowed ");
                    }
                }
            }
        }
        public void SetDataBook(Book book)
        {
            txtAuthor.Text = book.Author;
            txtBookId.Text = book.BookId.ToString();
            txtBookTitle.Text = book.Title;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BusinessObjects.BorrowRecord record = new BusinessObjects.BorrowRecord();
            if (!txtBookId.Text.IsNullOrEmpty())
            {
                if (Validate())
                {
                    record.BookId = Int32.Parse(txtBookId.Text);
                    record.StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value);
                    record.EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value);
                    User user = new User();
                    user.FullName = txtName.Text;
                    user.Email = txtEmailAddress.Text;
                    user.Cccd = txtCCCD.Text;
                    user.PhoneNumber = txtPhoneNumber.Text;

                    _borrowRecordServices.CreateNewBorrow(record, user);
                    System.Windows.MessageBox.Show("Registered to borrow books successfully");
                    ResetBookSelected();
                    LoadBook();
                    new BorrowRecorded().LoadBookBorrowing();
                }
            }
            else
            {
                MessageBox.Show("Choice the book you want to borrow");
                return;
            }

        }
        private void ResetBookSelected()
        {
            txtBookId.Text = null;
            txtBookTitle.Text = null;
            txtAuthor.Text = null;
        }
        private bool Validate()
        {
            // Validate CCCD
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                MessageBox.Show("CCCD of Reader is Empty");
                return false;
            }
            if (txtCCCD.Text.Length > 12)
            {
                MessageBox.Show("CCCD must not exceed 12 characters");
                return false;
            }

            // Validate Name
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name of Reader is Empty");
                return false;
            }

            // Validate Email Address
            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                MessageBox.Show("Email of Reader is Empty");
                return false;
            }
            if (!IsValidEmail(txtEmailAddress.Text))
            {
                MessageBox.Show("Invalid Email Address");
                return false;
            }

            // Validate Phone Number
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone number of Reader is Empty");
                return false;
            }

            // Validate Start Date and End Date
            DateTime? startDate = dpStartDate.SelectedDate;
            DateTime? endDate = dpEndDate.SelectedDate;
            DateTime today = DateTime.Today;

            if (startDate == null)
            {
                MessageBox.Show("Start date is Empty.");
                return false;
            }
            if (endDate == null)
            {
                MessageBox.Show("End date is Empty.");
                return false;
            }
            if (startDate < today || endDate <today )
            {
                MessageBox.Show("Start date and EndDate cannot be earlier than today.");
                return false;
            }
            if ((endDate - startDate).Value.Days > 7  )
            {
                MessageBox.Show("Books cannot be borrowed for more than 7 days");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetBookSelected();
        }

        private void FindCCCD(object sender, RoutedEventArgs e)
        {
            string key = txtCCCD.Text;
            if (!key.IsNullOrEmpty())
            {
                User user = _userServices.GetUserByCCCD(key);
                if (user != null)
                {
                    txtEmailAddress.Text = user.Email;
                    txtName.Text = user.FullName;
                    txtPhoneNumber.Text = user.PhoneNumber;
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
