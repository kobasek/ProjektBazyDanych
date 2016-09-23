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
        int id;
        string name;

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
    }
}
