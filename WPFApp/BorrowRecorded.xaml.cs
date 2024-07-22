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
    /// Interaction logic for BorrowRecord.xaml
    /// </summary>
    public partial class BorrowRecorded : Window
    {
        private readonly IBorrowRecordServices _services;
        private BorrowRecord recordSelected ;
        public BorrowRecorded()
        {
            InitializeComponent();
            _services = new BorrowRecordServices();
            LoadBookBorrowing();
        }
        public void LoadBookBorrowing()
        {
            dgBorrowedBook.ItemsSource = null;
            List<BorrowRecord> borrowRecords = _services.GetBookBorrowing();
            dgBorrowedBook.ItemsSource = from item in borrowRecords
                                         select new { borrow = item, debt = CountDaysDebt(item.EndDate.Value) };
        }

        public int CountDaysDebt(DateOnly endDate)
        {
            DateTime current = DateTime.Now;
            DateTime end = endDate.ToDateTime(TimeOnly.MinValue);
            if (end > current)
            {
                return 0;
            }
            else
            {
                TimeSpan difference = current - end;
                return difference.Days;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BorrowRecordDetail borrowRecordDetail = new BorrowRecordDetail();
            borrowRecordDetail.ShowDialog();
            if(borrowRecordDetail.DialogResult == false)
            {
                LoadBookBorrowing();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text.ToLower();
            List<BorrowRecord> results = new List<BorrowRecord> ();
            foreach(var record in _services.GetBookBorrowing())
            {
                if(record.User.FullName.ToLower().Contains(key)
                    ||record.Book.Author.ToLower().Contains(key)
                    ||record.User.Cccd.ToLower().ToString().Contains(key)
                    ||record.User.PhoneNumber.ToLower().Contains(key)){
                    results.Add(record);
                }
    
            }
            dgBorrowedBook.ItemsSource = null;
            dgBorrowedBook.Items.Clear ();
            dgBorrowedBook.ItemsSource = dgBorrowedBook.ItemsSource = from item in results
                                                                      select new { borrow = item, debt = CountDaysDebt(item.EndDate.Value) };
        }

        private void dgBorrowedBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if(dataGrid != null )
            {
                var selectedItem = dgBorrowedBook.SelectedItem as dynamic;
                if(selectedItem != null)
                {
                    recordSelected = selectedItem.borrow;
                }
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
   
            if (recordSelected != null)
            {
                recordSelected.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
                recordSelected.BorrowStatus = 1;
                _services.UpdateBorrowRecord(recordSelected);
            }
            LoadBookBorrowing();
        }
    }
}
