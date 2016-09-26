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
    public partial class TemplateDetailsWindow : Form
    {
        public TemplateDetailsWindow()
        {
            InitializeComponent();
        }

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
    }
}
