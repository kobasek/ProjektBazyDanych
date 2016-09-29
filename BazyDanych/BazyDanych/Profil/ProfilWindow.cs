using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
    /// <summary>
    /// Klasa formularza wyświatlającego okno profilu użytkownika
    /// </summary>
    public partial class ProfilWindow : Form
    {
        private User user;
        private int id;
        /// <summary>
        /// Dwuparametrowy konstruktor klasy formularza wyświatlającego okno profilu użytkownika
        /// </summary>
        /// <param name="mainWindow">Uchwyt do okna głównego aplikacji</param>
        /// <param name="userID">ID użytkownika, którego profil jest wyświetlany</param>
        public ProfilWindow(MainWindow mainWindow, int userID)
        {
            InitializeComponent();
            main = mainWindow;
            id = userID;
            EditProfileInitialize(userID);
        }
        /// <summary>
        /// Bezparametrowy konstruktor klasy formularza wyświatlającego okno profilu użytkownika
        /// </summary>
        public ProfilWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja inicjalizująca pola formularza wyświatlającego okno profilu użytkownika
        /// </summary>
        /// <param name="userID">ID użytkownika, którego profil jest wyświetlany</param>
        public void EditProfileInitialize(int userID)
        {
            user = User.GetUserById(userID);
            textBox1.Text = user.name;
            textBox2.Text = user.lastName;
            textBox3.Text = user.phone;
            textBox4.Text = user.street;
            textBox5.Text = user.buildingNumber.ToString();
            textBox6.Text = user.apartmentNumber.ToString();
            textBox7.Text = user.city;
            textBox8.Text = user.zipCode;
            dateTimePicker1.Value = user.dateOfBirth;
        }

        /// <summary>
        /// Event Handler dla przycisku włączającego okno zmiany hasła
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ChangingPassword obj = new ChangingPassword(id);
            obj.Show();
        }

        /// <summary>
        /// Event Handler dla przycisku zamykającego okno profilu użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event Handler dla przycisku akceptującego zmianę danych profilowych. Po walidacji danych, jeśli wszystko jest poprawne następuje aktualizacja bazy danych, oraz listy użytkowników wyświetlanej w głównym okni programu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var userDto = new UserDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            userDto.Id = user.id;

            if (textBox1.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj imię.\n";
            }
            else
            {
                userDto.Name = textBox1.Text;
            }

            if (textBox2.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwisko.\n";
            }
            else
            {
                userDto.LastName = textBox2.Text;
            }

            if (textBox3.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer telefonu.\n";
            }
            else
            {
                userDto.Phone = textBox3.Text;
            }

            if (textBox4.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę ulicy.\n";
            }
            else
            {
                userDto.Street = textBox4.Text;
            }

            if (textBox5.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer budynku.\n";
            }
            else
            {
                userDto.BuildingNumber = Int32.Parse(textBox5.Text);
            }

            if (textBox6.Text == "")
            {
                userDto.ApartmentNumber = null;
            }
            else
            {
                userDto.ApartmentNumber = Int32.Parse(textBox6.Text);
            }

            if (textBox7.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwe miejscowości.\n";
            }
            else
            {
                userDto.City = textBox7.Text;
            }

            if (textBox8.TextLength == 6)
            {
                userDto.ZipCode = textBox8.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Niepoprawny kod pocztowy.\n";
            }

            userDto.DateOfBirth = dateTimePicker1.Value;

            userDto.Birthplace = user.birthplace;

            userDto.IdentityCardNumber = user.identityCardNumber;

            userDto.Pesel = user.pesel;

            userDto.Gender = user.gender;

            userDto.Password = user.password;
            userDto.Login = user.login;

            userDto.Permissions = user.permissions;

            userDto.DriversLicense = user.driversLicense;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    User.UpdateUser(userDto);
                    main.UpdateUser(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Edytowanie profilu nie powiodło się!");
                    throw (ex);
                }

            }
        }
    }
}
