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
    public class BorrowRecordDAO
    {
        public static List<BorrowRecord> GetBookBorrowing()
        {
            using var db = new LibraryManagementContext();
            List<BorrowRecord> borrowRecords = db.BorrowRecords
                .Where(br => br.BorrowStatus == 0)
                .Include(br => br.Book)
                .Include(br => br.User).ToList();
            return borrowRecords;
        }
        public static List<BorrowRecord> GetBorrowingByBookId(int id)
        {
            using var db = new LibraryManagementContext();
            List<BorrowRecord> borrowRecords = db.BorrowRecords
                .Where(br => br.BorrowStatus == 0 &&  br.BookId == id)
                .Include(br => br.Book)
                .Include(br => br.User).ToList();
            return borrowRecords;
        }
        public static void UpdateBorrowRecord(BorrowRecord record)
        {
            using var db = new LibraryManagementContext();
            if(record.Book != null)
            {
                db.BorrowRecords.Update(record);
                db.SaveChanges();
            }
        }
        public static void CreateNewBorrow(BorrowRecord record, User user)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    using var db = new LibraryManagementContext();

                    
                    var userCheck = db.Users.FirstOrDefault(u => u.Email.Equals(user.Email));
                    if (userCheck == null)
                    {
                        
                        db.Users.Add(user);
                        db.SaveChanges();
                        userCheck = user; 
                    }
                    else
                    {
                       
                        user.UserId = userCheck.UserId;
                    }

                    
                    record.User = userCheck;
                    db.BorrowRecords.Add(record);
                    db.SaveChanges();

                   
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error creating borrow record", ex);
                }
            }
        }
        public static List<BorrowRecord> GetBorrowRecordsByUserId(int userId)
        {
            using var db = new LibraryManagementContext();
            return db.BorrowRecords.Where(br => br.UserId ==  userId)
                .Include(br => br.User)
                .Include(br => br.Book).ToList();                       
        }
        public static void Reservation(BorrowRecord record, User user)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    using var db = new LibraryManagementContext();
                    record.BorrowStatus = -1;
                    db.BorrowRecords.Add(record);
                    db.SaveChanges();
                    int borrowId = record.BorrowId;
                    Reservation reservation = new Reservation();
                    reservation.BorrowId = borrowId;
                    reservation.UserId = user.UserId ;
                    reservation.ReservationDate = DateOnly.FromDateTime(DateTime.Now);
                    db.Reservations.Add(reservation);
                    db.SaveChanges();                   
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error reservation", ex);
                }
            }

        }
        public static int GetReturnedBooksLateByUserId(int id)
        {
            using var db = new LibraryManagementContext();
            User user = db.Users.FirstOrDefault(u => u.UserId == id);
            List<BorrowRecord> list = GetBorrowRecordsByUserId(id);
            int count = 0;
            foreach (BorrowRecord record in list)
            {
                if(record.ReturnDate != null && record.ReturnDate > record.EndDate)
                {
                    count++;
                }
            }
            return count;
        }
        public static List<BorrowRecord> GetReservationRecord(int userId)
        {
            using var db = new LibraryManagementContext();
            return db.BorrowRecords.Where(b=> b.BorrowStatus != 1 && b.UserId == userId).ToList();
        }
    }
}
