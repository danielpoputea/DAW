using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Dog
    {
        public Guid Id { get; set; }
        public int Age { get; set; }

        public int Weight { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }
    }
}
