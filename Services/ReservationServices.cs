using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservationServices : IReservationServices
    {
        public void DeleteReservation(int id)
        => ReservationDAO.DeleteReservation(id);

        public List<Reservation> GetReservations()
        => ReservationDAO.GetReservations();

        public void UpdateReservation(Reservation reservation)
        => ReservationDAO.UpdateReservation(reservation);
    }
}
