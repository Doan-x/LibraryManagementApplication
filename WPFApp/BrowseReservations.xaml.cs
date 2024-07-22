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
    /// Interaction logic for BrowseReservations.xaml
    /// </summary>
    public partial class BrowseReservations : Window
    {
        private readonly IReservationServices _reservationServices;
        public BrowseReservations()
        {
            InitializeComponent();
            _reservationServices = new ReservationServices();
            LoadReservations();
            dpEndDate.SelectedDate = DateTime.Now;
            dpStartDate.SelectedDate = DateTime.Now;
        }
        public void LoadReservations()
        {
            dgReservations.ItemsSource = null;
            dgReservations.ItemsSource = _reservationServices.GetReservations();
        }
        private BusinessObjects.Reservation reservationSelected = null;
        private void dgBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgReservations.SelectedItem != null)
            {
                BusinessObjects.Reservation reservation = dgReservations.SelectedItem as BusinessObjects.Reservation;
                if(reservation != null)
                {
                    dpStartDate.SelectedDate = reservation.Borrow.StartDate.Value.ToDateTime(TimeOnly.MinValue);
                    dpEndDate.SelectedDate = reservation.Borrow.EndDate.Value.ToDateTime(TimeOnly.MinValue);
                    reservationSelected = reservation;
                }
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            BusinessObjects.Reservation updateReservation = reservationSelected;
            if(updateReservation != null  && updateReservation.Borrow !=null)
            {
                _reservationServices.UpdateReservation(updateReservation);
            }
            LoadReservations();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string key = txtSearch.Text.ToLower();
            List<BusinessObjects.Reservation> result = new List<BusinessObjects.Reservation>();
            foreach(var item in _reservationServices.GetReservations())
            {
                if(item.Borrow != null)
                {
                    User user = item.User;
                    if(user.Email.ToLower().Contains(key)
                        || user.FullName.ToLower().Contains(key)
                        || user.PhoneNumber.ToLower().Contains(key)
                        || user.Cccd.ToLower().Contains(key)) 
                    {
                        result.Add(item);
                    }
                }
            }
            dgReservations.ItemsSource = null;
            dgReservations.ItemsSource = result;

        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if(reservationSelected != null)
            {
                MessageBoxResult result = MessageBox.Show("You confirm delete this reservation", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _reservationServices.DeleteReservation(reservationSelected.ReservationId);
                    dpEndDate.SelectedDate = DateTime.Now;
                    dpStartDate.SelectedDate = DateTime.Now;
                    LoadReservations();
                }
            }
            else
            {
                MessageBox.Show("Choice row you want to delete ");
            }
                
            
        }
    }
}
