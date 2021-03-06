﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    /// <summary>
    /// Klasa formularza wyświetlającego okno do zmiany hasła
    /// </summary>
    public partial class ChangingPassword : Form
    {
        private User user;
        
        /// <summary>
        /// Jednoargumentowy konstruktor klasy formularza wyświetlającego okno do zmiany hasła
        /// </summary>
        /// <param name="userID"></param>
        public ChangingPassword(int userID)
        {
            user = User.GetUserById(userID);
            InitializeComponent();
        }

        /// <summary>
        /// Event Handler przycisku potwierdzającego zmianę hasła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = Functions.GetConnectionString();
            int id = 0;
            try
            {
                var connection = new MySql.Data.MySqlClient.MySqlConnection { ConnectionString = connectionString };
                connection.Open();

                string query = "SELECT id FROM projekt_bazy_danych.uzytkownik WHERE uzytkownik.login = \"" + user.login + "\" AND uzytkownik.haslo = \"" + textBox1.Text.ToString() + "\"";
                var command = new MySqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }
                else
                    id = 0;
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (id == 0)
                MessageBox.Show("Błędne hasło");
            else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Podaj 2 razy takie samo hasło");
            }
            else
            {
                User.ChangeUserPassword(user.id, textBox2.Text.ToString());
            }

            this.Close();
        }

        /// <summary>
        /// Event handler przycisku anuluj w oknie zmiany hasła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
