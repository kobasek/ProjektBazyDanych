using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class KlasaTestowa_order
    {
        private int id;
        private string keeper;
        private string driver;
        private string car;
        private static string editButton = "Edytuj";
        private static string showCalendar = "Wyświetl";

        public KlasaTestowa_order(int _id, string _keeper, string _driver, string _car)
        {
            this.id = _id;
            this.keeper = _keeper;
            this.driver = _driver;
            this.car = _car;
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
        public string Keeper
        {
            get
            {
                return keeper;
            }
            set
            {
               keeper = value;
            }
        }

        public string Car
        {
            get
            {
                return car;
            }
            set
            {
               car = value;
            }
        }

        public string Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }
    }
}
