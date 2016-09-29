using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa do przechowywania danych uzytkownika
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// ID użytkownika - GETTER/SETTER
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Prawa użytkownika - GETTER/SETTER
        /// </summary>
        public char Permissions { get; set; }

        /// <summary>
        /// Imię użytkownika - GETTER/SETTER
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nazwisko użytkownika - GETTER/SETTER
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Telefon użytkownika - GETTER/SETTER
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Miasto użytkownika - GETTER/SETTER
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Kod pocztowy użytkownika - GETTER/SETTER
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Ulica użytkownika - GETTER/SETTER
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Numer budynku użytkownika - GETTER/SETTER
        /// </summary>
        public int BuildingNumber { get; set; }

        /// <summary>
        /// Nr mieszkania użytkownika - GETTER/SETTER
        /// </summary>
        public int? ApartmentNumber { get; set; }

        /// <summary>
        /// Miejsce urodzenia użytkownika - GETTER/SETTER
        /// </summary>
        public string Birthplace { get; set; }

        /// <summary>
        /// Data urodzenia użytkownika - GETTER/SETTER
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Płeć użytkownika - GETTER/SETTER
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Nr dowodu osobistego użytkownika - GETTER/SETTER
        /// </summary>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Pesel użytkownika - GETTER/SETTER
        /// </summary>
        public string Pesel { get; set; }

        /// <summary>
        /// Prawo jazdy użytkownika - GETTER/SETTER
        /// </summary>
        public string DriversLicense { get; set; }

        /// <summary>
        /// Login użytkownika - GETTER/SETTER
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Hasło użytkownika - GETTER/SETTER
        /// </summary>
        public string Password { get; set; }
    }
}
