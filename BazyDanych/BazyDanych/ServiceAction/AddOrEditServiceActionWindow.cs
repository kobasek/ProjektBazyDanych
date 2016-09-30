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
    /// Klasa formularza wyświetlającego okno dodawania/edycji czynności serwisowej
    /// </summary>
    public partial class AddOrEditServiceActionWindow : Form
    {
        private MainWindow mainWindow;
        private AddOrEditServiceWindow addOrEditServiceWindow;
        private ServiceAction serviceAction;
        private bool addToDatabase = true;

        public AddOrEditServiceActionWindow()
        {
            InitializeComponent();
        }

        public AddOrEditServiceActionWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var catalogsList = Catalog.GetCatalogsList();
            foreach (var catalog in catalogsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = catalog.name;
                comboBoxItem.Value = catalog.id;
                catalogComboBox.Items.Add(comboBoxItem);
            }
            var servicesList = Service.GetServiceList();
            foreach (var service in servicesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = service.id + " " + ServicePlace.GetServicePlaceById(service.servicePlaceId).companyName;
                comboBoxItem.Value = service.id;
                serviceComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
        }

        public AddOrEditServiceActionWindow(AddOrEditServiceWindow addOrEditServiceWindow)
        {
            InitializeComponent();
            addToDatabase = false;
            var catalogsList = Catalog.GetCatalogsList();
            foreach (var catalog in catalogsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = catalog.name;
                comboBoxItem.Value = catalog.id;
                catalogComboBox.Items.Add(comboBoxItem);
            }
            serviceComboBox.Visible = false;
            this.addOrEditServiceWindow = addOrEditServiceWindow;
        }

        public AddOrEditServiceActionWindow(MainWindow mainWindow, int serviceActionId)
        {
            InitializeComponent();
            var catalogsList = Catalog.GetCatalogsList();
            foreach (var catalog in catalogsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = catalog.name;
                comboBoxItem.Value = catalog.id;
                catalogComboBox.Items.Add(comboBoxItem);
            }
            var servicesList = Service.GetServiceList();
            foreach (var service in servicesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = service.id + " " + ServicePlace.GetServicePlaceById(service.servicePlaceId).companyName;
                comboBoxItem.Value = service.id;
                serviceComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
            serviceAction = ServiceAction.GetServiceActionById(serviceActionId);
            NameTextBox.Text = serviceAction.name;
            costNumericUpDown.Value = serviceAction.cost;
            catalogComboBox.SelectedValue = serviceAction.catalogId;
            serviceComboBox.SelectedValue = serviceAction.serviceId;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var serviceActionDto = new ServiceActionDto();

            if (NameTextBox.Text != "")
            {
                serviceActionDto.Name = NameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę czynności serwisowej.\n";
            }

            if (costNumericUpDown.Value > 0)
            {
                serviceActionDto.Cost = (int)costNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }
            if (catalogComboBox.SelectedItem != null)
            {
                serviceActionDto.CatalogId = (int)((ComboBoxItem)catalogComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać katalog.\n";
            }
            if (addToDatabase)
            {
                if (serviceComboBox.SelectedItem != null)
                {
                    serviceActionDto.ServiceId = (int)((ComboBoxItem)serviceComboBox.SelectedItem).Value;
                }
                else
                {
                    isError = true;
                    errorNumber++;
                    errorMessage += errorNumber + ". Należy wybrać serwis.\n";
                }
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                if (addToDatabase)
                {
                    try
                    {
                        mainWindow.AddServiceActionToDatabase(serviceActionDto);
                        Close();
                    }
                    #pragma warning disable 0168
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    #pragma warning restore 0168
                    {

                        MessageBox.Show("Dodawanie czynności serwisowej nie powiodło się!");
                    }
                }
                else
                {
                    addOrEditServiceWindow.serviceActions.Add(serviceActionDto);
                    addOrEditServiceWindow.UpdateServiceActionsGridView();
                    Close();
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var serviceActionDto = new ServiceActionDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            serviceActionDto.Id = serviceAction.id;

            if (NameTextBox.Text != "")
            {
                serviceActionDto.Name = NameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę czynności serwisowej.\n";
            }

            if (costNumericUpDown.Value > 0)
            {
                serviceActionDto.Cost = (int)costNumericUpDown.Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać koszt większy od zera.\n";
            }
            if (catalogComboBox.SelectedItem != null)
            {
                serviceActionDto.CatalogId = (int)((ComboBoxItem)catalogComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać katalog.\n";
            }
            if (serviceComboBox.SelectedItem != null)
            {
                serviceActionDto.ServiceId = (int)((ComboBoxItem)serviceComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać serwis.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    ServiceAction.UpdateServiceAction(serviceActionDto);
                    mainWindow.UpdateServiceAction();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning disable 0168
                {
                    MessageBox.Show("Edytowanie czynności serwisowej nie powiodło się!");
                }
            }
        }
    }
}
