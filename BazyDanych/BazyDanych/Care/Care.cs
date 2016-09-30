using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa reprezentująca opiekę
    /// </summary>
    public class Care
    {
        /// <summary>
        /// Id opieki
        /// </summary>
        public int id;
        /// <summary>
        /// Początkowa data opieki
        /// </summary>
        public DateTime startDate;
        /// <summary>
        /// Końcowa data opieki
        /// </summary>
        public DateTime? endDate;
        /// <summary>
        /// Id opiekuna
        /// </summary>
        public int keeperId;
        /// <summary>
        /// Id samochodu
        /// </summary>
        public int carId;

        /// <summary>
        /// Bezargumentowy onstruktor klasy reprezentującej opiekę
        /// </summary>
        public Care()
        {

        }

        /// <summary>
        /// Jednoargumentowy onstruktor klasy reprezentującej opiekę
        /// </summary>
        /// <param name="careDto">Informacje o opiece do utorzenia</param>
        public Care(CareDto careDto)
        {
            id = careDto.Id;
            startDate = careDto.StartDate;
            endDate = careDto.EndDate;
            keeperId = careDto.KeeperId;
            carId = careDto.CarId;
        }

        /// <summary>
        /// Metoda zwracająca id opiekuna
        /// </summary>
        /// <param name="id">Id zlecenia</param>
        public static int GetKeeperID(int id)
        {
            var connectionString = Functions.GetConnectionString();
            int keeperID = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT uzytkownik_id FROM projekt_bazy_danych.opieka where opieka.pojazd_id = " + id + " AND opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    keeperID = dataReader.GetInt32(0);
                    connection.Close();
                    return keeperID;
                }
                else
                {
                    connection.Close();
                    return keeperID;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return keeperID;
        }

        /// <summary>
        /// Metoda dodająca opiekę do bazy danych
        /// </summary>
        /// <param name="userId">Id opiekuna</param>
        /// <param name="carId">Id samochodu</param>
        /// <param name="startDate">Data początku opieki</param>
        public static void AddCare(int userId, int carId, DateTime startDate)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.opieka VALUES(null, \"" +
                                startDate +
                                 "\",null," +
                                userId +
                                "," +
                                carId +
                               ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie przyznano opiekę");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda dodająca opiekę do bazy danych
        /// </summary>
        /// <param name="careDto">Informacje o opiece do dodania</param>
        public static void AddCare(CareDto careDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var startDate = careDto.StartDate.ToString("yyyy.MM.dd");
                DateTime endDate = careDto.EndDate ?? DateTime.Now;
                string endDateString = endDate.ToString("yyyy.MM.dd");

                string query = "INSERT INTO projekt_bazy_danych.opieka VALUES(null, \"" +
                    startDate +
                                 "\", \"" +
                                 endDateString +
                                 "\", " +
                                 careDto.KeeperId +
                                 "," +
                                 careDto.CarId +
                                 ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano opiekę");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda kończąca opiekę
        /// </summary>
        public static void EndCare(int id)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.opieka SET opieka.data_konca = \"" + DateTime.Now + "\" WHERE id = " + id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda pobierająca opiekę
        /// </summary>
        /// <param name="userId">Id opiekuna opieki</param>
        /// <param name="carId">Id samochodu opieki</param>
        public static int GetCare(int userId, int carId)
        {
            var connectionString = Functions.GetConnectionString();
            int keeperId = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.opieka where opieka.pojazd_id = " + carId + " AND opieka.uzytkownik_id = " + userId;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    keeperId = dataReader.GetInt32(0);
                    connection.Close();
                    return keeperId;
                }
                else
                {
                    connection.Close();
                    return keeperId;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return keeperId;
        }

        /// <summary>
        /// Metoda pobierająca opiekę po samochodzie
        /// </summary>
        /// <param name="carId">Id samochodu opieki</param>
        public static int GetCarebyCar(int carId)
        {
            var connectionString = Functions.GetConnectionString();
            int careId = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.opieka where opieka.pojazd_id = " + carId + " AND opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    careId = dataReader.GetInt32(0);
                    connection.Close();
                    return careId;
                }
                else
                {
                    connection.Close();
                    return careId;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return careId;
        }

        /// <summary>
        /// Metoda pobierająca opiekę po opiekunie
        /// </summary>
        /// <param name="keeperId">Id opiekuna</param>
        public static int GetCarebyKeeper(int keeperId)
        {
            var connectionString = Functions.GetConnectionString();
            int careId = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.opieka where opieka.uzytkownik_id = " + keeperId + " AND opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    careId = dataReader.GetInt32(0);
                    connection.Close();
                    return careId;
                }
                else
                {
                    connection.Close();
                    return careId;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return careId;
        }

        /// <summary>
        /// Metoda Listę opiek danego opiekuna
        /// </summary>
        /// <param name="keeperId">Id opiekuna</param>
        public static List<Care> GetCareItembyKeeper(int keeperId)
        {
            List<Care> list = new List<Care>();
            var connectionString = Functions.GetConnectionString();
            int careId = 0;
            CareDto careDto = new CareDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.opieka where opieka.uzytkownik_id = " + keeperId;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    careDto.Id = dataReader.GetInt32(0);
                    careDto.StartDate = dataReader.GetDateTime(1);
                    careDto.EndDate = dataReader.IsDBNull(2) ? (DateTime?)null : dataReader.GetDateTime(2);
                    careDto.KeeperId = dataReader.GetInt32(3);
                    careDto.CarId = dataReader.GetInt32(4);

                    var care = new Care(careDto);
                    list.Add(care);
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
        /// Metoda zwracająca Id opiekuna
        /// </summary>
        /// <param name="userId">Id opiekuna</param>
        public static int CheckIsKeeper(int userId)
        {
            var connectionString = Functions.GetConnectionString();
            int careId = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.opieka where opieka.uzytkownik_id = " + userId + " AND opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    careId = dataReader.GetInt32(0);
                    connection.Close();
                    return careId;
                }
                else
                {
                    connection.Close();
                    return careId;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return careId;
        }

        /// <summary>
        /// Metoda zwracająca opiekę po id
        /// </summary>
        /// <param name="id">Id opieki</param>
        public static Care GetCareByID(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var careDto = new CareDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.opieka where opieka.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    careDto.Id = dataReader.GetInt32(0);
                    careDto.StartDate = dataReader.GetDateTime(1);
                    careDto.EndDate = dataReader.IsDBNull(2) ? dataReader.GetDateTime(1) : dataReader.GetDateTime(2);
                    careDto.KeeperId = dataReader.GetInt32(3);
                    careDto.CarId = dataReader.GetInt32(4);

                    connection.Close();
                    return new Care(careDto);
                }
                else
                {
                    connection.Close();
                    return new Care();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Care();
        }

        /// <summary>
        /// Metoda zwracająca listę opiek
        /// </summary>
        public static IList<Care> GetCareList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Care>();
            var careDto = new CareDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.opieka;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    careDto.Id = dataReader.GetInt32(0);
                    careDto.StartDate = dataReader.GetDateTime(1);
                    careDto.EndDate = dataReader.IsDBNull(2) ? (DateTime?)null : dataReader.GetDateTime(2);
                    careDto.KeeperId = dataReader.GetInt32(3);
                    careDto.CarId = dataReader.GetInt32(4);

                    var care = new Care(careDto);
                    list.Add(care);
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
        /// Metoda zwracająca listę aktywnych opiek
        /// </summary>
        public static IList<Care> GetActiveCareList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Care>();
            var careDto = new CareDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.opieka WHERE opieka.data_konca IS null";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    careDto.Id = dataReader.GetInt32(0);
                    careDto.StartDate = dataReader.GetDateTime(1);
                    careDto.EndDate = dataReader.IsDBNull(2) ? (DateTime?)null : dataReader.GetDateTime(2);
                    careDto.KeeperId = dataReader.GetInt32(3);
                    careDto.CarId = dataReader.GetInt32(4);

                    var care = new Care(careDto);
                    list.Add(care);
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
        /// Metoda aktualizująca opiekę
        /// </summary>
        /// <param name="careDto">Informacje o opiece do zaktualizowania</param>
        public static void UpdateCare(CareDto careDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();
                var startDate = careDto.StartDate.ToString("yyyy.MM.dd");
                DateTime endDate = careDto.EndDate ?? DateTime.Now;
                string endDateString = endDate.ToString("yyyy.MM.dd");

                string query = "UPDATE projekt_bazy_danych.opieka " +
                                "SET data_poczatku = \"" +
                                startDate +
                                "\",data_konca = \"" +
                                endDateString +
                                "\",uzytkownik_id = " +
                                careDto.KeeperId +
                                ",pojazd_id = " +
                                careDto.CarId +
                                " WHERE id = " +
                                careDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano opiekę");
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