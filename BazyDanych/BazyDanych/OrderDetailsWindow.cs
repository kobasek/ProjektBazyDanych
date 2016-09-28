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
    public partial class OrderDetailsWindow : Form
    {
        public OrderDetailsWindow()
        {
            InitializeComponent();
        }

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
