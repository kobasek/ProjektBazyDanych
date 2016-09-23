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
                    serviceTemplateDto.Kilometres = dataReader.GetInt32(1);
                    serviceTemplateDto.Period = dataReader.GetInt32(2);
                    serviceTemplateDto.CatalogId = dataReader.GetInt32(3);
                    serviceTemplateDto.TemplateId = dataReader.GetInt32(4);

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
    }
}