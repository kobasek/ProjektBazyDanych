using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class User
    {
        public int id;
        public char permissions;
        public string name;
        public string lastName;
        public string phone;
        public string city;
        public string street;
        public string zipCode;
        public int buildingNumber;
        public int? apartmentNumber;
        public string birthplace;
        public DateTime dateOfBirth;
        public char gender;
        public string identityCardNumber;
        public string pesel;
        public string driversLicense;
        public string login;
        public string password;

        public User(UserDto userDto)
        {
            id = userDto.Id;
            permissions = userDto.Permissions;
            name = userDto.Name;
            lastName = userDto.LastName;
            phone = userDto.Phone;
            city = userDto.City;
            zipCode = userDto.ZipCode;
            street = userDto.Street;
            buildingNumber = userDto.BuildingNumber;
            apartmentNumber = userDto.ApartmentNumber;
            birthplace = userDto.Birthplace;
            dateOfBirth = userDto.DateOfBirth;
            gender = userDto.Gender;
            identityCardNumber = userDto.IdentityCardNumber;
            pesel = userDto.Pesel;
            driversLicense = userDto.DriversLicense;
            login = userDto.Login;
            password = userDto.Password;
            phone = userDto.Phone;
        }

        public User()
        {
        }

        public static IList<User> GetUserList(char permissions = 'a')
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<User>();
            var userDto = new UserDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT * FROM projekt_bazy_danych.uzytkownik;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    userDto.Id = dataReader.GetInt32(0);
                    userDto.Name = dataReader.GetString(2);
                    userDto.LastName = dataReader.GetString(3);
                    userDto.Phone = dataReader.GetString(4);

                    var user = new User(userDto);
                    list.Add(user);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static User GetUserById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<User>();
            var userDto = new UserDto();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT * FROM projekt_bazy_danych.uzytkownik where uzytkownik.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    userDto.Id = dataReader.GetInt32(0);
                    userDto.Permissions = dataReader.GetChar(1);
                    userDto.Name = dataReader.GetString(2);
                    userDto.LastName = dataReader.GetString(3);
                    userDto.Phone = dataReader.GetString(4);
                    userDto.City = dataReader.GetString(5);
                    userDto.ZipCode = dataReader.GetString(6);
                    userDto.Street = dataReader.GetString(7);
                    userDto.BuildingNumber = dataReader.GetInt32(8);
                    userDto.ApartmentNumber = dataReader.GetInt32(9);
                    userDto.Birthplace = dataReader.GetString(10);
                    userDto.DateOfBirth = dataReader.GetDateTime(11);
                    userDto.Gender = dataReader.GetChar(12);
                    userDto.IdentityCardNumber = dataReader.GetString(13);
                    userDto.Pesel = dataReader.GetString(14);
                    userDto.DriversLicense = dataReader.GetString(15);
                    userDto.Login = dataReader.GetString(16);
                    userDto.Password = dataReader.GetString(17);

                    connection.Close();
                    return new User(userDto);
                }
                else
                {
                    connection.Close();
                    return new User();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new User();
        }

        public static void AddUser(UserDto userDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "INSERT INTO projekt_bazy_danych.uzytkownik VALUES(null, \"" +
                                userDto.Permissions +
                                 "\",\"" +
                                userDto.Name +
                                "\",\"" +
                                userDto.LastName +
                                "\",\"" +
                                userDto.Phone +
                                "\",\"" +
                                userDto.City +
                                "\",\"" +
                                userDto.ZipCode +
                                "\",\"" +
                                userDto.Street +
                                "\",\"" +
                                userDto.BuildingNumber +
                                "\",\"" +
                                userDto.ApartmentNumber +
                                "\",\"" +
                                userDto.Birthplace +
                                 "\",\"" +
                                userDto.DateOfBirth +
                                "\",\"" +
                                userDto.Gender +
                                 "\",\"" +
                                userDto.IdentityCardNumber +
                                 "\",\"" +
                                userDto.Pesel +
                                 "\",\"" +
                                userDto.DriversLicense +
                                 "\",\"" +
                                userDto.Login +
                                "\",\"" +
                                userDto.Password +
                                "\");";

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie dodano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void UpdateUser(UserDto userDto)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.uzytkownik " +
                               "SET imie = \"" +
                                userDto.Name +
                                "\", nazwisko = \"" +
                                userDto.LastName +
                                "\", telefon = \"" +
                                userDto.Phone +
                                "\", miejscowosc = \"" +
                                userDto.City +
                                "\", kod_pocztowy = \"" +
                                userDto.ZipCode +
                                "\", ulica = \"" +
                                userDto.Street +
                                "\", nr_budynku = \"" +
                                userDto.BuildingNumber +
                                "\", nr_lokalu = \"" +
                                userDto.ApartmentNumber +
                                "\", miejsce_urodzenia = \"" +
                                userDto.Birthplace +
                                "\", data_urodzenia = \"" +
                                userDto.DateOfBirth +
                                "\", plec = \"" +
                                userDto.Gender +
                                "\", nr_dowodu = \"" +
                                userDto.IdentityCardNumber +
                                "\", pesel = \"" +
                                userDto.Pesel +
                                "\", prawo_jazdy = \"" +
                                userDto.DriversLicense +
                                "\" WHERE id = " +
                                userDto.Id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static IList<string> GetUsersNameList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<string>();
            string pom = "";

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT nazwisko, imie FROM projekt_bazy_danych.uzytkownik;";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = dataReader.GetString(0) + " " + dataReader.GetString(1);
                    list.Add(pom);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static IList<string> GetKeeperNameList()
        {
            var connectionString = Functions.GetConnectionString();
            var list = new List<string>();
            string pom = "";

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                const string query = "SELECT nazwisko, imie FROM projekt_bazy_danych.uzytkownik WHERE uzytkownik.uprawnienia = \"O\"";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = dataReader.GetString(0) + " " + dataReader.GetString(1);
                    list.Add(pom);
                }
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        public static string GetUserNameById(int id)
        {
            var connectionString = Functions.GetConnectionString();
            string name = "";

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT nazwisko, imie FROM projekt_bazy_danych.uzytkownik where uzytkownik.id = " + id;
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    name = dataReader.GetString(0) + " " + dataReader.GetString(1);
                    connection.Close();
                    return name;
                }
                else
                {
                    connection.Close();
                    return name;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return name;
        }

        public static int GetUserIdByName(string name, string lastName)
        {
            var connectionString = Functions.GetConnectionString();
            int id = 0;

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.uzytkownik where uzytkownik.imie = \"" + name + "\" AND uzytkownik.nazwisko = \"" + lastName + "\"";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                    connection.Close();
                    return id;
                }
                else
                {
                    connection.Close();
                    return id;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }

        public static void SetKeeper(int id)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.uzytkownik " +
                               "SET uprawnienia = \"O\" WHERE id = " +
                                id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano użytkownika");
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        public static void SetDriver(int id)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.uzytkownik " +
                               "SET uprawnienia = \"K\" WHERE id = " +
                                id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie edytowano użytkownika");
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
