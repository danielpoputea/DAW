using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public string Color { get; set; }

        public string Style { get; set; }
    }
}
