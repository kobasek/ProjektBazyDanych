using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa do przechowywania danych szablonu
    /// </summary>
    public class TemplateDto
    {
        /// <summary>
        /// ID szablonu - GETTER/SETTER
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa szablonu - GETTER/SETTER
        /// </summary>
        public string Name { get; set; }
    }
}
