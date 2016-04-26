using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class Model
    {
        private string name;
        private string category;
        private Brand brand;

        public Model(string name, string category, Brand brand)
        {
            this.name = name;
            this.category = category;
            this.brand = brand;
        }
    }
}
