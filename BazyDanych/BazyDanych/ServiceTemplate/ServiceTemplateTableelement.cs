using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ServiceTemplateTableElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kilometres { get; set; }
        public int Period { get; set; }
        public int CatalogId { get; set; }
        public int TemplateId { get; set; }

        public ServiceTemplateTableElement(int id, string name, int kilometres, int period, int catalogId, int templateId)
        {
            Id = id;
            Name = name;
            Kilometres = kilometres;
            Period = period;
            CatalogId = catalogId;
            TemplateId = templateId;
        }
    }
}
