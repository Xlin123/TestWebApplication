using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _repository;
        private readonly IMapper _mapper;

        public BooksController(IBook repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetBooks()
        {
            var books = _repository.GetAllBooks();
            if(books!=null)
                return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
            return NotFound();
        }
        // GET api/books/{bookname}
        [HttpGet]
        [Route("{bookname}")]
        public ActionResult<BookReadDto> GetBookByName(string bookname)
        {
            var book = _repository.GetBookByName(bookname);
            if (book != null)
                return Ok(_mapper.Map<BookReadDto>(book));
            return NotFound();
        }
        // GET api/books/{author}
        [HttpGet]
        [Route("byAuthor/{author}")]
        public ActionResult<IEnumerable<BookReadDto>> GetBooksByAuthor(string author)
        {
            var books = _repository.GetBooksByAuthor(author);
            if (books != null)
                return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
            return NotFound();
        }
        // GET api/books/{genre}
        [HttpGet]
        [Route("byGenre/{genre}")]
        public ActionResult<IEnumerable<BookReadDto>> GetBooksByGenre(string genre)
        {
            var books = _repository.GetBooksByGenre(genre);
            if (books != null)
                return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}", Name ="GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var book = _repository.GetBookByID(id);
            if (book != null)
                return Ok(_mapper.Map<BookReadDto>(book));
            return NotFound();
        }

        //POST api/books
        [HttpPost]
        public ActionResult<BookReadDto> AddNewBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _repository.AddNewBook(bookModel);
            _repository.SaveChanges();
            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);
            return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);
        }
        
        //PUT api/books/{id}
        [HttpPut("{id}")]
        public ActionResult TakeOutBook(int id, BookUpdateDto bookUpdateDto)
        {
            var bookFromRepo = _repository.GetBookByID(id);
            if(bookFromRepo==null || _repository.CheckIfTaken(bookFromRepo))
            {
                return NotFound();
            }
            _mapper.Map(bookUpdateDto, bookFromRepo);
            _repository.TakeOutBook(bookFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}
