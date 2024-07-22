using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class ReservationDAO
    {
        public static List<Reservation> GetReservations()
        {
            using var db = new LibraryManagementContext();
            List < Reservation > reservations = db.Reservations.Where(r=> r.Status == false)
                .Include(r => r.User)
                .Include(r => r.Borrow).ToList();
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Borrow != null) 
                {
                    reservation.Borrow.Book = db.Books.FirstOrDefault(b => b.BookId == reservation.Borrow.BookId);
                }
            }
            return reservations;
        }
        public static void UpdateReservation(Reservation reservation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    using var db = new LibraryManagementContext();
                    reservation.Borrow.BorrowStatus = 0;
                    db.BorrowRecords.Update(reservation.Borrow);
                    db.SaveChanges();
                    reservation.Status = true;
                    db.Reservations.Update(reservation);
                    db.SaveChanges();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error reservation update", ex);
                }
            }
        }
        public static void DeleteReservation(int id)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    using var db = new LibraryManagementContext();
                    var reservation = db.Reservations.Find(id);
                    int borrowId = (int)reservation.BorrowId;
                    db.Reservations.Remove(reservation);
                    db.SaveChanges();

                    var borrow =  db.BorrowRecords.Find(borrowId);
                    db.BorrowRecords.Remove(borrow);
                    db.SaveChanges();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error reservation update", ex);
                }
            }
        }
    }
}
