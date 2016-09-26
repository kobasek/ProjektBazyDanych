using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
	public class CarDto
	{
		public int Id { get; set; }
		public DateTime DateOfPurchase { get; set; }

		public DateTime? DateOfScrapping { get; set; }

		public bool AirCondition { get; set; }

		public Decimal CostOfPurchase { get; set; }

		public string RegistrationNumber { get; set; }

		public float EngineCapacity { get; set; }

		public string TypeOfBody { get; set; }

		public char TypeOfFuel { get; set; }

		public bool AutomaticGearBox { get; set; }

		public string Vin { get; set; }

		public bool Assistance { get; set; }

		public int ModelId { get; set; }

		public bool ElectricWindows { get; set; }
	}
}
