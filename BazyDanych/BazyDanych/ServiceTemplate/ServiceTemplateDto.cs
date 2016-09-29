using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych szablonu serwisowego
    /// </summary>
    public class ServiceTemplateDto
    {
        /// <summary>
        /// Id szablonu serwisowego - GETTER/SETTER
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa szablonu serwisowego - GETTER/SETTER
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ilość kilometrów - GETTER/SETTER
        /// </summary>
        public int Kilometres { get; set; }

        /// <summary>
        /// Okres - GETTER/SETTER
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Id katalogu, do którego należy szablon serwisowy - GETTER/SETTER
        /// </summary>
        public int CatalogId { get; set; }

        /// <summary>
        /// ID szablonu, do któego należy szablon serwisowy - GETTER/SETTER
        /// </summary>
        public int TemplateId { get; set; }
    }
}
