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
		public int templateId;

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

				const string query = "SELECT * FROM projekt_bazy_danych.model;";
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					modelDto.Id = dataReader.GetInt32(0);
					modelDto.Name = dataReader.GetString(1);
					modelDto.Category = dataReader.GetString(2);
					modelDto.BrandId = dataReader.GetInt32(3);
					modelDto.TemplateId = dataReader.GetInt32(4);
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
					modelDto.TemplateId = dataReader.GetInt32(4);

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
	}
}
