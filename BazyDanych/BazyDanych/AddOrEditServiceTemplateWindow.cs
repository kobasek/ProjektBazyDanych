﻿using System;
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
    public partial class AddOrEditServiceTemplateWindow : Form
    {
        private MainWindow mainWindow;
        private ServiceTemplate serviceTemplate;

        public AddOrEditServiceTemplateWindow()
        {
            InitializeComponent();
        }
        public AddOrEditServiceTemplateWindow(MainWindow mainWindow)
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
            var templatesList = Template.GetTemplatesList();
            foreach (var template in templatesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = template.name;
                comboBoxItem.Value = template.id;
                templateComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
        }

        public AddOrEditServiceTemplateWindow(MainWindow mainWindow, int serviceTemplateId)
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
            var templatesList = Template.GetTemplatesList();
            foreach (var template in templatesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = template.name;
                comboBoxItem.Value = template.id;
                templateComboBox.Items.Add(comboBoxItem);
            }
            this.mainWindow = mainWindow;
            serviceTemplate = ServiceTemplate.GetServiceTemplateById(serviceTemplateId);
            nameTextBox.Text = serviceTemplate.name;
            KilometresNumericUpDown.Value = serviceTemplate.kilometres;
            periodNumericUpDown.Value = serviceTemplate.period;
            catalogComboBox.SelectedValue = serviceTemplate.catalogId;
            templateComboBox.SelectedValue = serviceTemplate.templateId;
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            var errorNumber = 0;
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

            }
        }

        private void acceptButton_Click_1(object sender, EventArgs e)
        {
            var serviceTemplateDto = new ServiceTemplateDto();
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
            }
        }
    }
}
