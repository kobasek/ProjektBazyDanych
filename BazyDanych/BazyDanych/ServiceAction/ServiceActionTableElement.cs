using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ServiceActionTableElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int CatalogId { get; set; }
        public int ServiceId { get; set; }

        public ServiceActionTableElement(int id, string name, decimal cost, int catalogId, int serviceId)
        {
            Id = id;
            Name = name;
            Cost = cost;
            CatalogId = catalogId;
            ServiceId = serviceId;
        }
    }
}
