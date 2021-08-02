using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SqlBookRepo : IBook
    {
        private readonly ProjectContext _context;

        public SqlBookRepo(ProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList<Book>();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            var q = from book in _context.Books.ToList<Book>()
                    where book.Author == author
                    select book;
            return q;
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            var q = from book in _context.Books.ToList<Book>()
                    where book.Genre == genre
                    select book;
            return q;
        }

        public Book GetBookByID(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public Book GetBookByName(string name)
        {
            return _context.Books.First(prop => prop.BookName == name);
        }

        public IEnumerable<Book> GetTakenBooks()
        {
            var q = from book in _context.Books.ToList<Book>()
                    where book.IsTaken
                    select book;

            return q;
        }

        public bool CheckIfTaken(Book book)
        {
            return book.IsTaken;
        }

        public void TakeOutBook(Book book)
        {
            //Nothing
        }

        public void AddNewBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            _context.Add(book);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>= 0);
        }
    }
}
