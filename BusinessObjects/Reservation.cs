using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? BorrowId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public bool? Status { get; set; }

    public virtual BorrowRecord? Borrow { get; set; }

    public virtual User? User { get; set; }
}
