using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa przechowywująca informacje o użytkowniku
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID użytkownika
        /// </summary>
        public int id;

        /// <summary>
        /// Prawa dostępu użytkownika
        /// </summary>
        public char permissions;

        /// <summary>
        /// Imię użytkownika
        /// </summary>
        public string name;

        /// <summary>
        /// Nazwisko użytkownika
        /// </summary>
        public string lastName;

        /// <summary>
        /// Telefon użytkownika
        /// </summary>
        public string phone;

        /// <summary>
        /// Miasto, w którym mieszka użytkownik
        /// </summary>
        public string city;

        /// <summary>
        /// Ulica, na której mieszka użytkownik
        /// </summary>
        public string street;

        /// <summary>
        /// Kod pocztowy użytkownika
        /// </summary>
        public string zipCode;

        /// <summary>
        /// Nr budynku, w którym mieszka użytkownik
        /// </summary>
        public int buildingNumber;

        /// <summary>
        /// Nr mieszkania, w któym mieszka użytkownik
        /// </summary>
        public int? apartmentNumber;

        /// <summary>
        /// Miejsce urodzenia użytkownika
        /// </summary>
        public string birthplace;

        /// <summary>
        /// Data urodzenia użytkownika
        /// </summary>
        public DateTime dateOfBirth;

        /// <summary>
        /// Płeć użytkownika
        /// </summary>
        public char gender;

        /// <summary>
        /// Nr dowodu osobistego użytkownika
        /// </summary>
        public string identityCardNumber;

        /// <summary>
        /// Pesel użytkownika
        /// </summary>
        public string pesel;

        /// <summary>
        /// Nr prawa jazdy użytkownika
        /// </summary>
        public string driversLicense;

        /// <summary>
        /// Login użytkownika
        /// </summary>
        public string login;

        /// <summary>
        /// Hasło użytkownika
        /// </summary>
        public string password;

        /// <summary>
        /// Jednoargumentowy konstruktor klasy zawierającej informacje o użytkowniku
        /// </summary>
        /// <param name="userDto">Obiekt reprezentujący użytkownika</param>
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

        /// <summary>
        /// Bezargumentowy konstruktor klasy zawierającej informacje o użytkowniku
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Metoda pobierająca listę użytkowników z bazy
        /// </summary>
        /// <returns>Lista użytkowników z bazy</returns>
        public static IList<User> GetUserList()
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
                    userDto.Pesel = dataReader.GetString(14);

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

        /// <summary>
        /// Metoda pobierająca dane użytkownika
        /// </summary>
        /// <param name="id">ID użytkownika, któego dane chcemy pobrać</param>
        /// <returns>Dane użytkownika o podanym w parametrze ID</returns>
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

        /// <summary>
        /// Zapis danych użytkownika do bazy
        /// </summary>
        /// <param name="userDto">Obiekt reprezentujący dane użytkownika</param>
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

        /// <summary>
        /// Aktualizacja danych użytkownika w bazie
        /// </summary>
        /// <param name="userDto">Obiekt reprezentujący zaktualizowane dane użytkownika do zapisania w bazie</param>
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

        /// <summary>
        /// Funkcja pobierająca listę imion i nazwisk użytkowników z bazy
        /// </summary>
        /// <returns>Lista imion i nazwisk uzytkowników z bazy w formacie: 'Nazwisko Imię'</returns>
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

        /// <summary>
        /// Metoda zwracająca listę opiekunów z bazy
        /// </summary>
        /// <returns>Lista opiekunów</returns>
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

        /// <summary>
        /// Metoda pobierająca imię i nazwisko konkretnego użytkownika z bazy
        /// </summary>
        /// <param name="id">ID użytkownika, którego imienia i nazwiska potrzebujemy</param>
        /// <returns>Imię i nazwisko użytkownika w formacie: 'Nazwisko Imię'</returns>
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

        /// <summary>
        /// Metoda zwracająca ID użytkownika na podstawie jego danych
        /// </summary>
        /// <param name="name">Imię użytkownika</param>
        /// <param name="lastName">Nazwisko użytkownika</param>
        /// <returns>ID użytkownika</returns>
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

        /// <summary>
        /// Metoda nadająca użytkownikowi prawa opiekuna
        /// </summary>
        /// <param name="id">ID użytkownika, któremu chcemy nadac prawa</param>
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

        /// <summary>
        /// Metoda użytkownikowi prawa kierowcy
        /// </summary>
        /// <param name="id">ID użytkownika, któremu chcemy nadać prawa</param>
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

        /// <summary>
        /// Metoda sprawdzająca zgodność loginu z hasłem w bazie
        /// </summary>
        /// <param name="id">ID użytkownika, którego hasło chcemy sprawdzić</param>
        /// <param name="password">HAsło do sprawdzenia</param>
        public static void ChangeUserPassword(int id, string password)
        {
            var connectionString = Functions.GetConnectionString();

            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "UPDATE projekt_bazy_danych.uzytkownik " +
                               "SET haslo = \"" + password + "\" WHERE id = " + id;

                var command = new MySqlCommand(query, connection);
                command.ExecuteReader();
                MessageBox.Show("Poprawnie zmieniono hasło");
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
