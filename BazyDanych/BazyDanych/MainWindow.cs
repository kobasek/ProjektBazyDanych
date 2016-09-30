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
    /// Klasa formularza zawierającego główne okno aplikacji
    /// </summary>
	public partial class MainWindow : Form
	{
		private bool isLogged;
        private int userID;
        private char permissions;

        /// <summary>
        /// Bezparametrowy konstruktor klasy formularza zawierającego główne okno aplikacji
        /// </summary>
		public MainWindow()
		{
			InitializeComponent();
			InitializeComponentStart();
			isLogged = false;
			profilLabel.Visible = false;
		}

        /// <summary>
        /// Metoda ładujące dane do tabel przy tworzeniu się okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form2_Load(object sender, EventArgs e)
		{
            var carList = Car.GetCarList();

            carList = Car.GetUserCarList(userID);

            klasaTestowaBindingSource.Clear();
            foreach (var car in carList)
			{
				var model = Model.GetModelById(car.modelId);
				var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
				klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
			}
            var userList = User.GetUserList();
            klasaTestowauserBindingSource.Clear();
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

        /// <summary>
        /// Metoda inicjalizująca wygląd okna głównego po starcie programu
        /// </summary>
        private void InitializeComponentStart()
		{
			this.panelS.Visible = true;
			this.panelS.SendToBack();
			this.panelM.Visible = false;
			this.panelO.Visible = false;
			this.panelK.Visible = false;
		}
        /// <summary>
        /// Metoda ustawiająca wygląd okna głównego po zalogowaniu jako manager
        /// </summary>
        /// <param name="id">ID zalogowanego użytkownika</param>
		public void InitializeComponentMenadzer(int id)
		{
            permissions = 'm';
            userID = id;
			this.panelM.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var carList = Car.GetCarList();
            klasaTestowaBindingSource.Clear();
            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
            UpdateOrder();
        }

        /// <summary>
        /// Metoda ustawiająca wygląd okna głównego po zalogowaniu jako piekun
        /// </summary>
        /// <param name="id">ID zalogowanego użytkownika</param>
		public void InitializeComponentOpieka(int id)
		{
            permissions = 'o';
            userID = id;
            this.panelO.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var carList = Car.GetUserCarList(userID);
            var careList = Care.GetCareItembyKeeper(userID);
            List<Order> ordersList = new List<Order>();
            foreach (Care care in careList)
            {
                ordersList.AddRange(Order.GetOrderByCare(care.id));
            }
            OrdersBindingSource.Clear();
            foreach (var order in ordersList)
            {
                OrdersBindingSource.Add(new OrderTableElement(order.id, order.plannedStartDate, order.plannedEndDate, order.actualStartDate, order.actualEndDate, order.counterStatusBefore, order.counterStatusAfter, order.commentsBefore, order.commentsAfter, order.type, order.cost, order.cancellationReason, order.state, order.careId, order.userId));
            }
            klasaTestowaBindingSource.Clear();
            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
        }

        /// <summary>
        /// Metoda ustawiająca wygląd okna głównego po zalogowaniu jako kierowca
        /// </summary>
        /// <param name="id">ID zalogowanego użytkownika</param>
		public void InitializeComponentKierowca(int id)
		{
            permissions = 'k';
            userID = id;
            this.panelK.Visible = true;
			this.profilLabel.Visible = true;
			this.logowanieLabel.Text = "Wyloguj";
            var orderList = Order.GetOrderByDriver(id);
            OrdersBindingSource.Clear();
            foreach (var order in orderList)
            {
                OrdersBindingSource.Add(new OrderTableElement(order.id, order.plannedStartDate, order.plannedEndDate, order.actualStartDate, order.actualEndDate, order.counterStatusBefore, order.counterStatusAfter, order.commentsBefore, order.commentsAfter, order.type, order.cost, order.cancellationReason, order.state, order.careId, order.userId));
            }
            var carList = Car.GetCarList();
            klasaTestowaBindingSource.Clear();
            foreach (var car in carList)
            {
                var model = Model.GetModelById(car.modelId);
                var brand = Brand.GetBrandById(model.brandId);
                string keeper = User.GetUserNameById(Care.GetKeeperID(car.id));
                klasaTestowaBindingSource.Add(new KlasaTestowa_car(car.id, brand.name, model.name, keeper));
            }
        }

        /// <summary>
        /// Event Handler dla przycisku "Zaloguj"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Metoda inicjalizująca edycję pojazdu
        /// </summary>
        /// <param name="carId">ID pojazdu do edycji</param>
		private void EdytujAuto(int carId)
		{
			var obj = new AddOrEditCarWindow(this, carId);
			obj.Text = "Menedżer Floty - Edytuj pojazd";
			obj.buttonDodajPojazd.Visible = false;
			obj.Show();
		}

        /// <summary>
        /// Metoda inicjalizująca edycję użytkownika
        /// </summary>
        /// <param name="userId">ID użytkownika do edycji</param>
        private void EdytujUser(int userId)
        {
            var obj = new AddOrEditUserWindow(this, userId);
            obj.Text = "Menedżer Floty - Edytuj Użytkownika";
            obj.buttonAddUser.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego pojazdu
        /// </summary>
        private void DodajAuto()
		{
			var obj = new AddOrEditCarWindow(this);
			obj.Text = "Menedżer Floty - Dodaj pojazd";
			obj.buttonZatwierdzZmiany.Visible = false;
			obj.Show();
		}

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego użytkownika
        /// </summary>
        private void DodajUser()
        {
            AddOrEditUserWindow obj = new AddOrEditUserWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Użytkownika";
            obj.button2.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca wyświetlenie szczegółów kierowcy
        /// </summary>
        /// <param name="userId">ID kierowcy, któego szczegóły mają być wyświetlone</param>
        private void SzczegolyUser(int userId)
        {
            var obj = new AddOrEditUserWindow(userId, "sz");
            obj.Text = "Menedżer Floty - Szczegóły Użytkownika";
            obj.buttonAddUser.Visible = false;
            obj.button2.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego miejsca serwisowego
        /// </summary>
        private void ShowAddServicePlaceWindow()
        {
            AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Miejsce Serwisowe";
            obj.approveButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję miejsca serwisowego
        /// </summary>
        /// <param name="servicePlaceId">ID miejsca serwisowego, które ma być edytowane</param>
        private void ShowEditServicePlaceWindow(int servicePlaceId)
        {
            AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this, servicePlaceId);
            obj.Text = "Menedżer Floty - Edytuj Miejsce Serwisowe";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego szablonu
        /// </summary>
        private void ShowAddTemplateWindow()
        {
            AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Szablon";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję szablonu
        /// </summary>
        /// <param name="templateId">ID szablonu, który ma być edytowany</param>
        private void ShowEditTemplateWindow(int templateId)
        {
            AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this, templateId);
            obj.Text = "Menedżer Floty - Edytuj Szablon";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego szablonu serwisowego
        /// </summary>
        private void ShowAddServiceTemplateWindow()
        {
            AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this);
            obj.Text = "Menedżer Floty - Dodaj szablon serwisowy";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję szablonu serwisowego
        /// </summary>
        /// <param name="templateId">ID szablonu serwisowego, który ma być edytowany</param>
        private void ShowEditServiceTemplateWindow(int templateId)
        {
            AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this, templateId);
            obj.Text = "Menedżer Floty - Edytuj szablon serwisowy";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowej czynności serwisowej
        /// </summary>
        private void ShowAddServiceActionWindow()
        {
            AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this);
            obj.Text = "Menedżer Floty - Dodaj czynność serwisową";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję czynności serwisowej
        /// </summary>
        /// <param name="serviceActionId">ID czynności serwisowej, która ma być edytowana</param>
        private void ShowEditServiceActionWindow(int serviceActionId)
        {
            AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this, serviceActionId);
            obj.Text = "Menedżer Floty - Edytuj czynność serwisową";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego serwisu
        /// </summary>
        private void ShowAddServiceWindow()
        {
            AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this);
            obj.Text = "Menedżer Floty - Dodaj serwis";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję serwisu
        /// </summary>
        /// <param name="serviceId">ID serwisu, który ma być edytowany</param>
        private void ShowEditServiceWindow(int serviceId)
        {
            AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this, serviceId);
            obj.Text = "Menedżer Floty - Edytuj serwis";
            obj.addButton.Visible = false;
            obj.addServiceActionButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowej opieki
        /// </summary>
        private void ShowAddCareWindow()
        {
            AddOrEditCareWindow obj = new AddOrEditCareWindow(this);
            obj.Text = "Menedżer Floty - Dodaj opiekę";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję opieki
        /// </summary>
        /// <param name="careId">ID opieki, któa ma być edytowana</param>
        private void ShowEditCareWindow(int careId)
        {
            AddOrEditCareWindow obj = new AddOrEditCareWindow(this, careId);
            obj.Text = "Menedżer Floty - Edytuj opiekę";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego katalogu
        /// </summary>
        private void ShowAddCatalogWindow()
        {
            AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Katalog";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycją katalogu
        /// </summary>
        /// <param name="catalogId">ID katalogu, który ma być edytowany</param>
        private void ShowEditCatalogWindow(int catalogId)
        {
            AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this, catalogId);
            obj.Text = "Menedżer Floty - Edytuj Katalog";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowej marki
        /// </summary>
        private void ShowAddBrandWindow()
        {
            AddOrEditBrandWindow obj = new AddOrEditBrandWindow(this);
            obj.Text = "Menedżer Floty - Dodaj Markę";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję marki
        /// </summary>
        /// <param name="brandId">ID marki, któa ma być edytowana</param>
        private void ShowEditBrandWindow(int brandId)
        {
            AddOrEditBrandWindow obj = new AddOrEditBrandWindow(this, brandId);
            obj.Text = "Menedżer Floty - Edytuj Markę";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca dodanie nowego modelu
        /// </summary>
        private void ShowAddModelWindow()
        {
            AddOrEditModelWindow obj = new AddOrEditModelWindow(this);
            obj.Text = "Menedżer Floty - Dodaj model";
            obj.acceptButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Metoda inicjalizująca edycję modelu
        /// </summary>
        /// <param name="modelId">ID modelu, który ma być edytowany</param>
        private void ShowEditModelWindow(int modelId)
        {
            AddOrEditModelWindow obj = new AddOrEditModelWindow(this, modelId);
            obj.Text = "Menedżer Floty - Edytuj model";
            obj.addButton.Visible = false;
            obj.Show();
        }

        /// <summary>
        /// Event handler dla tabeli zawierającej listę wszystkich pojazdów, wyświetlanej, gdy zalogowany użytkownik jest administratorem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				deleteButtonMPojazdy.Enabled = true;
			}
            else if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                int keeperId = Care.GetKeeperID(carId);
                SzczegolyUser(keeperId);
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
                ScheduleWindow obj = new ScheduleWindow(carId, 'C');
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

        /// <summary>
        /// Event Handler dla przycisku dodaj auto, przy tabeli zawierającej listę wszystkich pojazdów, wyświetlanej, gdy użytkowni jest zalogowany jako administrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			DodajAuto();
		}

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę aut, nad którą dany uzytkownik pełni opiekę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void oTabelaPojazdy_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
			else if (e.ColumnIndex == 4)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId, 'C');
				obj.Show();
			}
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę zleceń, które obejmują auta znajdujące się pod opieką danego użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void oTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
                var row = e.RowIndex;
                var orderId = (int)oTabelaZlecenia.Rows[row].Cells[1].Value;
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this, orderId);
                obj.Text = "Menedżer Floty - Edytuj Zlecenie";
                obj.addButton.Visible = false;
                obj.addServiceButton.Visible = false;
                obj.Show();
            }
		}

        /// <summary>
        /// Event Handler dla przycisku dodaj zlecenie, przy tabeli zawierającej listę zleceń, które obejmują auta znajdujące się pod opieką danego użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click_1(object sender, EventArgs e)
		{
			AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this);
			obj.acceptButton.Visible = false;
			obj.Show();
		}

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę wszystkich zleceń, wyświetlanej, gdy użytkownik zalogowany jest jako administrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void mTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            if (e.ColumnIndex == 12)
			{
                var row = e.RowIndex;
                var orderId = (int)ordersTableM.Rows[row].Cells[1].Value;
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this, orderId);
                obj.Text = "Menedżer Floty - Edytuj Zlecenie";
                obj.addButton.Visible = false;
                obj.addServiceButton.Visible = false;
                obj.Show();
            }
            else if (e.ColumnIndex == 2)
            {
                var row = e.RowIndex;
                var orderId = (int)ordersTableM.Rows[row].Cells[1].Value;
                var careId = Order.GetOrderById(orderId).careId;
                var carId = Care.GetCareByID(careId).carId;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla przycisku dodaj zlecenie, przy tabeli zawierającej listę wszystkich zleceń, wyświetlanej, gdy użytkownik zalogowany jest jako administrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void addButtonMZlecenia_Click(object sender, EventArgs e)
		{
			AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this);
			obj.Text = "Menedżer Floty - Dodaj Zlecenie";
			obj.acceptButton.Visible = false;
			obj.Show();
		}

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę wszystkich kierowców, wyświetlanej, gdy użytkownik zalogowany jest jako administrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                var carId = (int)tableDriversM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId, 'D');
				obj.Show();
			}
            else if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var userId = (int)tableDriversM.Rows[row].Cells[1].Value;
                SzczegolyUser(userId);
            }

        }

        /// <summary>
        /// Event Handler dla przycisku dodaj kierowcę, przy tabeli zawierającej listę wszystkich kierowców, wyświetlanej, gdy użytkownik zalogowany jest jako administrator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void addButtonMKierowcy_Click(object sender, EventArgs e)
		{
            DodajUser();
		}

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę wszystkich pojazdów, które można zarezerwować, wyświetlanej, gdy użytkownik zalogowany jest jako kierowca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void kTabelaRezerwacje_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
			else if (e.ColumnIndex == 4)
			{
                var row = e.RowIndex;
                var carId = (int)tableCarsM.Rows[row].Cells[1].Value;
                ScheduleWindow obj = new ScheduleWindow(carId, 'C');
				obj.Show();
			}
			else if (e.ColumnIndex == 6)
			{
				ReservationWindow obj = new ReservationWindow();
				obj.Show();
			}
		}

        /// <summary>
        /// Event Handler dla tabeli zawierającej listę wszystkich kierowców, wyświetlanej, gdy użytkownik zalogowany jest jako opiekun
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void oTabelaKierowcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 4)
			{
                var row = e.RowIndex;
                var carId = (int)oTabelaKierowcy.Rows[row].Cells[0].Value;
                ScheduleWindow obj = new ScheduleWindow(carId, 'D');
				obj.Show();
			}
            else if(e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var userId = (int)oTabelaKierowcy.Rows[row].Cells[0].Value;
                SzczegolyUser(userId);
            }
		}

        /// <summary>
        /// Event Handler dla radiobuttona odpowiadającego marce w tabeli z kosztami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton1.Checked == true)
			{
				this.comboBox1.Visible = true;
				this.comboBox2.Visible = false;
				this.comboBox3.Visible = false;
			}
		}

        /// <summary>
        /// Event Handler dla radiobuttona odpowiadającego modelowi w tabeli z kosztami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton2.Checked == true)
			{
				this.comboBox1.Visible = false;
				this.comboBox2.Visible = true;
				this.comboBox3.Visible = false;
			}
		}

        /// <summary>
        /// Event Handler dla radiobuttona odpowiadającego pojedyńczemu pojazdowi w tabeli z kosztami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton3.Checked == true)
			{
				this.comboBox1.Visible = false;
				this.comboBox2.Visible = false;
				this.comboBox3.Visible = true;
			}
		}

        /// <summary>
        /// Event Handler dla comboboxa ustawiającego zakres dat dla generowania kosztów pojazdów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Event Handler dla przycisku generuj koszty pojazdów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			double value = 50;
			double servisValue = 100;
			this.textBox1.Text = value.ToString() + " zł";
			this.textBox2.Text = servisValue.ToString() + " zł";
		}

        /// <summary>
        /// Event Handler dla comboboxa ustawiającego zakres dat dla generowania kosztów kierowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///  Event Handler dla przycisku generuj koszty kierowców
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///  Event Handler dla przycisku Profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void profilLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProfilWindow obj = new ProfilWindow(this, userID);
			obj.Show();
		}

        /// <summary>
        /// Metoda dodająca nowy pojazd do bazdy danych i listy wyświetlanych pojazdów
        /// </summary>
        /// <param name="carDto">Obiekt reprezentujący pojazd, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca pojazd w liście wyświetlanych pojazdów
        /// </summary>
        /// <param name="carDto">Obiekt reprezentując nowe dane pojazdu</param>
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

        /// <summary>
        /// Metoda dodająca nowego kierowcy do bazdy danych i listy wyświetlanych kierowców
        /// </summary>
        /// <param name="userDto">Obiekt reprezentujący kierowcę, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca kierowcę w liście wyświetlanych kierowców
        /// </summary>
        /// <param name="userDto"></param>
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

        /// <summary>
        /// Metoda dodająca nowe miejsce serwisu do bazdy danych i listy wyświetlanych miejsc serwisowych
        /// </summary>
        /// <param name="servicePlaceDto">Obiekt reprezentujący miejsce serwisu, które ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca miejsce serwisu w liście wyświetlanych miejsc serwisowych
        /// </summary>
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

        /// <summary>
        /// Metoda dodająca nowy szablon do bazdy danych i listy wyświetlanych szablonów
        /// </summary>
        /// <param name="templateDto">Obiekt reprezentujący szablon, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca szablon w liście wyświetlanych szablonów
        /// </summary>
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

        /// <summary>
        /// Metoda dodająca nowy szablon serwisowy do bazdy danych i listy wyświetlanych szablonów serwisowych
        /// </summary>
        /// <param name="serviceTemplateDto">Obiekt reprezentujący szablon serwisowy, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda dodająca nową czynność serwisową do bazdy danych i listy wyświetlanych czynności serwisowych
        /// </summary>
        /// <param name="serviceActionDto">Obiekt reprezentujący czynność serwisową, która ma zostać dodana do bazy</param>
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

        /// <summary>
        /// Metoda dodająca nowy serwis do bazdy danych i listy wyświetlanych serwisów
        /// </summary>
        /// <param name="serviceDto">Obiekt reprezentujący serwis, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda dodająca nowe zlecenie do bazdy danych i listy wyświetlanych zleceń
        /// </summary>
        /// <param name="orderDto">Obiekt reprezentujący zlecenie, które ma zostać dodane do bazy</param>
        /// <returns></returns>
        public int AddOrderToDatabase(OrderDto orderDto)
        {
            try
            {
                int id = Order.AddOrder(orderDto);
                OrdersBindingSource.Clear();
                var ordersList = Order.GetOrderList();
                foreach (var order in ordersList)
                {
                    OrdersBindingSource.Add(new OrderTableElement(order.id, order.plannedStartDate, order.plannedEndDate, order.actualStartDate, order.actualEndDate, order.counterStatusBefore, order.counterStatusAfter, order.commentsBefore, order.commentsAfter, order.type, order.cost, order.cancellationReason, order.state, order.careId, order.userId));
                }
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metoda dodająca nową opiekę do bazdy danych i listy wyświetlanych opiek
        /// </summary>
        /// <param name="careDto">Obiekt reprezentujący opiekę, która ma zostać dodana do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca szablon serwisowy w liście wyświetlanych szablonów serwisowych
        /// </summary>
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

        /// <summary>
        /// Metoda aktualizująca czynność serwisową w liście wyświetlanych czynności serwisowych
        /// </summary>
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

        /// <summary>
        /// Metoda aktualizująca serwis w liście wyświetlanych serwisów
        /// </summary>
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

        /// <summary>
        /// Metoda aktualizująca zlecenie w liście wyświetlanych zleceń
        /// </summary>
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

        /// <summary>
        /// Metoda aktualizująca opiekę w liście wyświetlanych opiek
        /// </summary>
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

        /// <summary>
        /// Metoda dodająca nowy katalog do bazdy danych i listy wyświetlanych katalogów
        /// </summary>
        /// <param name="catalogDto">Obiekt reprezentujący katalog, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca katalog w liście wyświetlanych katalogów
        /// </summary>
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

        /// <summary>
        /// Metoda dodająca nową markę do bazdy danych i listy wyświetlanych marek
        /// </summary>
        /// <param name="brandDto">Obiekt reprezentujący markę, która ma zostać dodaa do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca markę w liście wyświetlanych marek
        /// </summary>
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

        /// <summary>
        /// Metoda dodająca nowy model do bazdy danych i listy wyświetlanych modeli
        /// </summary>
        /// <param name="modelDto">Obiekt reprezentujący model, który ma zostać dodany do bazy</param>
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

        /// <summary>
        /// Metoda aktualizująca model w liście wyświetlanych modeli
        /// </summary>
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

        /// <summary>
        /// Event Handler dla przycisku dodaj miejsce serwisowe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ShowAddServicePlaceWindow();
        }

        /// <summary>
        /// Event Handler dla przycisku edytuj miejsce serwisowe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //ShowEditServicePlaceWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej miejsca serwisu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Event Handler dla przycisku dodaj szablon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTemplateButton_Click(object sender, EventArgs e)
        {
            ShowAddTemplateWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej szablony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void templatesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var row = e.RowIndex;
                var templateId = (int)templatesDataGridView.Rows[row].Cells[1].Value;
                TemplateDetailsWindow obj = new TemplateDetailsWindow(templateId);
                obj.Show();
            }
            else if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var templateId = (int)templatesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditTemplateWindow obj = new AddOrEditTemplateWindow(this, templateId);
                obj.Text = "Menedżer Floty - Edytuj Szablon";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla przycisku dodaj szablon serwisowy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addServiceTemplateButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceTemplateWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej szablony serwisowe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceTemplatesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var serviceTemplateId = (int)ServiceTemplatesDataGridView.Rows[row].Cells[1].Value;
                int catalogId = ServiceTemplate.GetServiceTemplateById(serviceTemplateId).catalogId;
                CatalogDetailsWindow obj = new CatalogDetailsWindow(catalogId);
                obj.Show();
            }
            else if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var serviceTemplateId = (int)ServiceTemplatesDataGridView.Rows[row].Cells[1].Value;
                int templateId = ServiceTemplate.GetServiceTemplateById(serviceTemplateId).templateId;
                TemplateDetailsWindow obj = new TemplateDetailsWindow(templateId);
                obj.Show();
            }
            else if (e.ColumnIndex == 8)
            {
                var row = e.RowIndex;
                var templateId = (int)ServiceTemplatesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceTemplateWindow obj = new AddOrEditServiceTemplateWindow(this, templateId);
                obj.Text = "Menedżer Floty - Edytuj Szablon";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej katalogi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catalogsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var row = e.RowIndex;
                var catalogId = (int)catalogsDataGridView.Rows[row].Cells[1].Value;
                CatalogDetailsWindow obj = new CatalogDetailsWindow(catalogId);
                obj.Show();
            }
            else if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var catalogId = (int)catalogsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditCatalogWindow obj = new AddOrEditCatalogWindow(this, catalogId);
                obj.Text = "Menedżer Floty - Edytuj Katalog";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla przycisku dodaj katalog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCatalogButton_Click(object sender, EventArgs e)
        {
            ShowAddCatalogWindow();
        }


        /// <summary>
        /// Event Handler dla przycisku dodaj markę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBrandButton_Click(object sender, EventArgs e)
        {
            ShowAddBrandWindow();
        }


        /// <summary>
        /// Event Handler dla tabeli zawierającej marki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brandsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var row = e.RowIndex;
                var brandId = (int)brandsDataGridView.Rows[row].Cells[1].Value;
                BrandDetailsWindow obj = new BrandDetailsWindow(brandId);
                obj.Show();
            }
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

        /// <summary>
        /// Event Handler dla przycisku dodaj model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addModelButton_Click(object sender, EventArgs e)
        {
            ShowAddModelWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej modele
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modelsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var modelId = (int)modelsDataGridView.Rows[row].Cells[1].Value;
                int brandId = Model.GetModelById(modelId).brandId;
                BrandDetailsWindow obj = new BrandDetailsWindow(brandId);
                obj.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var modelId = (int)modelsDataGridView.Rows[row].Cells[1].Value;
                if (Model.GetModelById(modelId).templateId != null)
                {
                    int templateId = (int)Model.GetModelById(modelId).templateId;
                    TemplateDetailsWindow obj = new TemplateDetailsWindow(templateId);
                    obj.Show();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var modelId = (int)modelsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditModelWindow obj = new AddOrEditModelWindow(this, modelId);
                obj.Text = "Menedżer Floty - Edytuj Model";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla przycisku dodaj opiekę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCareButton_Click(object sender, EventArgs e)
        {
            ShowAddCareWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej opieki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void careDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var careId = (int)careDataGridView.Rows[row].Cells[1].Value;
                int userId = Care.GetCareByID(careId).keeperId;
                SzczegolyUser(userId);
            }
            else if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var careId = (int)careDataGridView.Rows[row].Cells[1].Value;
                int carId = Care.GetCareByID(careId).carId;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
            else if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var careId = (int)careDataGridView.Rows[row].Cells[1].Value;
                AddOrEditCareWindow obj = new AddOrEditCareWindow(this, careId);
                obj.Text = "Menedżer Floty - Edytuj Opiekę";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }


        /// <summary>
        /// Event Handler dla przycisku dodaj serwis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addServiceButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceWindow();
        }


        /// <summary>
        /// Event Handler dla tabeli zawierającej serwisy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void servicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var serviceId = (int)servicesDataGridView.Rows[row].Cells[1].Value;
                int servicePlaceId = Service.GetServiceById(serviceId).servicePlaceId;
                AddOrEditServicePlaceWindow obj = new AddOrEditServicePlaceWindow(this, servicePlaceId);
                obj.Text = "Menedżer Floty - Szczegóły miejsca serwisowego";
                obj.addButton.Visible = false;
                obj.approveButton.Visible = false;
                obj.companyNameTextBox.ReadOnly = true;
                obj.addressTextBox.ReadOnly = true;
                obj.Show();
            }
            else if (e.ColumnIndex == 6)
            {
                var row = e.RowIndex;
                var serviceId = (int)servicesDataGridView.Rows[row].Cells[1].Value;
                ServiceDetails obj = new ServiceDetails(serviceId);
                obj.Show();
            }
            else if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var serviceId = (int)servicesDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceWindow obj = new AddOrEditServiceWindow(this, serviceId);
                obj.Text = "Menedżer Floty - Edytuj Serwis";
                obj.addButton.Visible = false;
                obj.addServiceActionButton.Visible = false;
                obj.Show();
            }
        }

        /// <summary>
        /// Event Handler dla przycisku dodaj czynność serwisową
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addServiceActionButton_Click(object sender, EventArgs e)
        {
            ShowAddServiceActionWindow();
        }

        /// <summary>
        /// Event Handler dla tabeli zawierającej czynności serwisowe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceActionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var row = e.RowIndex;
                var serviceActionId = (int)ServiceActionsDataGridView.Rows[row].Cells[1].Value;
                int catalogId = ServiceAction.GetServiceActionById(serviceActionId).catalogId;
                CatalogDetailsWindow obj = new CatalogDetailsWindow(catalogId);
                obj.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                var row = e.RowIndex;
                var serviceActionId = (int)ServiceActionsDataGridView.Rows[row].Cells[1].Value;
                int serviceId = ServiceAction.GetServiceActionById(serviceActionId).serviceId;
                ServiceDetails obj = new ServiceDetails(serviceId);
                obj.Show();
            }
            else if (e.ColumnIndex == 7)
            {
                var row = e.RowIndex;
                var serviceActionId = (int)ServiceActionsDataGridView.Rows[row].Cells[1].Value;
                AddOrEditServiceActionWindow obj = new AddOrEditServiceActionWindow(this, serviceActionId);
                obj.Text = "Menedżer Floty - Edytuj Czynność Serwisową";
                obj.addButton.Visible = false;
                obj.Show();
            }
        }

        private void mainHelpButton_Click(object sender, EventArgs e)
        {
            if (!isLogged)
            {
                MessageBox.Show("Aplikacja ta służy do zarządzania flotą samochodową.\nZaloguj się, aby uzyskać dostęp do funkcjonalności.", "Menedżer Floty - Pomoc");
            }
            else
            {
                if (permissions == 'm')
                {
                    MessageBox.Show("Aplikacja ta służy do zarządzania flotą samochodową.\nW pomocy znajdziesz co możesz znaleźć w zakładkach głównego okna, każda zakładka ma również swoją własną pomoc opisującą ją. Klikając na link profil w górnej części okna możesz zobaczyć swój profil użytkonika i edytować go.\n\n-Pojazdy - możesz zobaczyć aktualnie posiadane przez flotę samochody oraz informacje o nich, możesz edytować informacje o tych samochodach i zarządzać nimi.\n\nKierowcy - możesz zobaczyć kierowców należących do firmy, możesz edytować informację o nich i zarządzać nimi.\n\nZlecenia - możesz zobaczyć jakie zlecenia były, są i będą przeprowadzane przez floty (wykonywanie serwisów, itp.) możesz je edytować i zarządzać nimi.\n\n-Finanse - możesz zobaczyć informacje finansowe o flocie, możesz sprawdzić jakie były koszty wybranej operacji w wybranym okresie.\n\n-Miejsca serwisowe możesz zobaczyć w jakich firmach wykonywane były serwisy samochodów floty, sprawdzić ich adres, edytować je i zarządzać tymi miejscami.\n\n-W oknie szablony możesz zobaczyć dostępne szablony wykonywania serwisów dla danych modeli samochodów, możesz edytować je i zarządzać nimi.\n\n-Szablonowe serwisy - zobaczysz wszystkie szablony wykonywania czynności serwisowych, możesz je edytować i zarządzać nimi.\n\nKatalogi - możesz przejrzeć katalogi zawierające wykonane czynności serwisowe oraz szablony wykonywania ich, możesz je edytować i zarządzać nimi.\n\n-Czynności serwisowe - możesz przejrzeć wszystkie wykonane czynności serwisowe, możesz je edytować i zarządzać nimi.\n\n-Serwisy - możesz przejrzeć wszystkie serwisy wykonane na samochodach floty, możesz je edytować i zarządzać nimi.\n\nModele - możesz przejrzeć wszystkie dostępne modele w ramach floty, możesz je edytować i zarządzać nimi.\n\n-Marki - możesz przejrzeć marki samochodów i odpowiadające im modele, możesz je edytować i zarządzać nimi.\n\n-Opieki - możesz przejrzeć wszystkie opieki samochodów i informacje o nich, możesz je edytować i zarządzać nimi.", "Menedżer Floty - Pomoc");
                }
                else if (permissions == 'o')
                {
                    MessageBox.Show("Aplikacja ta służy do zarządzania flotą samochodową.\nW pomocy znajdziesz co możesz znaleźć w zakładkach głównego okna, każda zakładka ma również swoją własną pomoc opisującą ją. Klikając na link profil w górnej części okna możesz zobaczyć swój profil użytkonika i edytować go.\n\n-Zlecenia - możesz zobaczyć jakie zlecenia były, są i będą przeprowadzane pod twoją opieką (wykonywanie serwisów, itp.) możesz je edytować i zarządzać nimi.\n\n-Kierowcy - możesz zobaczyć kierowców należących do firmy.\n\n-Pojazdy - możesz zobaczyć aktualnie posiadane przez flotę samochody oraz informacje o nich.", "Menedżer Floty - Pomoc");
                }
                else if (permissions == 'k')
                {
                    MessageBox.Show("Aplikacja ta służy do zarządzania flotą samochodową.\nW pomocy znajdziesz co możesz znaleźć w zakładkach głównego okna, każda zakładka ma również swoją własną pomoc opisującą ją. Klikając na link profil w górnej części okna możesz zobaczyć swój profil użytkonika i edytować go.\n\n-Zlecenia - możesz zobaczyć jakie zlecenia masz do wykonania (wykonywanie serwisów, itp.).\n\n-Rezerwuj - możesz zobaczyć swoje rezerwacje samochodów i zarządzać nimi.\n\n", "Menedżer Floty - Pomoc");
                }
            }
        }

        private void oTabelaZlecenia_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                var row = e.RowIndex;
                var orderId = (int)oTabelaZlecenia.Rows[row].Cells[1].Value;
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this, orderId);
                obj.Text = "Menedżer Floty - Edytuj Zlecenie";
                obj.addButton.Visible = false;
                obj.addServiceButton.Visible = false;
                obj.Show();
            }
            else if (e.ColumnIndex == 2)
            {
                var row = e.RowIndex;
                var orderId = (int)oTabelaZlecenia.Rows[row].Cells[1].Value;
                var careId = Order.GetOrderById(orderId).careId;
                var carId = Care.GetCareByID(careId).carId;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
        }

        private void ordersKHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie twoje zlecenia. Klikając na linki w tabeli zobaczysz szczegóły danego elementu, szczegóły zleceń są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Zlecenia");
        }

        private void kTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var row = e.RowIndex;
                var orderId = (int)kTabelaZlecenia.Rows[row].Cells[0].Value;
                var careId = Order.GetOrderById(orderId).careId;
                var carId = Care.GetCareByID(careId).carId;
                CarDetailsWindow obj = new CarDetailsWindow(carId);
                obj.Show();
            }
            else if (e.ColumnIndex == 11)
            {
                var row = e.RowIndex;
                var orderId = (int)kTabelaZlecenia.Rows[row].Cells[0].Value;
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow(this, orderId);
                obj.addButton.Visible = false;
                obj.acceptButton.Visible = false;
                obj.addServiceButton.Visible = false;
                obj.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie pojazdy floty. Możesz zarządzać pojazdami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły pojazdów są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Pojazdy");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazani wszyscy kierowcy floty. Możesz zarządzać kierowcami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły kierowców są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Kierowcy");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie zlecenia. Możesz zarządzać zleceniami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły zleceń są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Zlecenia");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce są pokazane finanse floty. Wybierając odpoweidnie pozycje i naciskając przycisk generuj koszty otrzymasz koszty wybranych czynności w wybranym okresie", "Menedżer Floty - Pomoc Finanse");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie miejsca serwisu odwiedzane przez flotę. Możesz zarządzać miejscami serwisu przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły miejsc serwisu są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Miejsca Serwisowe");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie szablony z szablonowymi czynnościami serwisowymi floty. Możesz zarządzać szablonami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły szablonów są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Szablony");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie szablonowe czynności serwisowe samochodów floty. Możesz zarządzać szablonowymi czynnościami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły szablonowych czynności są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Szablonowe serwisy");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie katalogi z szablonowymi czynnościami serwisowymi i tymi faktycznie wykonanymi na samochodach floty. Możesz zarządzać katalogami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły katalogów są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pomoc Katalogi");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie czynności serwisowe wykonane na samochodach floty. Możesz zarządzać czynnościami serwisowymi przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły czynności serwisowych są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Czynności Serwisowe");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie serwisy z czynnościami serwisowymi wykonanymi na samochodach floty. Możesz zarządzać serwisami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły serwisów są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Serwisy");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie modele samochodów floty. Możesz zarządzać modelami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły modeli są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Modele");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie marki samochodów floty. Możesz zarządzać markami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły marek są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Marki");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie opieki samochodów floty. Możesz zarządzać opiekami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły opiek są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Opieki");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie twoje rezerwacje samochodów floty.", "Menedżer Floty - Rezerwacje");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie zlecenia wykonywane pod twoją opieką. Możesz zarządzać zleceniami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, edycje/szczegóły zleceń są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Zlecenia");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazani wszyscy kierowcy floty. Możesz zarządzać kierowcami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, szczegóły kierowców są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Kierowcy");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tej zakładce w tabeli są pokazane wszystkie pojazdy floty, których jesteś opiekunem. Możesz zarządzać pojazdami przyciskami po prawej stronie, klikając na linki w tabeli zobaczysz szczegóły danego elementu, szczegóły pojazdów są dostępne po naciśnięciu oznaczonych przycisków w tabeli.", "Menedżer Floty - Pojazdy");
        }
    }
}