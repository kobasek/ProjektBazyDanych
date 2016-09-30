using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych o samochodzie
    /// </summary>
	public class CarDto
	{
        /// <summary>
        /// Id samochodu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Data zakupu samochodu
        /// </summary>
        public DateTime DateOfPurchase { get; set; }
        /// <summary>
        /// Data złomowania samochodu
        /// </summary>
        public DateTime? DateOfScrapping { get; set; }
        /// <summary>
        /// Czy samochód ma klimatyzację?
        /// </summary>
        public bool AirCondition { get; set; }
        /// <summary>
        /// Koszt zakupu samochodu
        /// </summary>
        public Decimal CostOfPurchase { get; set; }
        /// <summary>
        /// Numer rejestracyjny samochodu
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Pojemność silnika samochodu
        /// </summary>
        public float EngineCapacity { get; set; }
        /// <summary>
        /// Rodzaj zawieszenia samochodu
        /// </summary>
        public string TypeOfBody { get; set; }
        /// <summary>
        /// Rodzaj paliwa jaki samochód wykorzystuje
        /// </summary>
        public char TypeOfFuel { get; set; }
        /// <summary>
        /// Czy samochód posiada automatyczną skrzynię biegów?
        /// </summary>
        public bool AutomaticGearBox { get; set; }
        /// <summary>
        /// Vin samochodu
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        /// Czy samochód posiada wspomaganie kierownicy?
        /// </summary>
        public bool Assistance { get; set; }
        /// <summary>
        /// Id modelu samochodu
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// Czy samochód posiada elektryczne szyby?
        /// </summary>
        public bool ElectricWindows { get; set; }
	}
}
