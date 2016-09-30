using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa przechowująca dane o miejscu serwisu
    /// </summary>
    public class ServicePlaceDto
    {
        /// <summary>
        /// Id miejsca serwisowego
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Adres miejsca serwisowego
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Nazwa firmy miejsca serwisowego
        /// </summary>
        public string CompanyName { get; set; }
    }
}
