using System;
using System.Data;
using System.Windows.Forms;

namespace BazyDanych
{
    public partial class AddOrEditUserWindow : Form
    {
        private User user;

        public AddOrEditUserWindow(int userId)
        {
            InitializeComponent();
            EditInitialize(userId);
        }

        public AddOrEditUserWindow(int userId, string pom)
        {
            InitializeComponent();
            SzczegolyInitialize(userId);
        }

        public AddOrEditUserWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        public AddOrEditUserWindow()
        {
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var userDto = new UserDto();

            if (textBox2.Text=="" || textBox3.Text=="")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Imię i nazwisko są obowiązkowe.\n";
            }
            else
            {
                userDto.Name = textBox2.Text;
                userDto.LastName = textBox3.Text;
            }

            if (textBox10.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer telefonu.\n";
            }
            else
            {
                userDto.Phone = textBox10.Text;
            }

            if (textBox1.TextLength == 6)
            {
                userDto.ZipCode = textBox1.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Niepoprawny kod pocztowy.\n";
            }

            if (textBox6.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwe miejscowości.\n";
            }
            else
            {
                userDto.City = textBox6.Text;
            }

            if (textBox7.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę ulicy.\n";
            }
            else
            {
                userDto.Street = textBox7.Text;
            }

            if (textBox11.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer budynku.\n";
            }
            else
            {
                userDto.BuildingNumber = Int32.Parse(textBox11.Text);
            }

            if (textBox12.Text == "")
            {
                userDto.ApartmentNumber = null;
            }
            else
            {
                userDto.ApartmentNumber = Int32.Parse(textBox12.Text);
            }

            userDto.DateOfBirth = dateTimePicker1.Value;

            if (textBox13.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj miejsce urodzenia.\n";
            }
            else
            {
                userDto.Birthplace = textBox13.Text;
            }

            if (textBox4.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer dowodu osobistego.\n";
            }
            else
            {
                userDto.IdentityCardNumber = textBox4.Text;
            }

            if (textBox5.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer pesel.\n";
            }
            else
            {
                userDto.Pesel = textBox5.Text;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    userDto.Gender = 'M';
                    break;
                case 1:
                    userDto.Gender = 'K';
                    break;
                case 2:
                    userDto.Gender = 'I';
                    break;
            }

            if (textBox8.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj hasło.\n";
            }
            else
            {
                userDto.Password = textBox8.Text;
            }

