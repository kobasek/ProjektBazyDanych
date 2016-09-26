using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class CareTableElement
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int KeeperId { get; set; }
        public int CarId { get; set; }

        public CareTableElement(int id, DateTime startDate, DateTime? endDate, int keeperId, int carId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            KeeperId = keeperId;
            CarId = carId;
        }
    }
}
