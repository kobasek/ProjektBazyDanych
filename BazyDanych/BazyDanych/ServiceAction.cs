using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class ServiceAction
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
    }
}
