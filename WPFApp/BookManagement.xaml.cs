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
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : Window
    {
        private readonly IBookServices _bookservices;
        private readonly IBorrowRecordServices _borrowrecordservices;
        private Book bookSelected;
        public BookManagement()
        {
            InitializeComponent();
            _bookservices = new BookServices();
            _borrowrecordservices = new BorrowRecordServices();
            LoadBook();
        }
        public void LoadBook()
        {
            dgBooks.ItemsSource = null;
            dgBooks.ItemsSource = from item in _bookservices.GetAll()
                                  select new { book = item, Borrowing = _borrowrecordservices.GetBorrowingByBookId(item.BookId).Count};
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           BookDetail detail = new BookDetail();
            detail.ShowDialog();
            if(detail.DialogResult == false)
            {
                LoadBook();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            BookDetail detail = new BookDetail();
            detail.setData(bookSelected);
            detail.ShowDialog();
            if (detail.DialogResult == false)
            {
                LoadBook();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book detail = bookSelected;
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this book?", "Notify", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _bookservices.DeleteBook(detail);
            }
            LoadBook();
        }

        private void dgBooks_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                var selectedItem = dataGrid.SelectedItem as dynamic;
                if (selectedItem != null)
                {
                    bookSelected = selectedItem.book;
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text.ToLower();
                List<Book> result = new List<Book>();
                foreach (Book book in _bookservices.GetAll())
                {
                    if(book.Title.ToLower().Contains(key)
                        || book.Author.ToLower().Contains(key))
                    {
                        result.Add(book);
                    }
                }

            dgBooks.ItemsSource = null;
            dgBooks.ItemsSource = from item in result
                                  select new { book = item, Borrowing = _borrowrecordservices.GetBorrowingByBookId(item.BookId).Count };
        
    }

    }
}
