using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Soda
    {
        public Guid Id { get; set; }

        public String Brand { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}
