using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
	class Model
	{
		public int id;
		public string name;
		public string category;
		public int brandId;
		public int? templateId;

		public Model(ModelDto model)
		{
			id = model.Id;
			name = model.Name;
			category = model.Category;
			brandId = model.BrandId;
			templateId = model.TemplateId;
		}

		public Model()
		{
		}

		public static Model GetModelById(int id)
		{
			var connectionString = Functions.GetConnectionString();
			var modelDto = new ModelDto();
			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				string query = "SELECT * FROM projekt_bazy_danych.model WHERE model.id ="+id;
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					modelDto.Id = dataReader.GetInt32(0);
					modelDto.Name = dataReader.GetString(1);
					modelDto.Category = dataReader.GetString(2);
					modelDto.BrandId = dataReader.GetInt32(3);
					modelDto.TemplateId = !dataReader.IsDBNull(4) ? dataReader.GetInt32(4) : (int?)null;
					connection.Close();
					return new Model(modelDto);
				}
				else
				{
					connection.Close();
					return new Model();
				}
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return new Model();
		}

		public static List<Model> GetModelList()
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Model>();
			var modelDto = new ModelDto();
			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				const string query = "SELECT * FROM projekt_bazy_danych.model;";
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					modelDto.Id = dataReader.GetInt32(0);
					modelDto.Name = dataReader.GetString(1);
					modelDto.Category = dataReader.GetString(2);
					modelDto.BrandId = dataReader.GetInt32(3);
					modelDto.TemplateId = !dataReader.IsDBNull(4) ? dataReader.GetInt32(4) : (int?)null;

					var model = new Model(modelDto);
					list.Add(model);
				}
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return list;
		}

        public static List<Model> GetModelsWithGivenTemplateIdList(int templateId)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<Model>();
            var modelDto = new ModelDto();
            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.model WHERE model.szablon_id = " + templateId + ";";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    modelDto.Id = dataReader.GetInt32(0);
                    modelDto.Name = dataReader.GetString(1);
                    modelDto.Category = dataReader.GetString(2);
                    modelDto.BrandId = dataReader.GetInt32(3);
                    modelDto.TemplateId = !dataReader.IsDBNull(4) ? dataReader.GetInt32(4) : (int?)null;

                    var model = new Model(modelDto);
                    list.Add(model);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static List<Model> GetModelListForBrand(int brandId)
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Model>();
			var modelDto = new ModelDto();
			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				string query = "SELECT * FROM projekt_bazy_danych.model WHERE marka_id = " + brandId;
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					modelDto.Id = dataReader.GetInt32(0);
					modelDto.Name = dataReader.GetString(1);
					modelDto.Category = dataReader.GetString(2);
					modelDto.BrandId = dataReader.GetInt32(3);
					modelDto.TemplateId = !dataReader.IsDBNull(4) ? dataReader.GetInt32(4) : (int?)null;

					var model = new Model(modelDto);
					list.Add(model);
				}
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return list;
		}

        public static void AddModel(ModelDto modelDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.model VALUES(null, \"" +
                                modelDto.Name +
                                "\", \"" +
                                modelDto.Category +
                                "\", " +
                                modelDto.BrandId +
                                ", " +
                                modelDto.TemplateId +
                                ");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano model");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateModel(ModelDto modelDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.model " +
                                "SET nazwa = \"" +
                                modelDto.Name +
                                "\",kategoria = \"" +
                                modelDto.Category +
                                "\",marka_id = " +
                                modelDto.BrandId +
                                ",szablon_id = " +
                                modelDto.TemplateId +
                                " WHERE id = " +
                                modelDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano model");
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
