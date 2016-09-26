using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class CatalogTableElement
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CatalogTableElement(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
