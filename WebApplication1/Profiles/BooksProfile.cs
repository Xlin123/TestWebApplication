using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class BooksProfile :Profile
    {
        public BooksProfile()
        {
            //source to destination
            CreateMap<Book, BookReadDto>();

            //source from destination
            CreateMap<BookCreateDto, Book>();

            CreateMap<BookUpdateDto, Book>();
        }
    }
}
