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

	//Okienko główne
	public partial class MainWindow : Form
	{
		private bool isLogged;
        private char permission;
        private int userID;
		public MainWindow()
		{
			InitializeComponent();
			InitializeComponentStart();
			isLogged = false;
			profilLabel.Visible = false;
		}


		private void Form2_Load(object sender, EventArgs e)
		{
            var carList = Car.GetCarList();

            carList = Car.GetUserCarList(userID);

            foreach (var car in carList)
			{
				var model = Model.GetModelById(car.modelId);
				var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
				klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
			}
            var userList = User.GetUserList();
            foreach (var user in userList)
            {
                klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.phone));
            }
            UpdateServicePlace();
            UpdateServiceTemplate();
            UpdateTemplate();
            UpdateCatalog();
            UpdateBrand();
            UpdateModel();
            UpdateCare();
            UpdateOrder();
            UpdateService();
            UpdateServiceAction();
        }

        private void InitializeComponentStart()
		{
			this.panelS.Visible = true;
			this.panelS.SendToBack();
			this.panelM.Visible = false;
			this.panelO.Visible = false;
			this.panelK.Visible = false;
		}

		public void InitializeComponentMenadzer(int id)
		{
            permission = 'M';
            userID = id;
			this.panelM.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var carList = Car.GetCarList();

            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
        }

		public void InitializeComponentOpieka(int id)
		{
            permission = 'O';
            userID = id;
            this.panelO.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var carList = Car.GetUserCarList(userID);

            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
        }

		public void InitializeComponentKierowca(int id)
		{
            permission = 'K';
            userID = id;
            this.panelK.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var carList = Car.GetCarList();

            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
        }

		private void zalogujSLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!isLogged)
			{
				LoginWindow obj = new LoginWindow(this);
				isLogged = true;
				obj.Show();
			}
			else
			{
				this.panelM.Visible = false;
				this.panelO.Visible = false;
				this.panelK.Visible = false;
				this.logowanieLabel.Text = "Zaloguj";
				this.profilLabel.Visible = false;
				isLogged = false;
			}
		}

		private void EdytujAuto(int carId)
		{
			var obj = new AddOrEditCarWindow(this, carId);
			obj.Text = "Menedżer Floty - Edytuj pojazd";
			obj.buttonDodajPojazd.Visible = false;
			obj.buttonWczytajSzablon.Visible = false;
			obj.buttonZapiszSzablon.Visible = false;
			obj.Show();
		}

        private void EdytujUser(int userId)
        {
            var obj = new AddOrEditUserWindow(this, userId);
            obj.Text = "Menedżer Floty - Edytuj Użytkownika";
            obj.buttonAddUser.Visible = false;
            obj.Show();
        }

        private void DodajAuto()
		{
			var obj = new AddOrEditCarWindow(this);
			obj.Text = "Menedżer Floty - Dodaj pojazd";
			obj.buttonZatwierdzZmiany.Visible = false;
			obj.Show();
		}

        private void DodajUser()
        {
            AddOrEditUserWindow obj = new AddOrEditUserWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Użytkownika";
            obj.button2.Visible = false;
            obj.Show();
        }

        private void SzczegolyUser(int userId)
        {
            var obj = new AddOrEditUserWindow(userId, "sz");
            obj.Text = "Menedżer Floty - Szczegóły Użytkownika";
            obj.buttonAddUser.Visible = false;
            obj.button2.Visible = false;
            obj.Show();
        }

        private void ShowAddServicePlaceWindow()
        {
            AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Miejsce Serwisowe";
            obj.approveButton.Visible = false;
            obj.Show();
        }

        private void ShowEditServicePlaceWindow(int servicePlaceId)
        {
            AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this, servicePlaceId);
            obj.Text = "Menedżer Floty - Edytuj Miejsce Serwisowe";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddTemplateWindow()
        {
            AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Szablon";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditTemplateWindow(int templateId)
        {
            AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this, templateId);
            obj.Text = "Menedżer Floty - Edytuj Szablon";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddServiceTemplateWindow()
        {
            AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this);
            obj.Text = "Menedżer Floty - Dodaj szablon serwisowy";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditServiceTemplateWindow(int templateId)
        {
            AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this, templateId);
            obj.Text = "Menedżer Floty - Edytuj szablon serwisowy";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddServiceActionWindow()
        {
            AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this);
            obj.Text = "Menedżer Floty - Dodaj czynność serwisową";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditServiceActionWindow(int serviceActionId)
        {
            AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this, serviceActionId);
            obj.Text = "Menedżer Floty - Edytuj czynność serwisową";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddServiceWindow()
        {
            AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this);
            obj.Text = "Menedżer Floty - Dodaj serwis";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditServiceWindow(int serviceId)
        {
            AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this, serviceId);
            obj.Text = "Menedżer Floty - Edytuj serwis";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddCareWindow()
        {
            AddOrEditCareWindow obj = new AddOrEditCareWindow(this);
            obj.Text = "Menedżer Floty - Dodaj opiekę";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditCareWindow(int careId)
        {
            AddOrEditCareWindow obj = new AddOrEditCareWindow(this, careId);
            obj.Text = "Menedżer Floty - Edytuj opiekę";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddCatalogWindow()
        {
            AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Katalog";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditCatalogWindow(int catalogId)
        {
            AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this, catalogId);
            obj.Text = "Menedżer Floty - Edytuj Katalog";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddBrandWindow()
        {
            AddOrEditBrandWindow obj = new AddOrEditBrandWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Markę";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditBrandWindow(int brandId)
        {
            AddOrEditBrandWindow obj = new AddOrEditBrandWindow(this, brandId);
            obj.Text = "Menedżer Floty - Edytuj Markę";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void ShowAddModelWindow()
        {
            AddOrEditModelWindow obj = new AddOrEditModelWindow(this);
            obj.Text = "Menedżer Floty - Dodaj model";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        private void ShowEditModelWindow(int modelId)
        {
            AddOrEditModelWindow obj = new AddOrEditModelWindow(this, modelId);
            obj.Text = "Menedżer Floty - Edytuj model";
            obj.addButton.Visible = false;
            obj.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				deleteButtonMPojazdy.Enabled = true;
			}
			else if (e.ColumnIndex == 7)
			{
				var row = e.RowIndex;
				var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
				EdytujAuto(carId);
			}
			else if (e.ColumnIndex == 6)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId);
				obj.Show();
			}
			else if (e.ColumnIndex == 5)
			{
				var row = e.RowIndex;
				var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
				CarDetailsWindow obj = new CarDetailsWindow(carId);
				obj.Show();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DodajAuto();
		}

		private void oTabelaPojazdy_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
				CarDetailsWindow obj = new CarDetailsWindow();
				obj.Show();
			}
			else if (e.ColumnIndex == 4)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId);
				obj.Show();
			}
		}

		private void oTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
				AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
				obj.addButton.Visible = false;
				obj.Show();
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
			obj.acceptButton.Visible = false;
			obj.Show();
		}

		private void mTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            if (e.ColumnIndex == 12)
			{
                var row = e.RowIndex;
                var orderId = (int)ordersTableM.Rows[row].Cells[1].Value;
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this, orderId);
                obj.Text = "Menedżer Floty - Edytuj Zlecenie";
                obj.addButton.Visible = false;
                obj.Show();
            }
		}

		private void addButtonMZlecenia_Click(object sender, EventArgs e)
		{
			AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this);
			obj.Text = "Menedżer Floty - Dodaj Zlecenie";
			obj.acceptButton.Visible = false;
			obj.Show();
		}

		private void mTabelaKierowcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 7)
			{

                var row = e.RowIndex;
                var userId = (int)tableDriversM.Rows[row].Cells[1].Value;
                EdytujUser(userId);
			}
			else if (e.ColumnIndex == 6)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId);
				obj.Show();
			}
            else if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var userId = (int)tableDriversM.Rows[row].Cells[1].Value;
                SzczegolyUser(userId);
            }

        }

		private void addButtonMKierowcy_Click(object sender, EventArgs e)
		{
            DodajUser();
		}

		private void kTabelaRezerwacje_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
				CarDetailsWindow obj = new CarDetailsWindow();
				obj.Show();
			}
			else if (e.ColumnIndex == 6)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId);
				obj.Show();
			}
			else if (e.ColumnIndex == 7)
			{
				ReservationWindow obj = new ReservationWindow();
				obj.Show();
			}
		}

		private void oTabelaKierowcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 4)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId);
				obj.Show();
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton1.Checked == true)
			{
				this.comboBox1.Visible = true;
				this.comboBox2.Visible = false;
				this.comboBox3.Visible = false;
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton2.Checked == true)
			{
				this.comboBox1.Visible = false;
				this.comboBox2.Visible = true;
				this.comboBox3.Visible = false;
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton3.Checked == true)
			{
				this.comboBox1.Visible = false;
				this.comboBox2.Visible = false;
				this.comboBox3.Visible = true;
			}
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox4.SelectedIndex == 5)
			{
				this.label3.Visible = true;
				this.label4.Visible = true;
				this.dateTimePicker1.Visible = true;
				this.dateTimePicker2.Visible = true;
			}
			else
			{
				this.label3.Visible = false;
				this.label4.Visible = false;
				this.dateTimePicker1.Visible = false;
				this.dateTimePicker2.Visible = false;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			double value = 50;
			double servisValue = 100;
			this.textBox1.Text = value.ToString() + " zł";
			this.textBox2.Text = servisValue.ToString() + " zł";
		}

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox5.SelectedIndex == 5)
			{
				this.label9.Visible = true;
				this.label10.Visible = true;
				this.dateTimePicker3.Visible = true;
				this.dateTimePicker4.Visible = true;
			}
			else
			{
				this.label9.Visible = false;
				this.label10.Visible = false;
				this.dateTimePicker3.Visible = false;
				this.dateTimePicker4.Visible = false;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			double businessKilimetersValue = 50;
			double businessTimeValue = 50;
			double businessValue = 50;
			double privateKilimetersValue = 100;
			double privateTimeValue = 100;
			double privateValue = 100;

			this.textBox3.Text = businessKilimetersValue.ToString() + " km";
			this.textBox6.Text = businessTimeValue.ToString() + " h";
			this.textBox8.Text = businessValue.ToString() + " zł";
			this.textBox4.Text = privateKilimetersValue.ToString() + " km";
			this.textBox5.Text = privateTimeValue.ToString() + " h";
			this.textBox7.Text = privateValue.ToString() + " zł";
		}

		private void profilLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProfilWindow obj = new ProfilWindow(this, userID);
			obj.Show();
		}

		public void AddCarToDatabase(CarDto carDto)
		{
			try
			{
				Car.AddCar(carDto);
				klasaTestowaBindingSource.Clear();
				var list = Car.GetCarList();
				foreach (var car in list)
				{
					var model = Model.GetModelById(car.modelId);
					var brand = Brand.GetBrandById(model.brandId);
                    string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                    klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
				}

			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				throw ex;
			}
		}

        public void UpdateCar(CarDto carDto)
        {
            try
            {
                klasaTestowaBindingSource.Clear();
                var list = Car.GetCarList();
                foreach (var car in list)
                {
                    var model = Model.GetModelById(car.modelId);
                    var brand = Brand.GetBrandById(model.brandId);
                    string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                    klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }


        public void AddUserToDatabase(UserDto userDto)
        {
            try
            {
                User.AddUser(userDto);
                klasaTestowauserBindingSource.Clear();
                var userList = User.GetUserList();
                foreach (var user in userList)
                {
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.phone));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(UserDto userDto)
        {
            try
            {
                klasaTestowauserBindingSource.Clear();
                var userList = User.GetUserList();
                foreach (var user in userList)
                {
                    klasaTestowauserBindingSource.Add(new KlasaTestowa_user(user.id, user.name, user.lastName, user.phone));
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddServicePlaceToDatabase(ServicePlaceDto servicePlaceDto)
        {
            try
            {
                ServicePlace.AddServicePlace(servicePlaceDto);
                ServicePlacesBindingSource.Clear();
                var servicePlacesList = ServicePlace.GetServicePlacesList();
                foreach (var servicePlace in servicePlacesList)
                {
                    ServicePlacesBindingSource.Add(new ServicePlaceTableElement(servicePlace.id, servicePlace.address, servicePlace.companyName));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateServicePlace()
        {
            try
            {
                ServicePlacesBindingSource.Clear();
                var servicePlacesList = ServicePlace.GetServicePlacesList();
                foreach (var servicePlace in servicePlacesList)
                {
                    ServicePlacesBindingSource.Add(new ServicePlaceTableElement(servicePlace.id, servicePlace.address, servicePlace.companyName));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddTemplateToDatabase(TemplateDto templateDto)
        {
            try
            {
                Template.AddTemplate(templateDto);
                TemplatesBindingSource.Clear();
                var templatesList = Template.GetTemplatesList();
                foreach (var template in templatesList)
                {
                    TemplatesBindingSource.Add(new TemplateTableElement(template.id, template.name));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateTemplate()
        {
            try
            {
                TemplatesBindingSource.Clear();
                var templatesList = Template.GetTemplatesList();
                foreach (var template in templatesList)
                {
                    TemplatesBindingSource.Add(new TemplateTableElement(template.id, template.name));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddServiceTemplateToDatabase(ServiceTemplateDto serviceTemplateDto)
        {
            try
            {
                ServiceTemplate.AddServiceTemplate(serviceTemplateDto);
                TemplateServicesBindingSource.Clear();
                var serviceTemplatesList = ServiceTemplate.GetServiceTemplatesList();
                foreach (var serviceTemplate in serviceTemplatesList)
                {
                    TemplateServicesBindingSource.Add(new ServiceTemplateTableElement(serviceTemplate.id, serviceTemplate.name, serviceTemplate.kilometres, serviceTemplate.period, serviceTemplate.catalogId, serviceTemplate.templateId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddServiceActionToDatabase(ServiceActionDto serviceActionDto)
        {
            try
            {
                ServiceAction.AddServiceAction(serviceActionDto);
                ServiceActionsBindingSource.Clear();
                var serviceActionsList = ServiceAction.GetServiceActionsList();
                foreach (var serviceAction in serviceActionsList)
                {
                    ServiceActionsBindingSource.Add(new ServiceActionTableElement(serviceAction.id, serviceAction.name, serviceAction.cost, serviceAction.catalogId, serviceAction.serviceId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddServiceToDatabase(ServiceDto serviceDto)
        {
            try
            {
                Service.AddService(serviceDto);
                ServicesBindingSource.Clear();
                var servicesList = Service.GetServiceList();
                foreach (var service in servicesList)
                {
                    ServicesBindingSource.Add(new ServiceTableElement(service.id, service.cost, service.serviceDate, service.comment, service.servicePlaceId, service.orderId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddOrderToDatabase(OrderDto orderDto)
        {
            try
            {
                Order.AddOrder(orderDto);
                OrdersBindingSource.Clear();
                var ordersList = Order.GetOrderList();
                foreach (var order in ordersList)
                {
                    OrdersBindingSource.Add(new OrderTableElement(order.id, order.plannedStartDate, order.plannedEndDate, order.actualStartDate, order.actualEndDate, order.counterStatusBefore, order.counterStatusAfter, order.commentsBefore, order.commentsAfter, order.type, order.cost, order.cancellationReason, order.state, order.careId, order.userId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddCareToDatabase(CareDto careDto)
        {
            try
            {
                Care.AddCare(careDto);
                careBindingSource.Clear();
                var careList = Care.GetCareList();
                foreach (var care in careList)
                {
                    careBindingSource.Add(new CareTableElement(care.id, care.startDate, care.endDate, care.keeperId, care.carId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateServiceTemplate()
        {
            try
            {
                TemplateServicesBindingSource.Clear();
                var serviceTemplatesList = ServiceTemplate.GetServiceTemplatesList();
                foreach (var serviceTemplate in serviceTemplatesList)
                {
                    TemplateServicesBindingSource.Add(new ServiceTemplateTableElement(serviceTemplate.id, serviceTemplate.name, serviceTemplate.kilometres, serviceTemplate.period, serviceTemplate.catalogId, serviceTemplate.templateId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateServiceAction()
        {
            try
            {
                ServiceActionsBindingSource.Clear();
                var serviceActionsList = ServiceAction.GetServiceActionsList();
                foreach (var serviceAction in serviceActionsList)
                {
                    ServiceActionsBindingSource.Add(new ServiceActionTableElement(serviceAction.id, serviceAction.name, serviceAction.cost, serviceAction.catalogId, serviceAction.serviceId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateService()
        {
            try
            {
                ServicesBindingSource.Clear();
                var servicesList = Service.GetServiceList();
                foreach (var service in servicesList)
                {
                    ServicesBindingSource.Add(new ServiceTableElement(service.id, service.cost, service.serviceDate, service.comment, service.servicePlaceId, service.orderId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder()
        {
            try
            {
                OrdersBindingSource.Clear();
                var ordersList = Order.GetOrderList();
                foreach (var order in ordersList)
                {
                    OrdersBindingSource.Add(new OrderTableElement(order.id, order.plannedStartDate, order.plannedEndDate, order.actualStartDate, order.actualEndDate, order.counterStatusBefore, order.counterStatusAfter, order.commentsBefore, order.commentsAfter, order.type, order.cost, order.cancellationReason, order.state, order.careId, order.userId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateCare()
        {
            try
            {
                careBindingSource.Clear();
                var careList = Care.GetCareList();
                foreach (var care in careList)
                {
                    careBindingSource.Add(new CareTableElement(care.id, care.startDate, care.endDate, care.keeperId, care.carId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddCatalogToDatabase(CatalogDto catalogDto)
        {
            try
            {
                Catalog.AddCatalog(catalogDto);
                CatalogsBindingSource.Clear();
                var catalogsList = Catalog.GetCatalogsList();
                foreach (var catalog in catalogsList)
                {
                    CatalogsBindingSource.Add(new CatalogTableElement(catalog.id, catalog.name));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateCatalog()
        {
            try
            {
                CatalogsBindingSource.Clear();
                var catalogsList = Catalog.GetCatalogsList();
                foreach (var catalog in catalogsList)
                {
                    CatalogsBindingSource.Add(new CatalogTableElement(catalog.id, catalog.name));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddBrandToDatabase(BrandDto brandDto)
        {
            try
            {
                Brand.AddBrand(brandDto);
                BrandsBindingSource.Clear();
                var brandsList = Brand.GetBrandList();
                foreach (var brand in brandsList)
                {
                    BrandsBindingSource.Add(new BrandTableElement(brand.name, brand.id));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateBrand()
        {
            try
            {
                BrandsBindingSource.Clear();
                var brandsList = Brand.GetBrandList();
                foreach (var brand in brandsList)
                {
                    BrandsBindingSource.Add(new BrandTableElement(brand.name, brand.id));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void AddModelToDatabase(ModelDto modelDto)
        {
            try
            {
                Model.AddModel(modelDto);
                ModelsBindingSource.Clear();
                var modelsList = Model.GetModelList();
                foreach (var model in modelsList)
                {
                    ModelsBindingSource.Add(new ModelTableElement(model.id, model.name, model.category, model.brandId, model.templateId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateModel()
        {
            try
            {
                ModelsBindingSource.Clear();
                var modelsList = Model.GetModelList();
                foreach (var model in modelsList)
                {
                    ModelsBindingSource.Add(new ModelTableElement(model.id, model.name, model.category, model.brandId, model.templateId));
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowAddServicePlaceWindow();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ShowEditServicePlaceWindow();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var servicePlaceId = (int)tableServicePlacesM.Rows[row].Cells[1].Value;
                AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this, servicePlaceId);
                obj.Text = "Menedżer Floty - Edytuj Miejsce Serwisu";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void addTemplateButton_Click(object sender, EventArgs e)
        {
            ShowAddTemplateWindow();
        }

        private void templatesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var templateId = (int)templatesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this, templateId);
                obj.Text = "Menedżer Floty - Edytuj Szablon";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void addServiceTemplateButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceTemplateWindow();
        }

        private void ServiceTemplatesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                var row = e.RowIndex;
                var templateId = (int)ServiceTemplatesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this, templateId);
                obj.Text = "Menedżer Floty - Edytuj Szablon";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void catalogsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var catalogId = (int)catalogsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this, catalogId);
                obj.Text = "Menedżer Floty - Edytuj Katalog";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void AddCatalogButton_Click(object sender, EventArgs e)
        {
            ShowAddCatalogWindow();
        }

        private void deleteCatalogButton_Click(object sender, EventArgs e)
        {

        }

        private void addBrandButton_Click(object sender, EventArgs e)
        {
            ShowAddBrandWindow();
        }

        private void deleteBrandButton_Click(object sender, EventArgs e)
        {

        }

        private void brandsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var brandId = (int)brandsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditBrandWindow obj = new AddOrEditBrandWindow(this, brandId);
                obj.Text = "Menedżer Floty - Edytuj Markę";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void addModelButton_Click(object sender, EventArgs e)
        {
            ShowAddModelWindow();
        }

        private void deleteModelButton_Click(object sender, EventArgs e)
        {

        }

        private void modelsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var modelId = (int)modelsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditModelWindow obj = new AddOrEditModelWindow(this, modelId);
                obj.Text = "Menedżer Floty - Edytuj Model";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void addCareButton_Click(object sender, EventArgs e)
        {
            ShowAddCareWindow();
        }

        private void deleteCareButton_Click(object sender, EventArgs e)
        {

        }

        private void careDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var careId = (int)careDataGridView.Rows[row].Cells[1].Value;
                AddOrEditCareWindow obj = new AddOrEditCareWindow(this, careId);
                obj.Text = "Menedżer Floty - Edytuj Opiekę";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void deleteButtonMOrder_Click(object sender, EventArgs e)
        {

        }

        private void addServiceButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceWindow();
        }

        private void deleteServiceButton_Click(object sender, EventArgs e)
        {

        }

        private void servicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var serviceId = (int)servicesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this, serviceId);
                obj.Text = "Menedżer Floty - Edytuj Serwis";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void addServiceActionButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceActionWindow();
        }

        private void deleteServiceActionButton_Click(object sender, EventArgs e)
        {

        }

        private void ServiceActionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var serviceActionId = (int)ServiceActionsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this, serviceActionId);
                obj.Text = "Menedżer Floty - Edytuj Czynność Serwisową";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }
    }
}