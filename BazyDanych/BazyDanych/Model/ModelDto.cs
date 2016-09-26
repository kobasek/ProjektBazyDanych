using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
	public class ModelDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public int BrandId { get; set; }

		public int? TemplateId { get; set; }
	}
}
