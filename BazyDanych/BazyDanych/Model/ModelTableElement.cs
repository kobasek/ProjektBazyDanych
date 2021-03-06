﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ModelTableElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int BrandId { get; set; }
        public int? TemplateId { get; set; }
        public string BrandName { get; set; }
        public string TemplateName { get; set; }

        public ModelTableElement(int id, string name, string category, int brandId, int? templateId)
        {
            Id = id;
            Name = name;
            Category = category;
            BrandId = brandId;
            TemplateId = templateId;
            BrandName = Brand.GetBrandById(brandId).name;
            if (templateId != null)
            {
                TemplateName = Template.GetTemplateById((int)templateId).name;
            }
            else
            {
                TemplateName = "Brak szablonu";
            }
        }
    }
}
