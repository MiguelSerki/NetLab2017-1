using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class ReadOrderDto
    {
        public int OrderID { get; set; }
        public decimal? Freight { get; set; }
        public string CustomerName { get; set; }
    }
}
