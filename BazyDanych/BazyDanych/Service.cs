﻿using System;
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

        public static void AddService(ServiceDto serviceToAdd)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.serwis VALUES(null, " +
                                serviceToAdd.Cost.ToString("F").Replace(",", ".") +
                                ",\"" +
                                serviceToAdd.ServiceDate +
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

        public static void UpdateService(ServiceDto serviceDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.serwis " +
                                "SET koszt = " +
                                serviceDto.Cost.ToString("F").Replace(",", ".") +
                                ",data_serwisu = \"" +
                                serviceDto.ServiceDate +
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
    }
}
