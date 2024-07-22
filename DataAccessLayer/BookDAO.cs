using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookDAO
    {
        public static List<Book> GetAlL()
        {
            using var db = new LibraryManagementContext();
            List<Book> books =  db.Books.ToList();
            foreach(var item in books)
            {
                item.Category = db.Categories.FirstOrDefault(cat => cat.CategoryId == item.CategoryId);
            }
            return books;
        }
        public static Book GetBook( int id)
        {
            using var db = new LibraryManagementContext();
            return db.Books.Where(b => b.BookId == id) as Book;
        }
        public static List<Category> GetCategories()
        {
            using var db = new LibraryManagementContext();
            return db.Categories.ToList();
        }
         public static void AddNewBook(Book book)
        {
            using var db = new LibraryManagementContext();
            db.Books.Add(book);
            db.SaveChanges();
        }
        public static void UpdateBook(Book book)
        {
            using var db = new LibraryManagementContext();
            db.Books.Update(book);
            db.SaveChanges();
        }
        public static void DeleteBook(Book book)
        {
            using var db = new LibraryManagementContext();
            db.Books.Remove(book);
            db.SaveChanges();
        }
        public static List<Book> SearchBook(string key) {
            using var db = new LibraryManagementContext();
            List<Book> books = db.Books.Where(b => b.Title.ToLower().Contains(key) || b.Author.ToLower().Contains(key))
                .Include(b => b.Category).ToList();
            return books;
        }
    }
}
