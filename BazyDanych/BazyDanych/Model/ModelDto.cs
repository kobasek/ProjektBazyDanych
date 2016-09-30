using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych o modelu
    /// </summary>
	public class ModelDto
	{
        /// <summary>
        /// Id modelu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nazwa modelu
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Kategoria modelu
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Id marki modelu
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// Id szablonu modelu
        /// </summary>
        public int? TemplateId { get; set; }
	}
}
