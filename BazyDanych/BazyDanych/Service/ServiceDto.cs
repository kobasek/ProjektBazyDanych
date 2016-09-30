using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa przechowująca dane o serwisie
    /// </summary>
    public class ServiceDto
    {
        /// <summary>
        /// Lista czynności serwisowych należących do serwisu
        /// </summary>
        public List<ServiceActionDto> serviceActions = new List<ServiceActionDto>();
        /// <summary>
        /// Id serwisu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Koszt serwisu
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Data serwisu
        /// </summary>
        public DateTime ServiceDate { get; set; }
        /// <summary>
        /// Komentarz do serwisu
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Id miejsca serwisu
        /// </summary>
        public int ServicePlaceId { get; set; }
        /// <summary>
        /// Id zlecenia w ramach którego został wykonany serwis
        /// </summary>
        public int OrderId { get; set; }
    }
}
