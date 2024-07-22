using BusinessObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for Reservation.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        private readonly IBookServices _bookServices;
        private readonly IBorrowRecordServices _borrowRecordServices;
        private readonly IUserServices _userServices;
        public string email = null;
        public Reservation()
        {
            InitializeComponent();
            _bookServices = new BookServices();
            _borrowRecordServices = new BorrowRecordServices();
            _userServices = new UserServices();
            LoadBook();
            
            
        }
        public void LoadBook()
        {
            dpStartDate.SelectedDate = DateTime.Now;
            dgBook.ItemsSource = null;
            List<Book> books = _bookServices.GetAll();
            dgBook.ItemsSource = from item in books
                                 select new { book = item, remaining = item.Quantity - _borrowRecordServices.GetBorrowingByBookId(item.BookId).Count };
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                    var selectedItem = dgBook.SelectedItem as dynamic;
                    if(selectedItem != null)
                {
                    Book book = selectedItem.book;
                    
                    User user = _userServices.GetUserByEmail(email);
                    List<BorrowRecord> borrowRecords = _borrowRecordServices.GetReservationRecord(user.UserId);
                    foreach(var item in borrowRecords)
                    {
                        if(book.BookId == item.BookId)
                        {
                            MessageBox.Show("You have already registered to borrow this book");
                            return;
                        }
                    }
                    if (user != null)
                    {
                        BorrowRecord record = new BorrowRecord();                        
                        record.StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value);
                        record.EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value);
                        record.BookId = book.BookId;
                        record.UserId = user.UserId;
                        _borrowRecordServices.Reservation(record, user);
                        MessageBox.Show("Register successful");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Choice the Book you want to borrow");
                    return;
                }
               
            }
        }
        public bool Validate()
        {
            if(dpStartDate.SelectedDate == null)
            {
                MessageBox.Show("Start Date is empty");
                return false;
            }
            if(dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("End Date is empty");
                return false;
            }
            if ((dpEndDate.SelectedDate - dpStartDate.SelectedDate).Value.TotalDays < 0)
            {
                MessageBox.Show("Check your  start and end dates");
                return false;
            }
            if ((dpEndDate.SelectedDate - dpStartDate.SelectedDate).Value.TotalDays > 15) 
            {
                MessageBox.Show("You cannot borrow books for more than 7 days");
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key =txtSearch.Text.ToLower();
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

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            UserMainWindow userMainWindow = new UserMainWindow();
            userMainWindow.email = email;
            userMainWindow.SetData(email);
            userMainWindow.Show();
            this.Close();
        }
    }
}
