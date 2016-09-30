using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa przechowująca dane o czynności serwisowej
    /// </summary>
    public class ServiceActionDto
    {
        /// <summary>
        /// Id czynności serwisowej
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa czynności serwisowej
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Koszt czynności serwisowej
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Id katalogu czynności serwisowej
        /// </summary>
        public int CatalogId { get; set; }
        /// <summary>
        /// Id serwisu czynności serwisowej
        /// </summary>
        public int ServiceId { get; set; }
    }
}
