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
    /// <summary>
    /// Klasa formularza wyświetlającego okno ze szczegółami szablonu
    /// </summary>
    public partial class TemplateDetailsWindow : Form
    {
        /// <summary>
        /// Bez parametrowy konstruktor klasy formularza wyświatlającego okno szczegółów szablonu
        /// </summary>
        public TemplateDetailsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Jednoparametrowy konstruktor klasy formularza wyświatlającego okno szczegóły szablonu
        /// </summary>
        /// <param name="templateID">ID szablonu, którego szczegóły chcemy wyświetlić</param>
        public TemplateDetailsWindow(int templateID)
        {
            InitializeComponent();
            nameTextBox.Text = Template.GetTemplateById(templateID).name;
            servicesBindingSource.Clear();
            IList<ServiceTemplate> serviceTemplatesList = ServiceTemplate.GetServiceTemplatesWithGivenTemplateIdList(templateID);
            foreach (ServiceTemplate serviceTemplate in serviceTemplatesList)
            {
                servicesBindingSource.Add(new ServiceTemplateTableElement(serviceTemplate.id, serviceTemplate.name, serviceTemplate.kilometres, serviceTemplate.period, serviceTemplate.catalogId, serviceTemplate.templateId));
            }
            modelsBindingSource.Clear();
            IList<Model> modelsList = Model.GetModelsWithGivenTemplateIdList(templateID);
            foreach (Model model in modelsList)
            {
                modelsBindingSource.Add(new ModelTableElement(model.id, model.name, model.category, model.brandId, model.templateId));
            }
        }

        /// <summary>
        /// Event Handler tabeli zawierającej listę modeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var row = e.RowIndex;
                int brandId = Model.GetModelById((int)modelsDataGridView.Rows[row].Cells[0].Value).brandId;
                BrandDetailsWindow obj = new BrandDetailsWindow(brandId);
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler tabeli zawierającej listę serwisów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void servicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var catalogId = ServiceTemplate.GetServiceTemplateById((int)servicesDataGridView.Rows[row].Cells[0].Value).catalogId;
                CatalogDetailsWindow obj = new CatalogDetailsWindow(catalogId);
                obj.Show();
            }
        }
    }
}
