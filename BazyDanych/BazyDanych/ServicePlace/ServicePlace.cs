using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class ServicePlace
    {
        public int id;
        public string address;
        public string companyName;

        public ServicePlace()
        {

        }

        public ServicePlace(ServicePlaceDto servicePlaceDto)
        {
            id = servicePlaceDto.Id;
            address = servicePlaceDto.Address;
            companyName = servicePlaceDto.CompanyName;
        }

        public static ServicePlace GetServicePlaceById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var servicePlaceDto = new ServicePlaceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.miejsce_serwisu where miejsce_serwisu.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    servicePlaceDto.Id = dataReader.GetInt32(0);
                    servicePlaceDto.Address = dataReader.GetString(1);
                    servicePlaceDto.CompanyName = dataReader.GetString(2);

                    connection.Close();
                    return new ServicePlace(servicePlaceDto);
                }
                else
                {
                    connection.Close();
                    return new ServicePlace();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new ServicePlace();
        }

        public static void AddServicePlace(ServicePlaceDto servicePlaceDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.miejsce_serwisu VALUES(null, \"" +
                                servicePlaceDto.Address +
                                "\", \"" +
                                servicePlaceDto.CompanyName +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano miejsce serwisowe");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<ServicePlace> GetServicePlacesList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServicePlace>();
            var servicePlaceDtoDto = new ServicePlaceDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.miejsce_serwisu;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    servicePlaceDtoDto.Id = dataReader.GetInt32(0);
                    servicePlaceDtoDto.Address = dataReader.GetString(1);
                    servicePlaceDtoDto.CompanyName = dataReader.GetString(2);

                    var servicePlace = new ServicePlace(servicePlaceDtoDto);
                    list.Add(servicePlace);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static void UpdateServicePlace(ServicePlaceDto servicePlaceDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.miejsce_serwisu " +
                                "SET adres = \"" +
                                servicePlaceDto.Address +
                                "\",nazwa_firmy = \"" +
                                servicePlaceDto.CompanyName +
                                "\" WHERE id = " +
                                servicePlaceDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano miejsce serwisu");
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
