using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class ServiceTemplate
    {
        public int id;
        public string name;
        public int kilometres;
        public int period;
        public int catalogId;
        public int templateId;

        public ServiceTemplate()
        {

        }

        public ServiceTemplate(ServiceTemplateDto serviceTemplateDto)
        {
            id = serviceTemplateDto.Id;
            name = serviceTemplateDto.Name;
            kilometres = serviceTemplateDto.Kilometres;
            period = serviceTemplateDto.Period;
            catalogId = serviceTemplateDto.CatalogId;
            templateId = serviceTemplateDto.TemplateId;
        }


        public static ServiceTemplate GetServiceTemplateById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var serviceTemplateDto = new ServiceTemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis_szablon where serwis_szablon.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    serviceTemplateDto.Id = dataReader.GetInt32(0);
                    serviceTemplateDto.Name = dataReader.GetString(1);
                    serviceTemplateDto.Kilometres = dataReader.GetInt32(2);
                    serviceTemplateDto.Period = dataReader.GetInt32(3);
                    serviceTemplateDto.CatalogId = dataReader.GetInt32(4);
                    serviceTemplateDto.TemplateId = dataReader.GetInt32(5);

                    connection.Close();
                    return new ServiceTemplate(serviceTemplateDto);
                }
                else
                {
                    connection.Close();
                    return new ServiceTemplate();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new ServiceTemplate();
        }

        public static void AddServiceTemplate(ServiceTemplateDto serviceTemplateDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.serwis_szablon VALUES(null, \"" +
                                serviceTemplateDto.Name +
                                "\", " +
                                serviceTemplateDto.Kilometres +
                                ", " +
                                serviceTemplateDto.Period +
                                ", " +
                                serviceTemplateDto.CatalogId +
                                ", " +
                                serviceTemplateDto.TemplateId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano szablon serwisu");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<ServiceTemplate> GetServiceTemplatesList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceTemplate>();
            var serviceTemplateDto = new ServiceTemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.serwis_szablon;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceTemplateDto.Id = dataReader.GetInt32(0);
                    serviceTemplateDto.Name = dataReader.GetString(1);
                    serviceTemplateDto.Kilometres = dataReader.GetInt32(2);
                    serviceTemplateDto.Period = dataReader.GetInt32(3);
                    serviceTemplateDto.CatalogId = dataReader.GetInt32(4);
                    serviceTemplateDto.TemplateId = dataReader.GetInt32(5);

                    var serviceTemplate = new ServiceTemplate(serviceTemplateDto);
                    list.Add(serviceTemplate);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static IList<ServiceTemplate> GetServiceTemplatesWithGivenTemplateIdList(int templateId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceTemplate>();
            var serviceTemplateDto = new ServiceTemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis_szablon WHERE serwis_szablon.szablon_id = " + templateId + ";";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceTemplateDto.Id = dataReader.GetInt32(0);
                    serviceTemplateDto.Name = dataReader.GetString(1);
                    serviceTemplateDto.Kilometres = dataReader.GetInt32(2);
                    serviceTemplateDto.Period = dataReader.GetInt32(3);
                    serviceTemplateDto.CatalogId = dataReader.GetInt32(4);
                    serviceTemplateDto.TemplateId = dataReader.GetInt32(5);

                    var serviceTemplate = new ServiceTemplate(serviceTemplateDto);
                    list.Add(serviceTemplate);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static IList<ServiceTemplate> GetServiceTemplatesWithGivenCatalogIdList(int catalogId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<ServiceTemplate>();
            var serviceTemplateDto = new ServiceTemplateDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.serwis_szablon WHERE serwis_szablon.katalog_id = " + catalogId + ";";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceTemplateDto.Id = dataReader.GetInt32(0);
                    serviceTemplateDto.Name = dataReader.GetString(1);
                    serviceTemplateDto.Kilometres = dataReader.GetInt32(2);
                    serviceTemplateDto.Period = dataReader.GetInt32(3);
                    serviceTemplateDto.CatalogId = dataReader.GetInt32(4);
                    serviceTemplateDto.TemplateId = dataReader.GetInt32(5);

                    var serviceTemplate = new ServiceTemplate(serviceTemplateDto);
                    list.Add(serviceTemplate);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static void UpdateServiceTemplate(ServiceTemplateDto serviceTemplateDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.serwis_szablon " +
                                "SET nazwa = \"" +
                                serviceTemplateDto.Name +
                                "\",kilometry = " +
                                serviceTemplateDto.Kilometres +
                                ",okres = " +
                                serviceTemplateDto.Period +
                                ",katalog_id = " +
                                serviceTemplateDto.CatalogId +
                                ",szablon_id = " +
                                serviceTemplateDto.TemplateId +
                                " WHERE id = " +
                                serviceTemplateDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano szablonowy serwis");
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