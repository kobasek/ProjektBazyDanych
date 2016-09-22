using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Opieka
    {
        public static int GetOpiekunID(int id)
        {
            var connectionString = Functions.GetConnectionString();
            int opiekunID = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT uzytkownik_id FROM projekt_bazy_danych.opieka where opieka.pojazd_id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    opiekunID = dataReader.GetInt32(0);
                    connection.Close();
                    return opiekunID;
                }
                else
                {
                    connection.Close();
                    return opiekunID;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return opiekunID;
        }

        public static void AddOpieka(int userId, int carId, DateTime startDate)
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
    }
}
