using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Template
    {
        public int id;
        public string name;

        public Template()
        {

        }

        public Template(TemplateDto templateDto)
        {
            id = templateDto.Id;
            name = templateDto.Name;
        }

        public static Template GetTemplateById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var templateDto = new TemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.szablon where szablon.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    templateDto.Id = dataReader.GetInt32(0);
                    templateDto.Name = dataReader.GetString(1);

                    connection.Close();
                    return new Template(templateDto);
                }
                else
                {
                    connection.Close();
                    return new Template();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Template();
        }

        public static void AddTemplate(TemplateDto templateDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.szablon VALUES(null, \"" +
                                templateDto.Name +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano szablon");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<Template> GetTemplatesList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Template>();
            var templateDto = new TemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.szablon;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    templateDto.Id = dataReader.GetInt32(0);
                    templateDto.Name = dataReader.GetString(1);

                    var template = new Template(templateDto);
                    list.Add(template);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static void UpdateTemplate(TemplateDto templateDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.szablon " +
                                "SET nazwa = \"" +
                                templateDto.Name +
                                "\" WHERE id = " +
                                templateDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano szablon");
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
