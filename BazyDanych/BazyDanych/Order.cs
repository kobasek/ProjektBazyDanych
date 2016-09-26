using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Order
    {
        public int id;
        public DateTime plannedStartDate;
        public DateTime plannedEndDate;
        public DateTime actualStartDate;
        public DateTime actualEndDate;
        public int counterStatusBefore;
        public int counterStatusAfter;
        public string commentsBefore;
        public string commentsAfter;
        public char type;
        public decimal cost;
        public string cancellationReason;
        public char state;
        public int careId;
        public int userId;

        public Order()
        {

        }

        public Order(OrderDto orderDto)
        {
            id = orderDto.Id;
            plannedStartDate = orderDto.PlannedStartDate;
            plannedEndDate = orderDto.PlannedEndDate;
            actualStartDate = orderDto.ActualStartDate;
            actualEndDate = orderDto.ActualEndDate;
            counterStatusBefore = orderDto.CounterStatusBefore;
            counterStatusAfter = orderDto.CounterStatusAfter;
            commentsBefore = orderDto.CommentsBefore;
            commentsAfter = orderDto.CommentsAfter;
            type = orderDto.Type;
            cost = orderDto.Cost;
            cancellationReason = orderDto.CancellationReason;
            state = orderDto.State;
            careId = orderDto.CareId;
            userId = orderDto.UserId;
        }

        public static Order GetOrderById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var orderDto = new OrderDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.zlecenie where zlecenie.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    orderDto.Id = dataReader.GetInt32(0);
                    orderDto.PlannedStartDate = dataReader.GetDateTime(1);
                    orderDto.PlannedEndDate = dataReader.GetDateTime(2);
                    orderDto.ActualStartDate = dataReader.GetDateTime(3);
                    orderDto.ActualEndDate = dataReader.GetDateTime(4);
                    orderDto.CounterStatusBefore = dataReader.GetInt32(5);
                    orderDto.CounterStatusAfter = dataReader.GetInt32(6);
                    orderDto.CommentsBefore = dataReader.GetString(7);
                    orderDto.CommentsAfter = dataReader.GetString(8);
                    orderDto.Type = dataReader.GetChar(9);
                    orderDto.Cost = dataReader.GetDecimal(10);
                    orderDto.CancellationReason = dataReader.GetString(11);
                    orderDto.State = dataReader.GetChar(12);
                    orderDto.CareId = dataReader.GetInt32(13);
                    orderDto.UserId = dataReader.GetInt32(14);

                    connection.Close();
                    return new Order(orderDto);
                }
                else
                {
                    connection.Close();
                    return new Order();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Order();
        }

        public static List<Order> GetOrderList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Order>();
            var orderDto = new OrderDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.zlecenie;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    orderDto.Id = dataReader.GetInt32(0);
                    orderDto.PlannedStartDate = dataReader.GetDateTime(1);
                    orderDto.PlannedEndDate = dataReader.GetDateTime(2);
                    orderDto.ActualStartDate = dataReader.GetDateTime(3);
                    orderDto.ActualEndDate = dataReader.GetDateTime(4);
                    orderDto.CounterStatusBefore = dataReader.GetInt32(5);
                    orderDto.CounterStatusAfter = dataReader.GetInt32(6);
                    orderDto.CommentsBefore = dataReader.GetString(7);
                    orderDto.CommentsAfter = dataReader.GetString(8);
                    orderDto.Type = dataReader.GetChar(9);
                    orderDto.Cost = dataReader.GetDecimal(10);
                    orderDto.CancellationReason = dataReader.GetString(11);
                    orderDto.State = dataReader.GetChar(12);
                    orderDto.CareId = dataReader.GetInt32(13);
                    orderDto.UserId = dataReader.GetInt32(14);

                    var order = new Order(orderDto);
                    list.Add(order);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static void AddOrder(OrderDto orderDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var plannedStartDate = orderDto.PlannedStartDate.ToString("yyyy.MM.dd");
                var plannedEndDate = orderDto.PlannedEndDate.ToString("yyyy.MM.dd");
                var actualStartDate = orderDto.ActualStartDate.ToString("yyyy.MM.dd");
                var actualEndDate = orderDto.ActualEndDate.ToString("yyyy.MM.dd");

                string query = "INSERT INTO projekt_bazy_danych.zlecenie VALUES(null, \"" +
                                plannedStartDate +
                                "\", \"" +
                                plannedEndDate +
                                "\", \"" +
                                actualStartDate +
                                "\", \"" +
                                actualEndDate +
                                "\", " +
                                orderDto.CounterStatusBefore +
                                ", " +
                                orderDto.CounterStatusAfter +
                                ", \"" +
                                orderDto.CommentsBefore +
                                "\", \"" +
                                orderDto.CommentsAfter +
                                "\", '" +
                                orderDto.Type +
                                "', " +
                                orderDto.Cost +
                                ", \"" +
                                orderDto.CancellationReason +
                                "\", '" +
                                orderDto.State +
                                "', " +
                                orderDto.CareId +
                                ", " +
                                orderDto.UserId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano zlecenie");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateOrder(OrderDto orderDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                var plannedStartDate = orderDto.PlannedStartDate.ToString("yyyy.MM.dd");
                var plannedEndDate = orderDto.PlannedEndDate.ToString("yyyy.MM.dd");
                var actualStartDate = orderDto.ActualStartDate.ToString("yyyy.MM.dd");
                var actualEndDate = orderDto.ActualEndDate.ToString("yyyy.MM.dd");

                string query = "UPDATE projekt_bazy_danych.zlecenie " +
                                "SET planowana_data_rozpoczecia = \"" +
                                plannedStartDate +
                                "\",planowana_data_zakonczenia = \"" +
                                plannedEndDate +
                                "\",faktyczna_data_rozpoczecia = \"" +
                                actualStartDate +
                                "\",faktyczna_data_zakonczenia = \"" +
                                actualEndDate +
                                "\",stan_licznika_przed = " +
                                orderDto.CounterStatusBefore +
                                ",stan_licznika_po = " +
                                orderDto.CounterStatusAfter +
                                ",uwagi_przed = \"" +
                                orderDto.CommentsBefore +
                                "\",uwagi_po = \"" +
                                orderDto.CommentsAfter +
                                "\",rodzaj_zlecenia = '" +
                                orderDto.Type +
                                "',koszt = " +
                                orderDto.Cost +
                                ",powod_anulowania = \"" +
                                orderDto.CancellationReason +
                                "\",stan_zlecenia = '" +
                                orderDto.State +
                                "',opieka_id = " +
                                orderDto.CareId +
                                ",uzytkownik_id = " +
                                orderDto.UserId +
                                " WHERE id = " +
                                orderDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano zlecenie");
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
