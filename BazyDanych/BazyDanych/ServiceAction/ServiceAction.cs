using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    public class ServiceAction
    {
        public int id;
        public string name;
        public decimal cost;
        public int catalogId;
        public int serviceId;

        public ServiceAction()
        {

        }

        public ServiceAction(ServiceActionDto serviceActionDto)
        {
            id = serviceActionDto.Id;
            name = serviceActionDto.Name;
            cost = serviceActionDto.Cost;
            catalogId = serviceActionDto.CatalogId;
            serviceId = serviceActionDto.ServiceId;
        }

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
