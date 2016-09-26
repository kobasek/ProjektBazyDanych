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
    public partial class AddOrEditServiceWindow : Form
    {
        private MainWindow mainWindow;
        private Service service;

        public AddOrEditServiceWindow()
        {
            InitializeComponent();
        }

        public AddOrEditServiceWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var servicePlacesList = ServicePlace.GetServicePlacesList();
            foreach (var servicePlace in servicePlacesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = servicePlace.companyName + " " + servicePlace.address;
                comboBoxItem.Value = servicePlace.id;
                servicePlaceComboBox.Items.Add(comboBoxItem);
            }
            var ordersList = Order.GetOrderList();
            foreach (var order in ordersList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = order.id + " " + User.GetUserById(order.userId).name + " " + User.GetUserById(order.userId).lastName;
                comboBoxItem.Value = order.id;
                orderComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
        }

        public AddOrEditServiceWindow(MainWindow mainWindow, int serviceId)
        {
            InitializeComponent();
            var servicePlacesList = ServicePlace.GetServicePlacesList();
            foreach (var servicePlace in servicePlacesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = servicePlace.companyName + " " + servicePlace.address;
                comboBoxItem.Value = servicePlace.id;
                servicePlaceComboBox.Items.Add(comboBoxItem);
            }
            var ordersList = Order.GetOrderList();
            foreach (var order in ordersList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = order.id + " " + User.GetUserById(order.userId).name + " " + User.GetUserById(order.userId).lastName;
                comboBoxItem.Value = order.id;
                orderComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
            service = Service.GetServiceById(serviceId);
            servicePlaceComboBox.SelectedValue = service.id;
            serviceDateDateTimePicker.Value = service.serviceDate;
            serviceCostNumericUpDown.Value = service.cost;
            commentRichTextBox.Text = service.comment;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var serviceDto = new ServiceDto();

            if (servicePlaceComboBox.SelectedItem != null)
            {
                serviceDto.ServicePlaceId = (int)((ComboBoxItem)servicePlaceComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać miejsce serwisu.\n";
            }

            if (orderComboBox.SelectedItem != null)
            {
                serviceDto.OrderId = (int)((ComboBoxItem)orderComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać zlecenie.\n";
            }

            serviceDto.ServiceDate = serviceDateDateTimePicker.Value;

            if (serviceCostNumericUpDown.Value > 0)
            {
                serviceDto.Cost = serviceCostNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }

            serviceDto.Comment = commentRichTextBox.Text;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddServiceToDatabase(serviceDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Dodawanie serwisu nie powiodło się!");
                }

            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var serviceDto = new ServiceDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            serviceDto.Id = service.id;

            if (servicePlaceComboBox.SelectedItem != null)
            {
                serviceDto.ServicePlaceId = (int)((ComboBoxItem)servicePlaceComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać miejsce serwisu.\n";
            }

            if (orderComboBox.SelectedItem != null)
            {
                serviceDto.OrderId = (int)((ComboBoxItem)orderComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać zlecenie.\n";
            }

            serviceDto.ServiceDate = serviceDateDateTimePicker.Value;

            if (serviceCostNumericUpDown.Value > 0)
            {
                serviceDto.Cost = serviceCostNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }

            serviceDto.Comment = commentRichTextBox.Text;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Service.UpdateService(serviceDto);
                    mainWindow.UpdateService();
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Edytowanie serwisu nie powiodło się!");
                }
            }
        }
    }
}