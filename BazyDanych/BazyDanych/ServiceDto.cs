using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ServiceDto
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Comment { get; set; }
        public int ServicePlaceId { get; set; }
        public int OrderId { get; set; }
    }
}
