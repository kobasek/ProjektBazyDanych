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
    public partial class AddOrEditCareWindow : Form
    {
        private MainWindow mainWindow;
        private Care care;

        public AddOrEditCareWindow()
        {
            InitializeComponent();
        }

        public AddOrEditCareWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var usersList = User.GetUserList();
            foreach (var user in usersList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = user.name + " " + user.lastName;
                comboBoxItem.Value = user.id;
                userComboBox.Items.Add(comboBoxItem);
            }
            var carsList = Car.GetCarList();
            foreach (var car in carsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = Brand.GetBrandById(Model.GetModelById(car.modelId).brandId).name + " " + Model.GetModelById(car.modelId).name;
                comboBoxItem.Value = car.id;
                carComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
        }

        public AddOrEditCareWindow(MainWindow mainWindow, int careId)
        {
            InitializeComponent();
            var usersList = User.GetUserList();
            foreach (var user in usersList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = user.name + " " + user.lastName;
                comboBoxItem.Value = user.id;
                userComboBox.Items.Add(comboBoxItem);
            }
            var carsList = Car.GetCarList();
            foreach (var car in carsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = Brand.GetBrandById(Model.GetModelById(car.modelId).brandId).name + " " + Model.GetModelById(car.modelId).name;
                comboBoxItem.Value = car.id;
                carComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
            care = Care.GetCareByID(careId);
            startDateDateTimePicker.Value = care.startDate;
            endDateDateTimePicker.Value = care.endDate ?? DateTime.Now;
            userComboBox.SelectedValue = care.keeperId;
            carComboBox.SelectedValue = care.carId;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var careDto = new CareDto();

            careDto.StartDate = startDateDateTimePicker.Value;
            careDto.EndDate = endDateDateTimePicker.Value;
            if (userComboBox.SelectedItem != null)
            {
                careDto.KeeperId = (int)((ComboBoxItem)userComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać użytkownika.\n";
            }
            if (carComboBox.SelectedItem != null)
            {
                careDto.CarId = (int)((ComboBoxItem)carComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać samochód.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddCareToDatabase(careDto);
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {
                    MessageBox.Show("Dodawanie opieki nie powiodło się!");
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var careDto = new CareDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            careDto.Id = care.id;

            careDto.StartDate = startDateDateTimePicker.Value;
            careDto.EndDate = endDateDateTimePicker.Value;
            if (userComboBox.SelectedItem != null)
            {
                careDto.KeeperId = (int)((ComboBoxItem)userComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać użytkownika.\n";
            }
            if (carComboBox.SelectedItem != null)
            {
                careDto.CarId = (int)((ComboBoxItem)carComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać samochód.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Care.UpdateCare(careDto);
                    mainWindow.UpdateCare();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Edytowanie opieki nie powiodło się!");
                }
            }
        }
    }
}
