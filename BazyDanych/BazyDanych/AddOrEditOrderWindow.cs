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
            var careList = Care.GetCareList();
            foreach (var care in careList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = care.id + " " + Brand.GetBrandById(Model.GetModelById(Car.GetCarById(care.carId).modelId).brandId).name + " " + Model.GetModelById(Car.GetCarById(care.carId).modelId).name;
                comboBoxItem.Value = care.id;
                careComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName;
                comboBoxItem.Value = driver.id;
                driverComboBox.Items.Add(comboBoxItem);
            }
            orderTypeComboBox.Items.Add("1. Rodzaj");
            orderTypeComboBox.Items.Add("2. Rodzaj");
            orderTypeComboBox.Items.Add("3. Rodzaj");

            orderStateComboBox.Items.Add("Aktywny");
            orderStateComboBox.Items.Add("Zakończony");
            orderStateComboBox.Items.Add("Odwołany");

            this.mainWindow = mainWindow;
        }

        public AddOrEditOrderWindow(MainWindow mainWindow, int orderId)
        {
            InitializeComponent();
            var careList = Care.GetCareList();
            foreach (var care in careList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = care.id + " " + Brand.GetBrandById(Model.GetModelById(Car.GetCarById(care.carId).modelId).brandId).name + " " + Model.GetModelById(Car.GetCarById(care.carId).modelId).name;
                comboBoxItem.Value = care.id;
                careComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName;
                comboBoxItem.Value = driver.id;
                driverComboBox.Items.Add(comboBoxItem);
            }
            orderTypeComboBox.Items.Add("1. Rodzaj");
            orderTypeComboBox.Items.Add("2. Rodzaj");
            orderTypeComboBox.Items.Add("3. Rodzaj");

            orderStateComboBox.Items.Add("Aktywny");
            orderStateComboBox.Items.Add("Zakończony");
            orderStateComboBox.Items.Add("Odwołany");
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
            careComboBox.SelectedItem = Brand.GetBrandById(Model.GetModelById(Car.GetCarById(Care.GetCareByID(order.careId).carId).modelId).brandId) + " " + Model.GetModelById(Car.GetCarById(Care.GetCareByID(order.careId).carId).modelId).name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var orderDto = new OrderDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            orderDto.Id = order.id;

            if (careComboBox.SelectedItem != null)
            {
                orderDto.CareId = (int)((ComboBoxItem)careComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać opiekę.\n";
            }

            if (driverComboBox.SelectedItem != null)
            {
                orderDto.UserId = (int)((ComboBoxItem)driverComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać kierowcę.\n";
            }

            orderDto.PlannedStartDate = startDateDateTimePicker.Value;
            orderDto.PlannedEndDate = endDateDateTimePicker.Value;
            orderDto.ActualStartDate = actualStartDateDateTimePicker.Value;
            orderDto.ActualEndDate = actualEndDateDateTimePicker.Value;

            if (costNumericUpDown.Value > 0)
            {
                orderDto.Cost = costNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }

            if (orderTypeComboBox.SelectedItem != null)
            {
                switch (orderTypeComboBox.SelectedItem.ToString())
                {
                    case "1. Rodzaj":
                        orderDto.Type = '1';
                        break;
                    case "2. Rodzaj":
                        orderDto.Type = '2';
                        break;
                    case "3. Rodzaj":
                        orderDto.Type = '3';
                        break;
                }
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać rodzaj zlecenia.\n";
            }

            if (counterStartStateNumericUpDown.Value > 0)
            {
                orderDto.CounterStatusBefore = (int)counterStartStateNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać początkowy stan licznika.\n";
            }

            if (counterEndDateNumericUpDown.Value > 0)
            {
                orderDto.CounterStatusAfter = (int)counterEndDateNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać końcowy stan licznika.\n";
            }

            if (orderStateComboBox.SelectedItem != null)
            {
                switch (orderStateComboBox.SelectedItem.ToString())
                {
                    case "Aktywny":
                        orderDto.State = 'a';
                        break;
                    case "Zakończony":
                        orderDto.State = 'z';
                        break;
                    case "Odwołany":
                        orderDto.State = 'o';
                        break;
                }
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać stan zlecenia.\n";
            }

            orderDto.CommentsAfter = endCommentsRichTextBox.Text;
            orderDto.CommentsBefore = startCommentsRichTextBox.Text;
            orderDto.CancellationReason = cancellationReasonRichTextBox.Text;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Order.UpdateOrder(orderDto);
                    mainWindow.UpdateOrder();
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Edytowanie zlecenia nie powiodło się!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var orderDto = new OrderDto();

            if (careComboBox.SelectedItem != null)
            {
                orderDto.CareId = (int)((ComboBoxItem)careComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać opiekę.\n";
            }

            if (driverComboBox.SelectedItem != null)
            {
                orderDto.UserId = (int)((ComboBoxItem)driverComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać kierowcę.\n";
            }

            orderDto.PlannedStartDate = startDateDateTimePicker.Value;
            orderDto.PlannedEndDate = endDateDateTimePicker.Value;
            orderDto.ActualStartDate = actualStartDateDateTimePicker.Value;
            orderDto.ActualEndDate = actualEndDateDateTimePicker.Value;

            if (costNumericUpDown.Value > 0)
            {
                orderDto.Cost = costNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }

            if (orderTypeComboBox.SelectedItem != null)
            {
                switch (orderTypeComboBox.SelectedItem.ToString())
                {
                    case "1. Rodzaj":
                        orderDto.Type = '1';
                        break;
                    case "2. Rodzaj":
                        orderDto.Type = '2';
                        break;
                    case "3. Rodzaj":
                        orderDto.Type = '3';
                        break;
                }
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać rodzaj zlecenia.\n";
            }

            if (counterStartStateNumericUpDown.Value > 0)
            {
                orderDto.CounterStatusBefore = (int)counterStartStateNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać początkowy stan licznika.\n";
            }

            if (counterEndDateNumericUpDown.Value > 0)
            {
                orderDto.CounterStatusAfter = (int)counterEndDateNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać końcowy stan licznika.\n";
            }

            if (orderStateComboBox.SelectedItem != null)
            {
                switch (orderStateComboBox.SelectedItem.ToString())
                {
                    case "Aktywny":
                        orderDto.State = 'a';
                        break;
                    case "Zakończony":
                        orderDto.State = 'z';
                        break;
                    case "Odwołany":
                        orderDto.State = 'o';
                        break;
                }
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać stan zlecenia.\n";
            }

            orderDto.CommentsAfter = endCommentsRichTextBox.Text;
            orderDto.CommentsBefore = startCommentsRichTextBox.Text;
            orderDto.CancellationReason = cancellationReasonRichTextBox.Text;

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddOrderToDatabase(orderDto);
                    Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {

                    MessageBox.Show("Dodawanie zlecenia nie powiodło się!");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddServiceWindow obj = new AddServiceWindow();
            obj.Show();
        }
    }
}
