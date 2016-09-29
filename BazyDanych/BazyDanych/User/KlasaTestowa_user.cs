using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Klasa pomocnicza służąca do wypełniania tabeli z listą użytkowników
    /// </summary>
    class KlasaTestowa_user
    {
        private int id;
        private string name;
        private string lastName;
        private string phone;
        private static string editButton = "Edytuj";
        private static string showCalendar = "Wyświetl";

        public KlasaTestowa_user(int _id, string _name, string _lastName, string _phone)
        {
            this.id = _id;
            this.name = _name;
            this.lastName = _lastName;
            this.phone = _phone;
        }

        public string ShowCalendar
        {
            get
            {
                return showCalendar;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string EditButton
        {
            get
            {
                return editButton;
            }

        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
               phone = value;
            }
        }
    }
}
