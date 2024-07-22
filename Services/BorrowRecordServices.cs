using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BorrowRecordServices : IBorrowRecordServices
    {
        public void CreateNewBorrow(BorrowRecord record, User user)
        =>BorrowRecordDAO.CreateNewBorrow(record, user);    

        public List<BorrowRecord> GetBookBorrowing()
        => BorrowRecordDAO.GetBookBorrowing();

        public List<BorrowRecord> GetBorrowingByBookId(int id)
        => BorrowRecordDAO.GetBorrowingByBookId(id);

        public List<BorrowRecord> GetBorrowRecordsByUserId(int userId)
        => BorrowRecordDAO.GetBorrowRecordsByUserId((int)userId);

        public List<BorrowRecord> GetReservationRecord(int userId)
        => BorrowRecordDAO.GetReservationRecord(userId);

        public int GetReturnedBooksLateByUserId(int id)
        => BorrowRecordDAO.GetReturnedBooksLateByUserId(id);

        public void Reservation(BorrowRecord record, User user)
        => BorrowRecordDAO.Reservation(record,user);

        public void UpdateBorrowRecord(BorrowRecord record)
        => BorrowRecordDAO.UpdateBorrowRecord(record);


    }
}
