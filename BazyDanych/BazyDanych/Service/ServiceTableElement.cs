using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ServiceTableElement
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Comment { get; set; }
        public int ServicePlaceId { get; set; }
        public int OrderId { get; set; }

        public ServiceTableElement(int id, decimal cost, DateTime serviceDate, string comment, int servicePlaceId, int orderId)
        {
            Id = id;
            Cost = cost;
            ServiceDate = serviceDate;
            Comment = comment;
            ServicePlaceId = servicePlaceId;
            OrderId = orderId;
        }
    }
}
