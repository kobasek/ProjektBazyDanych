using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BazyDanych
{
	class Car
	{
		public int id;
		public DateTime dateOfPurchase;
		public DateTime dateOfScrapping;
		public bool airCondition;
		public Decimal costOfPurchase;
		public string registrationNumber;
		public float engineCapacity;
		public string typeOfBody;
		public string typeOfFuel;
		public bool automaticGearBox;
		public string vin;
		public bool assistance;
		public bool electricWindows;
		public int modelId;

		public Car(CarDto carDto)
		{
			id = carDto.Id;
			dateOfPurchase = carDto.DateOfPurchase;
			dateOfScrapping = carDto.DateOfScrapping;
			airCondition = carDto.AirCondition;
			costOfPurchase = carDto.CostOfPurchase;
			registrationNumber = carDto.RegistrationNumber;
			engineCapacity = carDto.EngineCapacity;
			typeOfBody = carDto.TypeOfBody;
			typeOfFuel = carDto.TypeOfFuel;
			automaticGearBox = carDto.AutomaticGearBox;
			vin = carDto.Vin;
			assistance = carDto.Assistance;
			modelId = carDto.ModelId;
			electricWindows = carDto.ElectricWindows;
		}

		public Car()
		{
		}

		public static IList<Car> GetCarList()
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Car>();
			var carDto = new CarDto();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				const string query = "SELECT * FROM projekt_bazy_danych.pojazd;";
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					carDto.Id = dataReader.GetInt32(0);
					carDto.Vin = dataReader.GetString(1);
					carDto.EngineCapacity = dataReader.GetFloat(2);
					carDto.TypeOfBody = dataReader.GetString(3);
					carDto.RegistrationNumber = dataReader.GetString(4);
					carDto.TypeOfFuel = dataReader.GetString(5);
					carDto.CostOfPurchase = dataReader.GetDecimal(6);
					carDto.ElectricWindows = dataReader.GetBoolean(7);
					carDto.Assistance = dataReader.GetBoolean(8);
					carDto.AirCondition = dataReader.GetBoolean(9);
					carDto.AutomaticGearBox = dataReader.GetBoolean(10);
					carDto.DateOfPurchase = dataReader.GetDateTime(11);
					carDto.DateOfScrapping = dataReader.GetDateTime(12);

					var car = new Car(carDto);
					list.Add(car);
				}
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return list;
		}

		public static Car GetCarById(int id)
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Car>();
			var carDto = new CarDto();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				const string query = "SELECT * FROM projekt_bazy_danych.pojazd;";
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					carDto.Id = dataReader.GetInt32(0);
					carDto.Vin = dataReader.GetString(1);
					carDto.EngineCapacity = dataReader.GetFloat(2);
					carDto.TypeOfBody = dataReader.GetString(3);
					carDto.RegistrationNumber = dataReader.GetString(4);
					carDto.TypeOfFuel = dataReader.GetString(5);
					carDto.CostOfPurchase = dataReader.GetDecimal(6);
					carDto.ElectricWindows = dataReader.GetBoolean(7);
					carDto.Assistance = dataReader.GetBoolean(8);
					carDto.AirCondition = dataReader.GetBoolean(9);
					carDto.AutomaticGearBox = dataReader.GetBoolean(10);
					carDto.DateOfPurchase = dataReader.GetDateTime(11);
					carDto.DateOfScrapping = dataReader.GetDateTime(12);

					connection.Close();
					return new Car(carDto);
				}
				else
				{
					connection.Close();
					return new Car();
				}
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}

			return new Car();
		}
	}
}
