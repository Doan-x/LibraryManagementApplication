using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBorrowRecordServices
    {
        List<BorrowRecord> GetBookBorrowing();
        void UpdateBorrowRecord(BorrowRecord record);
        List<BorrowRecord> GetBorrowingByBookId(int id);
        void CreateNewBorrow(BorrowRecord record, User user);
        List<BorrowRecord> GetBorrowRecordsByUserId(int userId);
        void Reservation(BorrowRecord record, User user);

        int GetReturnedBooksLateByUserId(int id);
        List<BorrowRecord> GetReservationRecord(int userId);
    }
}
