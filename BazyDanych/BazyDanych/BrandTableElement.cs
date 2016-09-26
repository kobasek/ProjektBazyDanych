using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class BrandTableElement
    {
        public int id { get; set; }
        public string name { get; set; }

        public BrandTableElement(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
