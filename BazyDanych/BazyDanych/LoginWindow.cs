using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa formularza odpowiedzialnego za logowanie do systemu
    /// </summary>
    public partial class LoginWindow : Form
    {
        private MainWindow obj;
        private int id;
        private char permission;

        /// <summary>
        /// Jednoargumentowy konstruktor klasy formularza odpowiedzialnego za logowanie do systemu
        /// </summary>
        /// <param name="obj">Uchwyt do głównego okna programu</param>
        public LoginWindow(MainWindow obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        /// <summary>
        /// Event handler dla przycisku zaloguj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            var connectionString = Functions.GetConnectionString();
            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id, uprawnienia FROM projekt_bazy_danych.uzytkownik WHERE uzytkownik.login = \"" + usernameTextBox.Text + "\" AND uzytkownik.haslo = \"" + passwordTextBox.Text+"\"";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                    permission = dataReader.GetChar(1);
                }
                else
                    id = 0;
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(id == 0)
            {
                MessageBox.Show("Podany login bądź hasło są błędne");
            }
            else if (permission == 'M')
            {
                obj.InitializeComponentMenadzer(id);
          
                this.Close();
            }
            else if (permission == 'O')
            {
                obj.InitializeComponentOpieka(id);
                this.Close();
            }

            else if (permission == 'K')
            {
                obj.InitializeComponentKierowca(id);
                this.Close();
            }
        }
    }
}
