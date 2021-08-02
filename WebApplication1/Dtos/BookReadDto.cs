using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos
{
    public class BookReadDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsTaken { get; set; }
    }
}
