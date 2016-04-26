using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class Car
    {
        private DateTime dateOfPurchase;
        private DateTime dateOfScrapping;
        private bool airCondition;
        private Decimal costOfPurchase;
        private string registrationNumber;
        private float engineCapacity;
        private string typeOfBody;
        private string typeOfFuel;
        private bool automaticGearBox;
        private string VIN;
        private bool assistance;

        public Car(DateTime dateOfPurchase, DateTime dateOfScrapping, bool airCondition, Decimal costOfPurchase, string registrationNumber, float engineCapacity, string typeOfBody, string typeOfFuel, bool automaticGearBox, string VIN, bool assistance)
        {
            this.dateOfPurchase = dateOfPurchase;
            this.dateOfScrapping = dateOfScrapping;
            this.airCondition = airCondition;
            this.costOfPurchase = costOfPurchase;
            this.registrationNumber = registrationNumber;
            this.engineCapacity = engineCapacity;
            this.typeOfBody = typeOfBody;
            this.typeOfFuel = typeOfFuel;
            this.automaticGearBox = automaticGearBox;
            this.VIN = VIN;
            this.assistance = assistance;
        }
    }
}
