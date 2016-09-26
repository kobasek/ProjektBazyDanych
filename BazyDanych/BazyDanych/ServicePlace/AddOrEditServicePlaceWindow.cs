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
    public partial class AddOrEditServicePlaceWindow : Form
    {
        private MainWindow mainWindow;
        private ServicePlace servicePlace;

        public AddOrEditServicePlaceWindow()
        {
            InitializeComponent();
        }
        public AddOrEditServicePlaceWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        public AddOrEditServicePlaceWindow(MainWindow mainWindow, int servicePlaceId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            servicePlace = ServicePlace.GetServicePlaceById(servicePlaceId);
            ServicePlace servicePlaceToEdit = ServicePlace.GetServicePlaceById(servicePlaceId);
            companyNameTextBox.Text = servicePlaceToEdit.companyName;
            addressTextBox.Text = servicePlaceToEdit.address;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var servicePlaceDto = new ServicePlaceDto();

            if (companyNameTextBox.Text != "")
            {
                servicePlaceDto.CompanyName = companyNameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę firmy.\n";
            }

            if (addressTextBox.Text != "")
            {
                servicePlaceDto.Address = addressTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać adres.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddServicePlaceToDatabase(servicePlaceDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Dodawanie miejsca serwisowego nie powiodło się!");
                }

            }
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            var servicePlaceDto = new ServicePlaceDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            servicePlaceDto.Id = servicePlace.id;

            if (companyNameTextBox.Text != "")
            {
                servicePlaceDto.CompanyName = companyNameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę firmy.\n";
            }
            if (addressTextBox.Text != "")
            {
                servicePlaceDto.Address = addressTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj adres.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    ServicePlace.UpdateServicePlace(servicePlaceDto);
                    mainWindow.UpdateServicePlace();
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Edytowanie pojazdu nie powiodło się!");
                }
            }
        }
    }
}
