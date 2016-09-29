using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BazyDanych
{
    /// <summary>
    /// Klasa reprezentująca samochód
    /// </summary>
	class Car
	{
        /// <summary>
        /// Id pojazdu
        /// </summary>
		public int id;

        /// <summary>
        /// Data zakupu pojazdu
        /// </summary>
		public DateTime dateOfPurchase;

        /// <summary>
        /// Data złomowania pojazdu
        /// </summary>
		public DateTime? dateOfScrapping;

        /// <summary>
        /// Klimatyzacja
        /// </summary>
		public bool airCondition;

        /// <summary>
        /// Koszt zakupu pojazdu
        /// </summary>
		public Decimal costOfPurchase;

        /// <summary>
        /// Nr rejestracyjny pojazdu
        /// </summary>
		public string registrationNumber;

        /// <summary>
        /// Pojemność silnika pojazdu
        /// </summary>
		public float engineCapacity;

        /// <summary>
        /// Rodzaj nadwozia pojazdu
        /// </summary>
		public string typeOfBody;

        /// <summary>
        /// Rodzaj paliwa pojazdu
        /// </summary>
		public char typeOfFuel;

        /// <summary>
        /// Automatyczna skrzynia biegów
        /// </summary>
		public bool automaticGearBox;

        /// <summary>
        /// Nr VIN pojazdu
        /// </summary>
		public string vin;

        /// <summary>
        /// Wspomaganie kierownicy
        /// </summary>
		public bool assistance;

        /// <summary>
        /// Elektryczne szyby
        /// </summary>
		public bool electricWindows;

        /// <summary>
        /// ID modelu, do któego należy samochód
        /// </summary>
		public int modelId;

        /// <summary>
        /// Jednoparametrowy konstruktor klasy reprezentującej samochód
        /// </summary>
        /// <param name="carDto"></param>
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

        /// <summary>
        /// Bezparametrowy konstruktor klasy reprezentującej samochód
        /// </summary>
		public Car()
		{
		}

        /// <summary>
        /// Metoda pobierająca listę samochodów z bazy
        /// </summary>
        /// <returns>Lista pojazdów</returns>
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
					carDto.TypeOfFuel = dataReader.GetChar(5);
					carDto.CostOfPurchase = dataReader.GetDecimal(6);
					carDto.ElectricWindows = dataReader.GetBoolean(7);
					carDto.Assistance = dataReader.GetBoolean(8);
					carDto.AirCondition = dataReader.GetBoolean(9);
					carDto.AutomaticGearBox = dataReader.GetBoolean(10);
					carDto.DateOfPurchase = dataReader.GetDateTime(11);
					carDto.DateOfScrapping = !dataReader.IsDBNull(12) ? dataReader.GetDateTime(12) : (DateTime?)null;
					carDto.ModelId = dataReader.GetInt32(13);

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

        /// <summary>
        /// Metoda pobierająca listę samochodów pod opieką danego użytkownika
        /// </summary>
        /// <param name="userId">Id użytkownika, pod któego opieką samochodów szukamy</param>
        /// <returns>Lista samochodów</returns>
        public static IList<Car> GetUserCarList(int userId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Car>();
            var carDto = new CarDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT pojazd.* FROM pojazd LEFT JOIN opieka ON pojazd.id = opieka.pojazd_id WHERE opieka.uzytkownik_id = " + userId + " AND opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    carDto.Id = dataReader.GetInt32(0);
                    carDto.Vin = dataReader.GetString(1);
                    carDto.EngineCapacity = dataReader.GetFloat(2);
                    carDto.TypeOfBody = dataReader.GetString(3);
                    carDto.RegistrationNumber = dataReader.GetString(4);
                    carDto.TypeOfFuel = dataReader.GetChar(5);
                    carDto.CostOfPurchase = dataReader.GetDecimal(6);
                    carDto.ElectricWindows = dataReader.GetBoolean(7);
                    carDto.Assistance = dataReader.GetBoolean(8);
                    carDto.AirCondition = dataReader.GetBoolean(9);
                    carDto.AutomaticGearBox = dataReader.GetBoolean(10);
                    carDto.DateOfPurchase = dataReader.GetDateTime(11);
                    carDto.DateOfScrapping = !dataReader.IsDBNull(12) ? dataReader.GetDateTime(12) : (DateTime?)null;
                    carDto.ModelId = dataReader.GetInt32(13);

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

        /// <summary>
        /// Metoda pobierająca z bazy samochód
        /// </summary>
        /// <param name="id">ID pojazdu, którego chcemy pobrać z bazy</param>
        /// <returns>Pojazd</returns>
        public static Car GetCarById(int id)
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Car>();
			var carDto = new CarDto();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				string query = "SELECT * FROM projekt_bazy_danych.pojazd where pojazd.id = " + id;
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					carDto.Id = dataReader.GetInt32(0);
					carDto.Vin = dataReader.GetString(1);
					carDto.EngineCapacity = dataReader.GetFloat(2);
					carDto.TypeOfBody = dataReader.GetString(3);
					carDto.RegistrationNumber = dataReader.GetString(4);
					carDto.TypeOfFuel = dataReader.GetChar(5);
					carDto.CostOfPurchase = dataReader.GetDecimal(6);
					carDto.ElectricWindows = dataReader.GetBoolean(7);
					carDto.Assistance = dataReader.GetBoolean(8);
					carDto.AirCondition = dataReader.GetBoolean(9);
					carDto.AutomaticGearBox = dataReader.GetBoolean(10);
					carDto.DateOfPurchase = dataReader.GetDateTime(11);
					carDto.DateOfScrapping = !dataReader.IsDBNull(12) ? dataReader.GetDateTime(12) : (DateTime?)null;
					carDto.ModelId = dataReader.GetInt32(13);

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

        /// <summary>
        /// Metoda dodająca pojazd do bazy
        /// </summary>
        /// <param name="carDto">Obiekt reprezentujący pojazd, który chcemy dodać do bazy</param>
		public static void AddCar(CarDto carDto)
		{
			var connectionString = Functions.GetConnectionString();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				string query = "INSERT INTO projekt_bazy_danych.pojazd VALUES(null, \"" +
								carDto.Vin +
								"\"," +
								carDto.EngineCapacity.ToString("F").Replace(",", ".") +
								",\"" +
								carDto.TypeOfBody +
								"\",\"" +
								carDto.RegistrationNumber +
								"\",'" +
								carDto.TypeOfFuel +
								"'," +
								carDto.CostOfPurchase.ToString("F").Replace(",", ".") +
								"," +
								carDto.ElectricWindows +
								"," +
								carDto.Assistance +
								"," +
								carDto.AirCondition +
								"," +
								carDto.AutomaticGearBox +
								",\"" +
								carDto.DateOfPurchase +
								"\", null," +
								carDto.ModelId +
								");";

				var command = new MySqlCommand(query, connection);
				command.ExecuteReader();
				MessageBox.Show("Poprawnie dodano pojazd");
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				throw ex;
			}
		}

        /// <summary>
        /// Metoda aktualizująca pojazd w bazie
        /// </summary>
        /// <param name="carDto">Obiekt reprezentujący zaktualizowany pojazd</param>
		public static void UpdateCar(CarDto carDto)
		{
			var connectionString = Functions.GetConnectionString();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();
				var dateOfScrapping = carDto.DateOfScrapping.HasValue ? "\""+carDto.DateOfScrapping.ToString()+"\"" : "null";

				string query = "UPDATE projekt_bazy_danych.pojazd " +
								"SET nr_rejestracyjny = \"" +
								carDto.RegistrationNumber +
								"\",paliwo = '" +
								carDto.TypeOfFuel +
								"',data_zlomowania = " +
								dateOfScrapping +
								" WHERE id = " +
								carDto.Id;

				var command = new MySqlCommand(query, connection);
				command.ExecuteReader();
				MessageBox.Show("Poprawnie edytowano pojazd");
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				throw ex;
			}
		}
    }
}
