using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa reprezentująca serwis
    /// </summary>
    public class Service
    {
        /// <summary>
        /// ID serwisu
        /// </summary>
        public int id;

        /// <summary>
        /// Koszt serwisu
        /// </summary>
        public decimal cost;

        /// <summary>
        /// Data serwisu
        /// </summary>
        public DateTime serviceDate;

        /// <summary>
        /// komentarz
        /// </summary>
        public string comment;

        /// <summary>
        /// ID miejsca serwisu
        /// </summary>
        public int servicePlaceId;

        /// <summary>
        /// ID zlecenia
        /// </summary>
        public int orderId;

        /// <summary>
        /// Bezparametrowy konstruktor klasy reprezentującej serwis
        /// </summary>
        public Service()
        {

        }

        /// <summary>
        /// Jednoparametrowy konstruktor klasy reprezentującej serwis
        /// </summary>
        /// <param name="serviceDto">Obiekt rezeprezentujący serwis</param>
        public Service(ServiceDto serviceDto)
        {
            id = serviceDto.Id;
            cost = serviceDto.Cost;
            serviceDate = serviceDto.ServiceDate;
            comment = serviceDto.Comment;
            servicePlaceId = serviceDto.ServicePlaceId;
            orderId = serviceDto.OrderId;
        }

        /// <summary>
        /// Metoda pobierająca serwis z bazy
        /// </summary>
        /// <param name="id">Id serwisu, który chcemy pobrać</param>
        /// <returns>Serwis</returns>
        public static Service GetServiceById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<User>();
            var serviceDto = new ServiceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis where serwis.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    serviceDto.Id = dataReader.GetInt32(0);
                    serviceDto.Cost = dataReader.GetDecimal(1);
                    serviceDto.ServiceDate = dataReader.GetDateTime(2);
                    serviceDto.Comment = dataReader.GetString(3);
                    serviceDto.ServicePlaceId = dataReader.GetInt32(4);
                    serviceDto.OrderId = dataReader.GetInt32(5);

                    connection.Close();
                    return new Service(serviceDto);
                }
                else
                {
                    connection.Close();
                    return new Service();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Service();
        }

        /// <summary>
        /// Metoda dodająca serwis do bazy
        /// </summary>
        /// <param name="serviceToAdd">Obiekt reprezenntujący serwis, który chcemy dodać</param>
        public static void AddService(ServiceDto serviceToAdd)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var serviceDate = serviceToAdd.ServiceDate.ToString("yyyy.MM.dd");

                string query = "INSERT INTO projekt_bazy_danych.serwis VALUES(null, " +
                                serviceToAdd.Cost.ToString("F").Replace(",", ".") +
                                ",\"" +
                                serviceDate +
                                "\",\"" +
                                serviceToAdd.Comment +
                                "\"," +
                                serviceToAdd.ServicePlaceId +
                                "," +
                                serviceToAdd.OrderId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano serwis");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda dodaje serwis z czynnością serwisową do bazy
        /// </summary>
        /// <param name="serviceToAdd">Obiekt reprezentujący serwis do dodania</param>
        public static void AddServiceWithServiceActions(ServiceDto serviceToAdd)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var serviceDate = serviceToAdd.ServiceDate.ToString("yyyy.MM.dd");

                string query = "INSERT INTO projekt_bazy_danych.serwis VALUES(null, " +
                                serviceToAdd.Cost.ToString("F").Replace(",", ".") +
                                ",\"" +
                                serviceDate +
                                "\",\"" +
                                serviceToAdd.Comment +
                                "\"," +
                                serviceToAdd.ServicePlaceId +
                                "," +
                                serviceToAdd.OrderId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                int serviceId = (int)command.LastInsertedId;
                MessageBox.Show("Poprawnie dodano serwis");
                foreach (ServiceActionDto serviceAction in serviceToAdd.serviceActions)
                {
                    serviceAction.ServiceId = serviceId;
                    ServiceAction.AddServiceAction(serviceAction);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda pobiera listę serwisów z bazy
        /// </summary>
        /// <returns>Lista serwisów</returns>
        public static IList<Service> GetServiceList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Service>();
            var serviceDto = new ServiceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.serwis;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceDto.Id = dataReader.GetInt32(0);
                    serviceDto.Cost = dataReader.GetDecimal(1);
                    serviceDto.ServiceDate = dataReader.GetDateTime(2);
                    serviceDto.Comment = dataReader.GetString(3);
                    serviceDto.ServicePlaceId = dataReader.GetInt32(4);
                    serviceDto.OrderId = dataReader.GetInt32(5);

                    var service = new Service(serviceDto);
                    list.Add(service);
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
        /// Metoda pobiera listę serwisów należących do danego zlecenia
        /// </summary>
        /// <param name="orderId">ID zlecenia, z którego pobieramy serwisy</param>
        /// <returns>Lista serwisów</returns>
        public static IList<Service> GetServiceListWithGivenOrderId(int orderId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Service>();
            var serviceDto = new ServiceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis WHERE serwis.zlecenie_id = " + orderId + "; ";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceDto.Id = dataReader.GetInt32(0);
                    serviceDto.Cost = dataReader.GetDecimal(1);
                    serviceDto.ServiceDate = dataReader.GetDateTime(2);
                    serviceDto.Comment = dataReader.GetString(3);
                    serviceDto.ServicePlaceId = dataReader.GetInt32(4);
                    serviceDto.OrderId = dataReader.GetInt32(5);

                    var service = new Service(serviceDto);
                    list.Add(service);
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
        /// Metoda aktualizuje serwis w bazie
        /// </summary>
        /// <param name="serviceDto">Obiekt reprezentujący serwis do zaktualizowania w bazie</param>
        public static void UpdateService(ServiceDto serviceDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var serviceDate = serviceDto.ServiceDate.ToString("yyyy.MM.dd");

                string query = "UPDATE projekt_bazy_danych.serwis " +
                                "SET koszt = " +
                                serviceDto.Cost.ToString("F").Replace(",", ".") +
                                ",data_serwisu = \"" +
                                serviceDate +
                                "\",komentarz = \"" +
                                serviceDto.Comment +
                                "\",miejsce_serwisu_id = " +
                                serviceDto.ServicePlaceId +
                                ",zlecenie_id = " +
                                serviceDto.OrderId +
                                " WHERE id = " +
                                serviceDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano serwis");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda pobierająca z bazy serwis należący do zlecenia
        /// </summary>
        /// <param name="idOrder">Id zlecenia, z którego chcemy serwis</param>
        /// <returns></returns>
        public static int GetIdServiceByOrder(int idOrder)
        {
            var connectionString = Functions.GetConnectionString();
            int idService = 0;
            var serviceDto = new ServiceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis where serwis.zlecenie_id = " + idOrder;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    idService = dataReader.GetInt32(0);


                    connection.Close();
                    return idService;
                }
                else
                {
                    connection.Close();
                    return idService;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return idService;
        }
    }
}
