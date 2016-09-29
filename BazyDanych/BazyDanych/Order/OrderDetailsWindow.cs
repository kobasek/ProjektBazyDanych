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
    /// Klasa formularza wyświetlająca szczegóły zlecenia
    /// </summary>
    public partial class OrderDetailsWindow : Form
    {
        /// <summary>
        /// Bezparametrowy konstrukor klasy formularza wyświetlająca szczegóły zlecenia
        /// </summary>
        public OrderDetailsWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Jednoparametrowy konstruktor klasy formularza wyświetlająca szczegóły zlecenia
        /// </summary>
        /// <param name="orderId">ID zlecenia, któego szczegóły mają być wyświetlone</param>
        public OrderDetailsWindow(int orderId)
        {
            /*InitializeComponent();
            Order order = Order.GetOrderById(orderId);
            Care care = order.careId;
            careComboBox.Text = "Data początkowa: " + care.startDate + "Data końcowa: " + care.endDate + ""
            placeTextBox.Text = ServicePlace.GetServicePlaceById(service.servicePlaceId).companyName + " " + ServicePlace.GetServicePlaceById(service.servicePlaceId).address;
            DateDateTimePicker.Value = service.serviceDate;
            costTextBox.Text = service.cost.ToString();
            commentRichTextBox.Text = service.comment;
            serviceActionsBindingSource.Clear();
            IList<ServiceAction> serviceActionsList = ServiceAction.GetServiceActionsWithGivenServiceIdList(serviceId);
            foreach (ServiceAction serviceAction in serviceActionsList)
            {
                serviceActionsBindingSource.Add(new ServiceActionTableElement(serviceAction.id, serviceAction.name, serviceAction.cost, serviceAction.catalogId, serviceAction.serviceId));
            }*/
        }
    }
}
