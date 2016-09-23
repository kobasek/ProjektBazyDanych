using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Service
    {
        public int id;
        public decimal cost;
        public DateTime serviceDate;
        public string comment;
        public int servicePlaceId;
        public int orderId;

        public Service()
        {

        }

        public Service(ServiceDto serviceDto)
        {
            id = serviceDto.Id;
            cost = serviceDto.Cost;
            serviceDate = serviceDto.ServiceDate;
            comment = serviceDto.Comment;
            servicePlaceId = serviceDto.ServicePlaceId;
            orderId = serviceDto.OrderId;
        }

        public Service GetServiceById(int id)
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
                    serviceDto.ServiceDate = dataReader.GetDateTime(1);
                    serviceDto.Comment = dataReader.GetString(2);
                    serviceDto.ServicePlaceId = dataReader.GetInt32(3);
                    serviceDto.OrderId = dataReader.GetInt32(4);

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
    }
}
