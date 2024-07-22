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
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    public partial class BookDetail : Window
    {
        private readonly IBookServices _bookService;
       
        public BookDetail()
        {
            InitializeComponent();
            _bookService = new BookServices();
            LoadCategories();
        }
        public void LoadCategories()
        {
            cbCategory.Items.Clear();
            cbCategory.ItemsSource = _bookService.GetCategories();
            cbCategory.SelectedIndex = 0;
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "CategoryId";
        }
        
        public void setData(Book book)
        {
            txtBookID.Text = book.BookId.ToString();
            txtBookTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtQuantity.Text = book.Quantity.ToString();
            txtPrice.Text = book.Price.ToString();
            dpDateAdded.SelectedDate = book.DateAdded.Value.ToDateTime(TimeOnly.MinValue);
            cbCategory.SelectedValue = book.Category?.CategoryId;
            if(book.Status == 0)
            {
                Deactice.IsSelected = true;
            }
            lbTitle.Content = null;
            lbTitle.Content = "Edit Book";

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)

        {
            if (Validate())
            {
                Book bookInfor = new Book();
                bookInfor.Title = txtBookTitle.Text;
                bookInfor.Author = txtAuthor.Text;
                bookInfor.Quantity = Int32.Parse(txtQuantity.Text);
                try
                {
                    bookInfor.Price = Decimal.Parse(txtPrice.Text);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Price is valid");
                }
                bookInfor.DateAdded = DateOnly.FromDateTime(dpDateAdded.SelectedDate.Value);
                try
                {
                    bookInfor.CategoryId = Int32.Parse(cbCategory.SelectedValue.ToString());
                }
                catch (Exception ex) { }
                if (Deactice.IsSelected)
                {
                    bookInfor.Status = 0;
                }
                else
                {
                    bookInfor.Status = 1;
                }
                if (!txtBookID.Text.IsNullOrEmpty())
                {
                    bookInfor.BookId = Int32.Parse(txtBookID.Text);
                    _bookService.UpdateBook(bookInfor);
                }
                else
                {
                    _bookService.AddNewBook(bookInfor);
                }
                DialogResult = false;
            }
        }
        private bool Validate()
        {
            // Check if Book Title is empty
            if (string.IsNullOrEmpty(txtBookTitle.Text))
            {
                MessageBox.Show("Book Title is empty");
                return false;
            }

            // Check if Book Author is empty
            if (string.IsNullOrEmpty(txtAuthor.Text))
            {
                MessageBox.Show("Book Author is empty");
                return false;
            }

            // Check if Book Price is empty or not a valid decimal
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Book Price is empty");
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Book Price is not a valid number");
                return false;
            }

            // Check if Book Quantity is empty or not a valid integer
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Book Quantity is empty");
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Book Quantity is not a valid number");
                return false;
            }

            // Check if Date Added is selected
            if (dpDateAdded.SelectedDate == null)
            {
                MessageBox.Show("Date Added is empty");
                return false;
            }

            // Check if Category is selected
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Category is empty");
                return false;
            }

            return true;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
