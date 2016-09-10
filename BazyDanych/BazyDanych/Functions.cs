using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
	class Functions
	{
		public static string GetConnectionString()
		{
			return "server=127.0.0.1;uid=root;" +
				"pwd=root;database=projekt_bazy_danych";
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
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return list;
		}
	}

}
