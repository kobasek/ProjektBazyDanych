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
    /// Klasa formularza wyświetlającego okno dodawania/edycji zlecenia
    /// </summary>
    public partial class AddOrEditOrderWindow : Form
    {
        private MainWindow mainWindow;
        private Order order;

        public List<ServiceDto> services = new List<ServiceDto>();

        public AddOrEditOrderWindow()
        {
            InitializeComponent();
        }
        public AddOrEditOrderWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var careList = Care.GetActiveCareList();
            foreach (var care in careList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = care.id + " " + User.GetUserById(care.keeperId).name + " " + User.GetUserById(care.keeperId).lastName + " " + User.GetUserById(care.keeperId).pesel + " " + Brand.GetBrandById(Model.GetModelById(Car.GetCarById(care.carId).modelId).brandId).name + " " + Model.GetModelById(Car.GetCarById(care.carId).modelId).name;
                comboBoxItem.Value = care.id;
                careComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName + " " + driver.pesel;
                comboBoxItem.Value = driver.id;
                driverComboBox.Items.Add(comboBoxItem);
            }
            orderTypeComboBox.Items.Add("1. Rodzaj");
            orderTypeComboBox.Items.Add("2. Rodzaj");
            orderTypeComboBox.Items.Add("3. Rodzaj");

            orderStateComboBox.Items.Add("Aktywny");
            orderStateComboBox.Items.Add("Zakończony");
            orderStateComboBox.Items.Add("Odwołany");

            orderStateComboBox.Text = "Aktywny";

            this.mainWindow = mainWindow;
        }

        public AddOrEditOrderWindow(MainWindow mainWindow, int orderId)
        {
            InitializeComponent();
            var careList = Care.GetActiveCareList();
            foreach (var care in careList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = care.id + " " + User.GetUserById(care.keeperId).name + " " + User.GetUserById(care.keeperId).lastName + " " + User.GetUserById(care.keeperId).pesel + " " + Brand.GetBrandById(Model.GetModelById(Car.GetCarById(care.carId).modelId).brandId).name + " " + Model.GetModelById(Car.GetCarById(care.carId).modelId).name;
                comboBoxItem.Value = care.id;
                careComboBox.Items.Add(comboBoxItem);
            }
            var driversList = User.GetUserList();
            foreach (var driver in driversList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = driver.name + " " + driver.lastName + " " + driver.pesel;
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
            IList<Service> services = Service.GetServiceListWithGivenOrderId(orderId);
            servicesBindingSource.Clear();
            foreach (Service service in services)
            {
                servicesBindingSource.Add(new ServiceTableElement(service.id, service.cost, service.serviceDate, service.comment, service.servicePlaceId, service.orderId));
            }
            order = Order.GetOrderById(orderId);
            startDateDateTimePicker.Value = order.plannedStartDate;
            endDateDateTimePicker.Value = order.plannedEndDate;
            if (order.state == 'z')
            {
                actualStartDateDateTimePicker.Value = (DateTime)order.actualStartDate;
                actualEndDateDateTimePicker.Value = (DateTime)order.actualEndDate;
                counterStartStateNumericUpDown.Value = (int)order.counterStatusBefore;
                counterEndDateNumericUpDown.Value = (int)order.counterStatusAfter;
                costNumericUpDown.Value = (decimal)order.cost;
            }
            startCommentsRichTextBox.Text = order.commentsBefore;
            endCommentsRichTextBox.Text = order.commentsAfter;
            switch (order.type)
            {
                case '1':
                    orderTypeComboBox.Text = "1. Rodzaj";
                    break;
                case '2':
                    orderTypeComboBox.Text = "2. Rodzaj";
                    break;
                case '3':
                    orderTypeComboBox.Text = "3. Rodzaj";
                    break;

            }
            cancellationReasonRichTextBox.Text = order.cancellationReason;
            orderStateComboBox.SelectedItem = order.state;
            switch (order.state)
            {
                case 'a':
                    orderStateComboBox.Text = "Aktywny";
                    break;
                case 'z':
                    orderStateComboBox.Text = "Zakończony";
                    break;
                case 'o':
                    orderStateComboBox.Text = "Odwołany";
                    break;
            }
            driverComboBox.Text = User.GetUserById(order.userId).name + " " + User.GetUserById(order.userId).lastName + " " + User.GetUserById(order.userId).pesel;
            Care careItem = Care.GetCareByID(order.careId);
            careComboBox.Text = careItem.id + " " + User.GetUserById(careItem.keeperId).name + " " + User.GetUserById(careItem.keeperId).lastName + " " + User.GetUserById(careItem.keeperId).pesel + " " + Brand.GetBrandById(Model.GetModelById(Car.GetCarById(careItem.carId).modelId).brandId).name + " " + Model.GetModelById(Car.GetCarById(careItem.carId).modelId).name;
        }

        public void UpdateServicesGridView()
        {
            servicesBindingSource.Clear();
            foreach (var service in services)
            {
                servicesBindingSource.Add(new ServiceTableElement(service.Id, service.Cost, service.ServiceDate, service.Comment, service.ServicePlaceId, service.OrderId));
            }
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
            if (orderStateComboBox.Text == "Zakończony")
            {
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
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
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

            if (orderStateComboBox.Text == "Zakończony")
            {
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
            }

            orderDto.PlannedStartDate = startDateDateTimePicker.Value;
            orderDto.PlannedEndDate = endDateDateTimePicker.Value;

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
                    int orderId = mainWindow.AddOrderToDatabase(orderDto);
                    foreach (ServiceDto service in services)
                    {
                        service.OrderId = orderId;
                        Service.AddServiceWithServiceActions(service);
                    }
                    mainWindow.UpdateOrder();
                    mainWindow.UpdateService();
                    mainWindow.UpdateServiceAction();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
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

        private void addServiceButton_Click(object sender, EventArgs e)
        {
            AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this);
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void servicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (addButton.Visible)
                {
                    var row = e.RowIndex;
                    AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(mainWindow, services[row].ServicePlaceId);
                    obj.addButton.Visible = false;
                    obj.approveButton.Visible = false;
                    obj.companyNameTextBox.ReadOnly = true;
                    obj.addressTextBox.ReadOnly = true;
                    obj.Text = "Menedżer Floty - Szczegóły miejsca serwisowego";
                    obj.Show();
                }
                else
                {
                    var row = e.RowIndex;
                    ServiceTableElement serviceTableElement = (ServiceTableElement)servicesBindingSource.List[row];
                    var serviced = serviceTableElement.Id;
                    int servicePlaceId = Service.GetServiceById(serviced).servicePlaceId;
                    ServicePlace servicePlace = ServicePlace.GetServicePlaceById(servicePlaceId);
                    AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow();
                    obj.companyNameTextBox.Text = servicePlace.companyName;
                    obj.addressTextBox.Text = servicePlace.address;
                    obj.addButton.Visible = false;
                    obj.approveButton.Visible = false;
                    obj.companyNameTextBox.ReadOnly = true;
                    obj.addressTextBox.ReadOnly = true;
                    obj.Show();
                }
            }
            if (e.ColumnIndex == 4)
            {
                if (addButton.Visible)
                {
                    var row = e.RowIndex;
                    ServiceDetails obj = new ServiceDetails();
                    ServiceDto service = services[row];
                    obj.placeTextBox.Text = ServicePlace.GetServicePlaceById(service.ServicePlaceId).companyName + " " + ServicePlace.GetServicePlaceById(service.ServicePlaceId).address;
                    obj.DateDateTimePicker.Value = service.ServiceDate;
                    obj.costTextBox.Text = service.Cost.ToString();
                    obj.commentRichTextBox.Text = service.Comment;
                    obj.serviceActionsBindingSource.Clear();
                    List<ServiceActionDto> serviceActionsList = service.serviceActions;
                    foreach (ServiceActionDto serviceActionDto in serviceActionsList)
                    {
                        obj.serviceActionsBindingSource.Add(new ServiceActionTableElement(serviceActionDto.Id, serviceActionDto.Name, serviceActionDto.Cost, serviceActionDto.CatalogId, serviceActionDto.ServiceId));
                    }
                    obj.Show();
                }
                else
                {
                    var row = e.RowIndex;
                    ServiceTableElement serviceTableElement = (ServiceTableElement)servicesBindingSource.List[row];
                    var serviceId = serviceTableElement.Id;
                    ServiceDetails obj = new ServiceDetails(serviceId);
                    obj.Show();
                }
            }
        }

        private void orderStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderStateComboBox.Text == "Aktywny" || orderStateComboBox.Text == "")
            {
                actualEndDateDateTimePicker.Enabled = false;
                actualStartDateDateTimePicker.Enabled = false;
                costNumericUpDown.Enabled = false;
                counterStartStateNumericUpDown.Enabled = false;
                counterEndDateNumericUpDown.Enabled = false;
                endCommentsRichTextBox.Enabled = false;
                cancellationReasonRichTextBox.Enabled = false;
                cancellationReasonRichTextBox.Enabled = false;
            }
            else if (orderStateComboBox.Text == "Odwołany")
            {
                actualEndDateDateTimePicker.Enabled = false;
                actualStartDateDateTimePicker.Enabled = false;
                costNumericUpDown.Enabled = false;
                counterStartStateNumericUpDown.Enabled = false;
                counterEndDateNumericUpDown.Enabled = false;
                endCommentsRichTextBox.Enabled = false;
                cancellationReasonRichTextBox.Enabled = true;
            }
            else if (orderStateComboBox.Text == "Zakończony")
            {
                actualEndDateDateTimePicker.Enabled = true;
                actualStartDateDateTimePicker.Enabled = true;
                costNumericUpDown.Enabled = true;
                counterStartStateNumericUpDown.Enabled = true;
                counterEndDateNumericUpDown.Enabled = true;
                endCommentsRichTextBox.Enabled = true;
                cancellationReasonRichTextBox.Enabled = false;
            }
        }
    }
}
