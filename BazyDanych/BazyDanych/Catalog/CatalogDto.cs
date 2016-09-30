using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych o katalogu
    /// </summary>
    public class CatalogDto
    {
        /// <summary>
        /// Id katalogu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa katalogu
        /// </summary>
        public string Name { get; set; }
    }
}