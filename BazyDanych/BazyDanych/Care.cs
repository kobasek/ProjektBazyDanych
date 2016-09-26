using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Care
    {
        public int id;
        public DateTime startDate;
        public DateTime? endDate;
        public int keeperId;
        public int carId;

        public Care()
        {

        }

        public Care(CareDto careDto)
        {
            id = careDto.Id;
            startDate = careDto.StartDate;
            endDate = careDto.EndDate;
            keeperId = careDto.KeeperId;
            carId = careDto.CarId;
        }

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

        public static int GetCare(int carId)
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
                    careDto.EndDate = dataReader.GetDateTime(2);
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