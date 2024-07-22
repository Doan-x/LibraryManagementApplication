using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? CategoryId { get; set; }

    private decimal? _price;

    public decimal? Price
    {
        get { return _price.HasValue ? Math.Round(_price.Value, 2) : (decimal?)null; }
        set { _price = value; }
    }

    public int? Quantity { get; set; }

    public DateOnly? DateAdded { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual Category? Category { get; set; }
}
