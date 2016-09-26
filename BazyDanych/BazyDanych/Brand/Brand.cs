using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
	class Brand
	{
		public int id;
		public string name;

		public Brand()
		{
		}

		public Brand(string name, int id)
		{
			this.name = name;
			this.id = id;
		}

		public static Brand GetBrandById(int id)
		{
			var connectionString = Functions.GetConnectionString();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				string query = "SELECT * FROM projekt_bazy_danych.marka WHERE marka.id =" + id;
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				if (dataReader.Read())
				{
					var brandName = dataReader.GetString(1);
					var brandId = dataReader.GetInt32(0);
					connection.Close();
					return new Brand(brandName, brandId);
				}
				else
				{
					connection.Close();
					return new Brand();
				}
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return new Brand();
		}

		public static List<Brand> GetBrandList()
		{
			var connectionString = Functions.GetConnectionString();
			var list = new List<Brand>();

			try
			{
				var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
				connection.Open();

				const string query = "SELECT * FROM projekt_bazy_danych.marka;";
				var command = new MySqlCommand(query, connection);
				var dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					var brandName = dataReader.GetString(1);
					var brandId = dataReader.GetInt32(0);
					
					var brand = new Brand(brandName, brandId);
					list.Add(brand);
				}
				connection.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show(ex.Message);
			}
			return list;
		}

        public static void AddBrand(BrandDto brandDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.marka VALUES(null, \"" +
                                brandDto.name +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano markę");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateBrand(BrandDto brandDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.marka " +
                                "SET nazwa = \"" +
                                brandDto.name +
                                "\" WHERE id = " +
                                brandDto.id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano markę");
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
