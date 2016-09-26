using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Catalog
    {
        public int id;
        public string name;

        public Catalog()
        {

        }

        public Catalog(CatalogDto catalogDto)
        {
            id = catalogDto.Id;
            name = catalogDto.Name;
        }

        public static Catalog GetCatalogById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var catalogDto = new CatalogDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.katalog where katalog.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    catalogDto.Id = dataReader.GetInt32(0);
                    catalogDto.Name = dataReader.GetString(1);

                    connection.Close();
                    return new Catalog(catalogDto);
                }
                else
                {
                    connection.Close();
                    return new Catalog();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new Catalog();
        }

        public static void AddCatalog(CatalogDto catalogDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.katalog VALUES(null, \"" +
                                catalogDto.Name +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano katalog");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<Catalog> GetCatalogsList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Catalog>();
            var catalogDto = new CatalogDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.katalog;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    catalogDto.Id = dataReader.GetInt32(0);
                    catalogDto.Name = dataReader.GetString(1);

                    var catalog = new Catalog(catalogDto);
                    list.Add(catalog);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static void UpdateCatalog(CatalogDto catalogDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.katalog " +
                                "SET nazwa = \"" +
                                catalogDto.Name +
                                "\" WHERE id = " +
                                catalogDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano katalog");
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