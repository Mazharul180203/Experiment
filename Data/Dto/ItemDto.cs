using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class ItemCreate
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
