using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookServices
    {
        List<Book> GetAll();
        List<Category> GetCategories();
        void AddNewBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        List<Book> SearchBook(string key);
    }
}
