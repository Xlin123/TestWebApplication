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
        private readonly MockBookRepo mockWebRepo = new MockBookRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var commandItems = mockWebRepo.GetBooks();
            return Ok(commandItems);
        }
        // GET api/commands/{id}
        [HttpGet]
        [Route("api/[controller]/{bookname=book}")]
        public ActionResult<Book> GetBookByName(string name)
        {
            var commandItem = mockWebRepo.GetBookByName(name);
            return Ok(commandItem);
        }
        
    }
}
