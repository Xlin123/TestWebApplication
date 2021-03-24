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
    public class CommandsController : ControllerBase
    {
        private readonly MockWebRepo mockWebRepo = new MockWebRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            var commandItems = mockWebRepo.GetCommands();
            return Ok(commandItems);
        }
        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = mockWebRepo.GetCommandByID(id);
            return Ok(commandItem);
        }
    }
}
