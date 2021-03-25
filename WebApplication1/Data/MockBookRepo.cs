﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MockBookRepo : IBook
    {
        public IEnumerable<Book> GetBooks()
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
            foreach(Book book in GetBooks())
            {
                if (HttpUtility.UrlDecode(book.BookName) == name)
                    return book;
            }
            return null;
        }

        public string StripString(string bookName)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9-]");
            string str = rgx.Replace(bookName, "-");
            return str;
        }

        public Book GetBookByID(int id)
        {
            foreach (Book book in GetBooks())
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }
    }
}
