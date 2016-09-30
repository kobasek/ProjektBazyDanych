using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa reprezentująca czynność serwisową
    /// </summary>
    public class ServiceAction
    {
        /// <summary>
        /// Id czynności seriwsowej
        /// </summary>
        public int id;
        /// <summary>
        /// Nazwa czynności serwisowej
        /// </summary>
        public string name;
        /// <summary>
        /// Koszt czynności serwisowej
        /// </summary>
        public decimal cost;
        /// <summary>
        /// Id katalogu czynności serwisowej
        /// </summary>
        public int catalogId;
        /// <summary>
        /// Id serwisu czynności serwisowej
        /// </summary>
        public int serviceId;

        /// <summary>
        /// Bezparametrowy konstruktor
        /// </summary>
        public ServiceAction()
        {

        }

        /// <summary>
        /// Jednoargumentowy konstruktor klasy zawierającej informacje o użytkowniku
        /// </summary>
        /// <param name="serviceActionDto">Obiekt reprezentujący czynność serwisową</param>
        public ServiceAction(ServiceActionDto serviceActionDto)
        {
            id = serviceActionDto.Id;
            name = serviceActionDto.Name;
            cost = serviceActionDto.Cost;
            catalogId = serviceActionDto.CatalogId;
            serviceId = serviceActionDto.ServiceId;
        }

        /// <summary>
        /// Metoda pobierająca czynność serwisową o podanym Id
        /// </summary>
        /// <param name="id">Id czynności serwisowej</param>
        public static ServiceAction GetServiceActionById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<User>();
            var serviceActionDto = new ServiceActionDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.czynnosc_serwisowa where czynnosc_serwisowa.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    serviceActionDto.Id = dataReader.GetInt32(0);
                    serviceActionDto.Name = dataReader.GetString(1);
                    serviceActionDto.Cost = dataReader.GetDecimal(2);
                    serviceActionDto.CatalogId = dataReader.GetInt32(3);
                    serviceActionDto.ServiceId = dataReader.GetInt32(4);

                    connection.Close();
                    return new ServiceAction(serviceActionDto);
                }
                else
                {
                    connection.Close();
                    return new ServiceAction();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new ServiceAction();
        }

        /// <summary>
        /// Metoda dodająca do bazy danych podaną czynność serwisową
        /// </summary>
        /// <param name="serviceActionDto">Dane o czynności serwisowej do dodania do bazy danych</param>
        public static void AddServiceAction(ServiceActionDto serviceActionDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.czynnosc_serwisowa VALUES(null, \"" +
                                serviceActionDto.Name +
                                "\", " +
                                serviceActionDto.Cost +
                                ", " +
                                serviceActionDto.CatalogId +
                                ", " +
                                serviceActionDto.ServiceId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano czynnosc serwisową");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Metoda pobierająca listę czynności serwisowych z bazy danych
        /// </summary>
        public static IList<ServiceAction> GetServiceActionsList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceAction>();
            var serviceActionDto = new ServiceActionDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.czynnosc_serwisowa;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceActionDto.Id = dataReader.GetInt32(0);
                    serviceActionDto.Name = dataReader.GetString(1);
                    serviceActionDto.Cost = dataReader.GetInt32(2);
                    serviceActionDto.CatalogId = dataReader.GetInt32(3);
                    serviceActionDto.ServiceId = dataReader.GetInt32(4);

                    var serviceAction = new ServiceAction(serviceActionDto);
                    list.Add(serviceAction);
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
        /// Metoda pobierająca listę czynności serwisowych o podanym id katalogu z bazy danych
        /// </summary>
        /// <param name="catalogId">Id katalogu</param>
        public static IList<ServiceAction> GetServiceActionsWithGivenCatalogIdList(int catalogId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceAction>();
            var serviceActionDto = new ServiceActionDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.czynnosc_serwisowa WHERE czynnosc_serwisowa.katalog_id = " + catalogId + ";";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceActionDto.Id = dataReader.GetInt32(0);
                    serviceActionDto.Name = dataReader.GetString(1);
                    serviceActionDto.Cost = dataReader.GetInt32(2);
                    serviceActionDto.CatalogId = dataReader.GetInt32(3);
                    serviceActionDto.ServiceId = dataReader.GetInt32(4);

                    var serviceAction = new ServiceAction(serviceActionDto);
                    list.Add(serviceAction);
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
        /// Metoda pobierająca listę czynności serwisowych o podanym id serwisu z bazy danych
        /// </summary>
        /// <param name="serviceId">Id serwisu</param>
        public static IList<ServiceAction> GetServiceActionsWithGivenServiceIdList(int serviceId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceAction>();
            var serviceActionDto = new ServiceActionDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.czynnosc_serwisowa WHERE czynnosc_serwisowa.serwis_id = " + serviceId + ";";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceActionDto.Id = dataReader.GetInt32(0);
                    serviceActionDto.Name = dataReader.GetString(1);
                    serviceActionDto.Cost = dataReader.GetInt32(2);
                    serviceActionDto.CatalogId = dataReader.GetInt32(3);
                    serviceActionDto.ServiceId = dataReader.GetInt32(4);

                    var serviceAction = new ServiceAction(serviceActionDto);
                    list.Add(serviceAction);
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
        /// Metoda uaktualniająca dane o czynności serwisowej
        /// </summary>
        /// <param name="serviceActionDto">Dane o czynności serwisowej do zaktualizowania</param>
        public static void UpdateServiceAction(ServiceActionDto serviceActionDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.czynnosc_serwisowa " +
                                "SET nazwa = \"" +
                                serviceActionDto.Name +
                                "\",koszt = " +
                                serviceActionDto.Cost +
                                ",katalog_id = " +
                                serviceActionDto.CatalogId +
                                ",serwis_id = " +
                                serviceActionDto.ServiceId +
                                " WHERE id = " +
                                serviceActionDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano czynność serwisową");
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
