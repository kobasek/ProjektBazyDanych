using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa przechowująca informacje o szablonie
    /// </summary>
    class Template
    {
        /// <summary>
        /// ID szablonu
        /// </summary>
        public int id;

        /// <summary>
        /// Nazwa szablonu
        /// </summary>
        public string name;

        /// <summary>
        /// Bezparametrowy konstruktor klasy szablon
        /// </summary>
        public Template()
        {

        }

        /// <summary>
        /// Jednoparametrowy konstruktor klasy szablon
        /// </summary>
        /// <param name="templateDto">Obiekt reprezentujący informacje o szablonie</param>
        public Template(TemplateDto templateDto)
        {
            id = templateDto.Id;
            name = templateDto.Name;
        }

        /// <summary>
        /// Metoda zwracająca szablon z bazy
        /// </summary>
        /// <param name="id">ID szablonu, który chcemy pobrać z bazy</param>
        /// <returns>Obiekt reprezentujący pobrany z bazy szablon</returns>
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

        /// <summary>
        /// Metoda dodająca szablon do bazy
        /// </summary>
        /// <param name="templateDto">Obiekt reprezentujący szablon, któy chcemy dodac do bazy</param>
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

        /// <summary>
        /// Metoda pobierająca listę szablonów z bazy
        /// </summary>
        /// <returns>Lista szablonów</returns>
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

        /// <summary>
        /// Metoda aktualizująca szablon w bazie
        /// </summary>
        /// <param name="templateDto">Obiekt reprezentujący zaktualizowany szablon</param>
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
