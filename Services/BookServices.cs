using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookServices : IBookServices
    {
        public void AddNewBook(Book book)
        =>BookDAO.AddNewBook(book);

        public void DeleteBook(Book book)
        => BookDAO.DeleteBook(book);

        public List<Book> GetAll()
        => BookDAO.GetAlL();

        public List<Category> GetCategories()
        => BookDAO.GetCategories();

        public List<Book> SearchBook(string key)
        => BookDAO.SearchBook(key);

        public void UpdateBook(Book book)
        => BookDAO.UpdateBook(book);
    }
}
