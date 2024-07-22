using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static List<User> GetUserList()
        {
            try
            {
                using var db = new LibraryManagementContext();
                return db.Users.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<User>();
            }
        }
        public static User GetUserByCCCD(string cccd)
        {
            using var db = new LibraryManagementContext();
            return db.Users.FirstOrDefault(u => u.Cccd == cccd);
        }
        public static User GetUserByEmail(string email)
        {
            using var db = new LibraryManagementContext();
            return db.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
        public static void AddNewUser(User user)
        {
            using var db = new LibraryManagementContext();
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static User GetUserById(int id) 
        {
            using var db = new LibraryManagementContext();
            return db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public static void DeleteUser(int id)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    using var db = new LibraryManagementContext();
                    Reservation reservation = db.Reservations.FirstOrDefault(r => r.UserId == id);
                    if(reservation != null)
                    {
                        db.Reservations.Remove(reservation);
                        db.SaveChanges();
                    }
                    BorrowRecord record = db.BorrowRecords.FirstOrDefault(r => r.UserId == id);
                    if(record != null)
                    {
                        db.BorrowRecords.Remove(record);
                        db.SaveChanges();
                    }
                    User user = db.Users.FirstOrDefault(u => u.UserId==id);
                    if(user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                    }
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error reservation", ex);
                }
            }

        }

        public static List<User> SearchUser(string keyword)
        {
            using var db= new LibraryManagementContext();
            var results = db.Users.Where(user =>
            (user.FullName != null && user.FullName.ToLower().Contains(keyword)) ||
            user.Email.ToLower().Contains(keyword) ||
            (user.PhoneNumber != null && user.PhoneNumber.ToLower().Contains(keyword)) ||
            (user.Cccd !=null && user.Cccd.ToLower().Contains(keyword))
        ).ToList();
            return results;
        }
        public static void UpdateUsers(User user)
        {
            using var db = new LibraryManagementContext();
            db.Users.Update(user);
            db.SaveChanges();
        }
    }
}
