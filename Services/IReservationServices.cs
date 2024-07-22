using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReservationServices
    {
        List<Reservation> GetReservations();
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int id);
    }
}
