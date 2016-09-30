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
    /// Klasa formularza wyświetlającego okno dodawania/edycji modelu
    /// </summary>
    public partial class AddOrEditModelWindow : Form
    {
        private MainWindow mainWindow;
        private Model model;

        public AddOrEditModelWindow()
        {
            InitializeComponent();
        }
        public AddOrEditModelWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            var brandsList = Brand.GetBrandList();
            foreach (var brand in brandsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = brand.name;
                comboBoxItem.Value = brand.id;
                brandComboBox.Items.Add(comboBoxItem);
            }
            var templatesList = Template.GetTemplatesList();
            foreach (var template in templatesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = template.name;
                comboBoxItem.Value = template.id;
                templateComboBox.Items.Add(comboBoxItem);
            }
            CategoryComboBox.Items.Add("B");
            CategoryComboBox.Items.Add("BE");
            CategoryComboBox.Items.Add("C");
            CategoryComboBox.Items.Add("C1");
            CategoryComboBox.Items.Add("C1E");
            CategoryComboBox.Items.Add("CE");
            CategoryComboBox.Items.Add("D");
            CategoryComboBox.Items.Add("D1");
            CategoryComboBox.Items.Add("D1E");
            CategoryComboBox.Items.Add("DE");
            this.mainWindow = mainWindow;
        }

        public AddOrEditModelWindow(MainWindow mainWindow, int modelId)
        {
            InitializeComponent();
            var brandsList = Brand.GetBrandList();
            foreach (var brand in brandsList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = brand.name;
                comboBoxItem.Value = brand.id;
                brandComboBox.Items.Add(comboBoxItem);
            }
            var templatesList = Template.GetTemplatesList();
            foreach (var template in templatesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = template.name;
                comboBoxItem.Value = template.id;
                templateComboBox.Items.Add(comboBoxItem);
            }
            CategoryComboBox.Items.Add("B");
            CategoryComboBox.Items.Add("BE");
            CategoryComboBox.Items.Add("C");
            CategoryComboBox.Items.Add("C1");
            CategoryComboBox.Items.Add("C1E");
            CategoryComboBox.Items.Add("CE");
            CategoryComboBox.Items.Add("D");
            CategoryComboBox.Items.Add("D1");
            CategoryComboBox.Items.Add("D1E");
            CategoryComboBox.Items.Add("DE");
            this.mainWindow = mainWindow;
            model = Model.GetModelById(modelId);
            nameTextBox.Text = model.name;
            CategoryComboBox.SelectedItem = model.category;
            brandComboBox.SelectedItem = Brand.GetBrandById(model.brandId).name;
            templateComboBox.SelectedValue = model.templateId;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var modelDto = new ModelDto();

            if (nameTextBox.Text != "")
            {
                modelDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę modelu.\n";
            }

            if (CategoryComboBox.SelectedItem != null)
            {
                modelDto.Category = CategoryComboBox.SelectedItem.ToString();
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać kategorię.\n";
            }
            if (brandComboBox.SelectedItem != null)
            {
                modelDto.BrandId = (int)((ComboBoxItem)brandComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać markę.\n";
            }
            if (templateComboBox.SelectedItem != null)
            {
                modelDto.TemplateId = (int)((ComboBoxItem)templateComboBox.SelectedItem).Value;
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
                    mainWindow.AddModelToDatabase(modelDto);
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Dodawanie modelu nie powiodło się!");
                }

            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var modelDto = new ModelDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            modelDto.Id = model.id;

            if (nameTextBox.Text != "")
            {
                modelDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę modelu.\n";
            }

            if (CategoryComboBox.SelectedItem != null)
            {
                modelDto.Category = CategoryComboBox.SelectedText;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać kategorię.\n";
            }
            if (brandComboBox.SelectedItem != null)
            {
                modelDto.BrandId = (int)((ComboBoxItem)brandComboBox.SelectedItem).Value;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy wybrać markę.\n";
            }
            if (templateComboBox.SelectedItem != null)
            {
                model.templateId = (int)((ComboBoxItem)templateComboBox.SelectedItem).Value;
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
                    Model.UpdateModel(modelDto);
                    mainWindow.UpdateModel();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Edytowanie modelu nie powiodło się!");
                }
            }
        }
    }
}
