using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych marki
    /// </summary>
    public class BrandDto
    {
        /// <summary>
        /// Id marki
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nazwa marki
        /// </summary>
        public string name { get; set; }
    }
}
