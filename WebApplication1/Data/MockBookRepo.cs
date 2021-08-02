using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MockBookRepo : IBook
    {
        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>
            {
                new Book { Id = 0, BookName="Fortnite the movie" },
                new Book { Id = 1, BookName="Steve vs Herobrine" },
                new Book { Id = 2, BookName="Faker?, WHAT#WAS%THAT?" }
            };
            return books;
        }

        public Book GetBookByName(string name)
        {
            foreach(Book book in GetAllBooks())
            {
                if (HttpUtility.UrlDecode(book.BookName) == name)
                    return book;
            }
            return null;
        }


        // DEPRECATED
        public string StripString(string bookName)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9-]");
            string str = rgx.Replace(bookName, "-");
            return str;
        }

        public Book GetBookByID(int id)
        {
            foreach (Book book in GetAllBooks())
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetTakenBooks()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfTaken(Book book)
        {
            throw new NotImplementedException();
        }

        public void TakeOutBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void AddNewBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
