using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class BorrowRecord
{
    public int BorrowId { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int? BorrowStatus { get; set; }

    public virtual Book? Book { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User? User { get; set; }
}
