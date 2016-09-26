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
    public partial class AddOrEditServiceActionWindow : Form
    {
        private MainWindow mainWindow;
        private ServiceAction serviceAction;

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
            /*var servicesList = Service.GetServicesList();
            foreach (var template in templatesList)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Text = template.name;
                comboBoxItem.Value = template.id;
                templateComboBox.Items.Add(comboBoxItem);
            }*/
            this.mainWindow = mainWindow;
        }

        public AddOrEditServiceActionWindow(MainWindow mainWindow, int serviceTemplateId)
        {
            /*InitializeComponent();
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
            templateComboBox.SelectedValue = serviceTemplate.templateId;*/
        }
    }
}