            if (textBox9.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj login.\n";
            }
            else
            {
                userDto.Login = textBox9.Text;
            }

            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                int? id = indexChecked;
                switch (id)
                {
                    case 0:
                        userDto.DriversLicense += "B,";
                        break;
                    case 1:
                        userDto.DriversLicense += "BE,";
                        break;
                    case 2:
                        userDto.DriversLicense += "C,";
                        break;
                    case 3:
                        userDto.DriversLicense += "C1,";
                        break;
                    case 4:
                        userDto.DriversLicense += "C1E,";
                        break;
                    case 5:
                        userDto.DriversLicense += "CE,";
                        break;
                    case 6:
                        userDto.DriversLicense += "D,";
                        break;
                    case 7:
                        userDto.DriversLicense += "D1,";
                        break;
                    case 8:
                        userDto.DriversLicense += "D1E,";
                        break;
                    case 9:
                        userDto.DriversLicense += "DE,";
                        break;
                }
            }
            if (userDto.DriversLicense != "")
                userDto.DriversLicense = userDto.DriversLicense.Remove(userDto.DriversLicense.Length - 1);

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    userDto.Permissions = 'M';
                    break;
                case 1:
                    userDto.Permissions = 'O';
                    break;
                case 2:
                    userDto.Permissions = 'K';
                    break;
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    main.AddUserToDatabase(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Dodawanie pojazdu nie powiodło się!");
                    throw ex;
                }

            }
        }

        public void EditInitialize(int userId)
        {
            user = User.GetUserById(userId);

            textBox2.Text = user.name;
            textBox2.Enabled = false;
            textBox3.Text = user.lastName;
            textBox3.Enabled = false;
            textBox10.Text = user.phone;
            textBox1.Text = user.zipCode;
            textBox6.Text = user.city;
            textBox7.Text = user.street;
            textBox11.Text = user.buildingNumber.ToString();
            textBox12.Text = user.apartmentNumber.ToString();
            dateTimePicker1.Value = user.dateOfBirth;
            dateTimePicker1.Enabled = false;
            textBox13.Text = user.birthplace;
            textBox13.Enabled = false;
            textBox4.Text = user.identityCardNumber;
            textBox5.Text = user.pesel;
            textBox3.Enabled = false;

            switch (user.gender)
            {
                case 'M':
                    comboBox1.Text = "Mężczyzna";
                    comboBox1.Enabled = false;
                    break;
                case 'K':
                    comboBox1.Text = "Kobieta";
                    comboBox1.Enabled = false;
                    break;
                case 'I':
                    comboBox1.Text = "Inny";
                    comboBox1.Enabled = false;
                    break;
            }

            textBox8.Text = user.password;
            textBox8.Enabled = false;
            textBox9.Text = user.login;
            textBox9.Enabled = false;

            string[] table = user.driversLicense.Split(',');
            foreach(string pom in table)
            {
                switch (pom)
                {
                    case "B":
                        checkedListBox1.SetItemChecked(0, true);
                        break;
                    case "BE":
                        checkedListBox1.SetItemChecked(1, true);
                        break;
                    case "C":
                        checkedListBox1.SetItemChecked(2, true);
                        break;
                    case "C1":
                        checkedListBox1.SetItemChecked(3, true);
                        break;
                    case "C1E":
                        checkedListBox1.SetItemChecked(4, true);
                        break;
                    case "CE":
                        checkedListBox1.SetItemChecked(5, true);
                        break;
                    case "D":
                        checkedListBox1.SetItemChecked(6, true);
                        break;
                    case "D1":
                        checkedListBox1.SetItemChecked(7, true);
                        break;
                    case "D1E":
                        checkedListBox1.SetItemChecked(8, true);
                        break;
                    case "DE":
                        checkedListBox1.SetItemChecked(9, true);
                        break;
                }
            }
            if (user.driversLicense != "")
                user.driversLicense = user.driversLicense.Remove(user.driversLicense.Length - 1);


            switch (user.permissions)
            {
                case 'M':
                    comboBox2.Text = "Manager";
                    comboBox2.Enabled = false;
                    break;
                case 'O':
                    comboBox2.Text = "Opieka";
                    comboBox2.Enabled = false;
                    break;
                case 'K':
                    comboBox2.Text = "Kierowca";
                    comboBox2.Enabled = false;
                    break;
            }

        }

        public void SzczegolyInitialize(int userId)
        {
            user = User.GetUserById(userId);

            textBox2.Text = user.name;
            textBox2.Enabled = false;
            textBox3.Text = user.lastName;
            textBox3.Enabled = false;
            textBox10.Text = user.phone;
            textBox10.Enabled = false;
            textBox1.Text = user.zipCode;
            textBox1.Enabled = false;
            textBox6.Text = user.city;
            textBox6.Enabled = false;
            textBox7.Text = user.street;
            textBox7.Enabled = false;
            textBox11.Text = user.buildingNumber.ToString();
            textBox11.Enabled = false;
            textBox12.Text = user.apartmentNumber.ToString();
            textBox12.Enabled = false;
            dateTimePicker1.Value = user.dateOfBirth;
            dateTimePicker1.Enabled = false;
            textBox13.Text = user.birthplace;
            textBox13.Enabled = false;
            textBox4.Text = user.identityCardNumber;
            textBox4.Enabled = false;
            textBox5.Text = user.pesel;
            textBox5.Enabled = false;

            switch (user.gender)
            {
                case 'M':
                    comboBox1.Text = "Mężczyzna";
                    comboBox1.Enabled = false;
                    break;
                case 'K':
                    comboBox1.Text = "Kobieta";
                    comboBox1.Enabled = false;
                    break;
                case 'I':
                    comboBox1.Text = "Inny";
                    comboBox1.Enabled = false;
                    break;
            }

            textBox8.Text = user.password;
            textBox8.Enabled = false;
            textBox9.Text = user.login;
            textBox9.Enabled = false;

            string[] table = user.driversLicense.Split(',');
            foreach (string pom in table)
            {
                switch (pom)
                {
                    case "B":
                        checkedListBox1.SetItemChecked(0, true);
                        break;
                    case "BE":
                        checkedListBox1.SetItemChecked(1, true);
                        break;
                    case "C":
                        checkedListBox1.SetItemChecked(2, true);
                        break;
                    case "C1":
                        checkedListBox1.SetItemChecked(3, true);
                        break;
                    case "C1E":
                        checkedListBox1.SetItemChecked(4, true);
                        break;
                    case "CE":
                        checkedListBox1.SetItemChecked(5, true);
                        break;
                    case "D":
                        checkedListBox1.SetItemChecked(6, true);
                        break;
                    case "D1":
                        checkedListBox1.SetItemChecked(7, true);
                        break;
                    case "D1E":
                        checkedListBox1.SetItemChecked(8, true);
                        break;
                    case "DE":
                        checkedListBox1.SetItemChecked(9, true);
                        break;
                }
            }
            checkedListBox1.Enabled = false;

            switch (user.permissions)
            {
                case 'M':
                    comboBox2.Text = "Manager";
                    comboBox2.Enabled = false;
                    break;
                case 'O':
                    comboBox2.Text = "Opieka";
                    comboBox2.Enabled = false;
                    break;
                case 'K':
                    comboBox2.Text = "Kierowca";
                    comboBox2.Enabled = false;
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userDto = new UserDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            userDto.Id = user.id;
            userDto.Name = textBox2.Text;
            userDto.LastName = textBox3.Text;

            if (textBox10.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer telefonu.\n";
            }
            else
            {
                userDto.Phone = textBox10.Text;
            }

            if (textBox1.TextLength == 6)
            {
                userDto.ZipCode = textBox1.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Niepoprawny kod pocztowy.\n";
            }

            if (textBox6.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwe miejscowości.\n";
            }
            else
            {
                userDto.City = textBox6.Text;
            }

            if (textBox7.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę ulicy.\n";
            }
            else
            {
                userDto.Street = textBox7.Text;
            }

            if (textBox11.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer budynku.\n";
            }
            else
            {
                userDto.BuildingNumber = Int32.Parse(textBox11.Text);
            }

            if (textBox12.Text == "")
            {
                userDto.ApartmentNumber = null;
            }
            else
            {
                userDto.ApartmentNumber = Int32.Parse(textBox12.Text);
            }

            userDto.DateOfBirth = dateTimePicker1.Value;
            userDto.Birthplace = textBox13.Text;

            if (textBox4.Text == "")
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj numer dowodu osobistego.\n";
            }
            else
            {
                userDto.IdentityCardNumber = textBox4.Text;
            }

            userDto.Pesel = textBox5.Text;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    userDto.Gender = 'M';
                    break;
                case 1:
                    userDto.Gender = 'K';
                    break;
                case 2:
                    userDto.Gender = 'I';
                    break;
            }

            userDto.Password = textBox8.Text;
            userDto.Login = textBox9.Text;

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    userDto.Permissions = 'M';
                    break;
                case 1:
                    userDto.Permissions = 'O';
                    break;
                case 2:
                    userDto.Permissions = 'K';
                    break;
            }

            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                int? id = indexChecked;
                switch (id)
                {
                    case 0:
                        userDto.DriversLicense += "B,";
                        break;
                    case 1:
                        userDto.DriversLicense += "BE,";
                        break;
                    case 2:
                        userDto.DriversLicense += "C,";
                        break;
                    case 3:
                        userDto.DriversLicense += "C1,";
                        break;
                    case 4:
                        userDto.DriversLicense += "C1E,";
                        break;
                    case 5:
                        userDto.DriversLicense += "CE,";
                        break;
                    case 6:
                        userDto.DriversLicense += "D,";
                        break;
                    case 7:
                        userDto.DriversLicense += "D1,";
                        break;
                    case 8:
                        userDto.DriversLicense += "D1E,";
                        break;
                    case 9:
                        userDto.DriversLicense += "DE,";
                        break;
                }
            }
            if (userDto.DriversLicense != "") 
                userDto.DriversLicense = userDto.DriversLicense.Remove(userDto.DriversLicense.Length - 1);

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    User.UpdateUser(userDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Edytowanie pojazdu nie powiodło się!");
                    throw (ex);
                }

            }
        }
    }
}
