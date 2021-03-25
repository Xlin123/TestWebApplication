using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MockBookRepo mockRepo = new MockBookRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = mockRepo.GetBooks();
            return Ok(books);
        }
        // GET api/commands/{id}
        [HttpGet]
        [Route("{bookname}")]
        public ActionResult<Book> GetBookByName(string bookname)
        {
            var book = mockRepo.GetBookByName(bookname);
            return Ok(book);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = mockRepo.GetBookByID(id);
            return Ok(book);
        }
        
    }
}
