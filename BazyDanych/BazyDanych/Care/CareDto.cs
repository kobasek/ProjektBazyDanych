using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych o opiece
    /// </summary>
    public class CareDto
    {
        /// <summary>
        /// Id opieki
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Data początkowa opieki
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Data końcowa opieki
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Id opiekuna
        /// </summary>
        public int KeeperId { get; set; }
        /// <summary>
        /// Id samochodu
        /// </summary>
        public int CarId { get; set; }
    }
}
