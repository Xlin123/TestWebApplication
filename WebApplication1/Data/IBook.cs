using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IBook
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookByName(string name);
        Book GetBookByID(int id);
        IEnumerable<Book> GetBooksByGenre(string genre);
        IEnumerable<Book> GetBooksByAuthor(string author);
        IEnumerable<Book> GetTakenBooks();
        bool CheckIfTaken(Book book);
        void TakeOutBook(Book book);
        void AddNewBook(Book book);
        bool SaveChanges();

    }
}
