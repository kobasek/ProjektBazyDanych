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
    /// Klasa formularza wyświatlającego szczegóły serwisu
    /// </summary>
    public partial class ServiceDetails : Form
    {
        /// <summary>
        /// Bezparametrowy konstruktor klasy formularza wyświetlającego szczegół serwisu
        /// </summary>
        public ServiceDetails()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Jednoparametrowy konstruktor klasy formularza wyświetlającego szczegół serwisu
        /// </summary>
        /// <param name="serviceId">ID serwisu, którego szczegóły chcemy wyświetlić</param>
        public ServiceDetails(int serviceId)
        {
            InitializeComponent();
            Service service = Service.GetServiceById(serviceId);
            placeTextBox.Text = ServicePlace.GetServicePlaceById(service.servicePlaceId).companyName + " " + ServicePlace.GetServicePlaceById(service.servicePlaceId).address;
            DateDateTimePicker.Value = service.serviceDate;
            costTextBox.Text = service.cost.ToString();
            commentRichTextBox.Text = service.comment;
            serviceActionsBindingSource.Clear();
            IList<ServiceAction> serviceActionsList = ServiceAction.GetServiceActionsWithGivenServiceIdList(serviceId);
            foreach (ServiceAction serviceAction in serviceActionsList)
            {
                serviceActionsBindingSource.Add(new ServiceActionTableElement(serviceAction.id, serviceAction.name, serviceAction.cost, serviceAction.catalogId, serviceAction.serviceId));
            }
        }
        /// <summary>
        /// Event Handler łapiący kliknięcie w tabelę czynności serwisowych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serviceActionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3)
            {
                var row = e.RowIndex;
                var serviceActionId = (int)serviceActionsDataGridView.Rows[row].Cells[0].Value;
                int catalogId = ServiceAction.GetServiceActionById(serviceActionId).catalogId;
                CatalogDetailsWindow obj = new CatalogDetailsWindow(catalogId);
                obj.Show();
            }
        }
    }
}
