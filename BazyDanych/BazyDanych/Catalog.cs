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
    }
}