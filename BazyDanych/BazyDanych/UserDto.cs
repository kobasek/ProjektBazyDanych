using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    public class UserDto
    {
        public int Id { get; set; }
        public char Permissions { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Birthplace { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Pesel { get; set; }
        public string DriversLicense { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
