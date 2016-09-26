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
    public partial class CatalogDetailsWindow : Form
    {
        public CatalogDetailsWindow()
        {
            InitializeComponent();
        }

        public CatalogDetailsWindow(int catalogID)
        {
            InitializeComponent();
            nameTextBox.Text = Catalog.GetCatalogById(catalogID).name;
            serviceTemplatesBindingSource.Clear();
            IList<ServiceTemplate> serviceTemplatesList = ServiceTemplate.GetServiceTemplatesWithGivenCatalogIdList(catalogID);
            foreach (ServiceTemplate serviceTemplate in serviceTemplatesList)
            {
                serviceTemplatesBindingSource.Add(new ServiceTemplateTableElement(serviceTemplate.id, serviceTemplate.name, serviceTemplate.kilometres, serviceTemplate.period, serviceTemplate.catalogId, serviceTemplate.templateId));
            }
            serviceActionsBindingSource.Clear();
            IList<ServiceAction> serviceActionsList = ServiceAction.GetServiceActionsWithGivenCatalogIdList(catalogID);
            foreach (ServiceAction serviceAction in serviceActionsList)
            {
                serviceActionsBindingSource.Add(new ServiceActionTableElement(serviceAction.id, serviceAction.name, serviceAction.cost, serviceAction.catalogId, serviceAction.serviceId));
            }
        }
    }
}
