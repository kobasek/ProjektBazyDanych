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
    public partial class AddOrEditOrderWindow : Form
    {
        private MainWindow mainWindow;
        private Order order;

        public AddOrEditOrderWindow()
        {
            InitializeComponent();
        }
        public AddOrEditOrderWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var carsList = Car.GetCarList();
            foreach (var car in carsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = car.id + " " + Brand.GetBrandById(Model.GetModelById(car.modelId).brandId).name + " " + Model.GetModelById(car.modelId).name;
                comboBoxItem.Value = car.id;
                carComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName;
                comboBoxItem.Value = driver.id;
                driverComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
        }

        public AddOrEditOrderWindow(MainWindow mainWindow, int orderId)
        {
            InitializeComponent();
            var carsList = Car.GetCarList();
            foreach (var car in carsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = car.id + " " + Brand.GetBrandById(Model.GetModelById(car.modelId).brandId).name + " " + Model.GetModelById(car.modelId).name;
                comboBoxItem.Value = car.id;
                carComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName;
                comboBoxItem.Value = driver.id;
                driverComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
            order = Order.GetOrderById(orderId);
            startDateDateTimePicker.Value = order.plannedStartDate;
            endDateDateTimePicker.Value = order.plannedEndDate;
            actualStartDateDateTimePicker.Value = order.actualStartDate;
            actualEndDateDateTimePicker.Value = order.actualEndDate;
            counterStartStateNumericUpDown.Value = order.counterStatusBefore;
            counterEndDateNumericUpDown.Value = order.counterStatusAfter;
            startCommentsRichTextBox.Text = order.commentsBefore;
            endCommentsRichTextBox.Text = order.commentsAfter;
            orderTypeComboBox.SelectedItem = order.type;
            costNumericUpDown.Value = order.cost;
            cancellationReasonRichTextBox.Text = order.cancellationReason;
            orderStateComboBox.SelectedItem = order.state;
            driverComboBox.SelectedItem = User.GetUserById(order.userId);
            carComboBox.SelectedItem = Brand.GetBrandById(Model.GetModelById(Car.GetCarById(Care.GetCareByID(order.careId).carId).modelId).brandId) + " " + Model.GetModelById(Car.GetCarById(Care.GetCareByID(order.careId).carId).modelId).name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*var serviceTemplateDto = new ServiceTemplateDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            serviceTemplateDto.Id = serviceTemplate.id;

            if (nameTextBox.Text != "")
            {
                serviceTemplateDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę szablonu serwisowego.\n";
            }

            if (KilometresNumericUpDown.Value > 0)
            {
                serviceTemplateDto.Kilometres = (int)KilometresNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać liczbę kilometrów większą od zera.\n";
            }

            if (periodNumericUpDown.Value > 0)
            {
                serviceTemplateDto.Period = (int)periodNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać okres większy od zera.\n";
            }
            if (catalogComboBox.SelectedItem != null)
            {
                serviceTemplateDto.CatalogId = (int)catalogComboBox.SelectedValue;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać katalog.\n";
            }
            if (templateComboBox.SelectedItem != null)
            {
                serviceTemplateDto.TemplateId = (int)templateComboBox.SelectedValue;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać szablon.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    ServiceTemplate.UpdateServiceTemplate(serviceTemplateDto);
                    mainWindow.UpdateServiceTemplate();
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Edytowanie szablonu serwisowego nie powiodło się!");
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var serviceTemplateDto = new ServiceTemplateDto();

            if (nameTextBox.Text != "")
            {
                serviceTemplateDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę szablonu serwisowego.\n";
            }

            if (KilometresNumericUpDown.Value > 0)
            {
                serviceTemplateDto.Kilometres = (int)KilometresNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać liczbę kilometrów większą od zera.\n";
            }

            if (periodNumericUpDown.Value > 0)
            {
                serviceTemplateDto.Period = (int)periodNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać okres większy od zera.\n";
            }
            if (catalogComboBox.SelectedItem != null)
            {
                serviceTemplateDto.CatalogId = (int)((ComboBoxItem)catalogComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać katalog.\n";
            }
            if (templateComboBox.SelectedItem != null)
            {
                serviceTemplateDto.TemplateId = (int)((ComboBoxItem)templateComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać szablon.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddServiceTemplateToDatabase(serviceTemplateDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Dodawanie szablonu serwisowego nie powiodło się!");
                }

            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddServiceWindow obj = new AddServiceWindow();
            obj.Show();
        }
    }
}
