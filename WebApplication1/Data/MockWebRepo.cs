using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MockWebRepo : IWebRepo
    {
        public IEnumerable<Command> GetCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "ads", Line = "ads", Platform = "sada" },
                new Command { Id = 1, HowTo = "gsfdgs", Line = "sfg", Platform = "fsgdf" },
                new Command { Id = 2, HowTo = "ghjk", Line = "jgkj", Platform = "gjk" }
            };
            return commands;
        }

        public Command GetCommandByID(int id)
        {
            return new Command { Id = 0, HowTo = "ads", Line = "ads", Platform = "sada" };
        }
    }
}
