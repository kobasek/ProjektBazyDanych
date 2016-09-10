using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BazyDanych
{
	class Car
	{
		private DateTime _dateOfPurchase;
		private DateTime _dateOfScrapping;
		private bool _airCondition;
		private Decimal _costOfPurchase;
		private string _registrationNumber;
		private float _engineCapacity;
		private string _typeOfBody;
		private string _typeOfFuel;
		private bool _automaticGearBox;
		private string _vin;
		private bool _assistance;
		private Model _model;
		private bool _electricWindows;
		private int _modelId;

		public Car(DateTime dateOfPurchase, DateTime dateOfScrapping, bool airCondition, Decimal costOfPurchase, string registrationNumber, float engineCapacity, string typeOfBody, string typeOfFuel, bool automaticGearBox, string vin, bool assistance, Model model, bool electricWindows)
		{
			_dateOfPurchase = dateOfPurchase;
			_dateOfScrapping = dateOfScrapping;
			_airCondition = airCondition;
			_costOfPurchase = costOfPurchase;
			_registrationNumber = registrationNumber;
			_engineCapacity = engineCapacity;
			_typeOfBody = typeOfBody;
			_typeOfFuel = typeOfFuel;
			_automaticGearBox = automaticGearBox;
			_vin = vin;
			_assistance = assistance;
			_model = model;
			_electricWindows = electricWindows;
		}

		public Car(CarDto carDto)
		{
			_dateOfPurchase = carDto.DateOfPurchase;
			_dateOfScrapping = carDto.DateOfScrapping;
			_airCondition = carDto.AirCondition;
			_costOfPurchase = carDto.CostOfPurchase;
			_registrationNumber = carDto.RegistrationNumber;
			_engineCapacity = carDto.EngineCapacity;
			_typeOfBody = carDto.TypeOfBody;
			_typeOfFuel = carDto.TypeOfFuel;
			_automaticGearBox = carDto.AutomaticGearBox;
			_vin = carDto.Vin;
			_assistance = carDto.Assistance;
			_modelId = carDto.ModelId;
			_electricWindows = carDto.ElectricWindows;
		}

		public Car()
		{
		}
	}
}
