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
    }
}
