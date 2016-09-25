using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class ServicePlaceTableElement
    {
        public int id { get; set; }
        public string address { get; set; }
        public string companyName { get; set; }
        public static string editButton { get; set; } = "Edytuj";

        public ServicePlaceTableElement(int _id, string _address, string _companyName)
        {
            this.id = _id;
            this.address = _address;
            this.companyName = _companyName;
        }
    }
}