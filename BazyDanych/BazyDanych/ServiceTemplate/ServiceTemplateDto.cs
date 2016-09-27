﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    public class ServiceTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kilometres { get; set; }
        public int Period { get; set; }
        public int CatalogId { get; set; }
        public int TemplateId { get; set; }
    }
}