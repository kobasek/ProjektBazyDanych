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
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponentStart();
            isLogged = false;
            profilLabel.Visible = false;
            powiadomieniaLabel.Visible = false;
        }


        
        private void Form2_Load(object sender, EventArgs e)
        {
            klasaTestowaBindingSource.Add(new KlasaTestowa(1, "Opel", "Astra", "Janusz"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(2, "Mercedes", "Vito", "Filip"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(3, "Fiat", "Panda", "Marek"));
  
     
        }




        private void InitializeComponentStart()
        {
            this.panelS.Visible = true;
            this.panelS.SendToBack();
            this.panelM.Visible = false;
            this.panelO.Visible = false;
            this.panelK.Visible = false;
        }

        public void InitializeComponentMenadzer()
        {
            this.panelM.Visible = true;
            this.powiadomieniaLabel.Visible = true;
            this.profilLabel.Visible = true;
            this.logowanieLabel.Text = "Wyloguj";
        }

        public void InitializeComponentOpieka()
        {
            this.panelO.Visible = true;
            this.powiadomieniaLabel.Visible = true;
            this.profilLabel.Visible = true;
            this.logowanieLabel.Text = "Wyloguj";
        }

        public void InitializeComponentKierowca()
        {
            this.panelK.Visible = true;
            this.powiadomieniaLabel.Visible = true;
            this.profilLabel.Visible = true;
            this.logowanieLabel.Text = "Wyloguj";
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
                this.powiadomieniaLabel.Visible = false;
                this.profilLabel.Visible = false;
                isLogged = false;
            }
        }

        private void EdytujAuto()
        {
            AddOrEditCarWindow obj = new AddOrEditCarWindow();
            obj.Text = "Menedżer Floty - Edytuj pojazd";
            obj.label14.Visible = false;
            obj.dateTimePicker2.Visible = false;
            obj.buttonDodajPojazd.Visible = false;
            obj.buttonWczytajSzablon.Visible = false;
            obj.buttonZapiszSzablon.Visible = false;
            obj.Show();
        }

        private void DodajAuto()
        {
            AddOrEditCarWindow obj = new AddOrEditCarWindow();
            obj.Text = "Menedżer Floty - Dodaj pojazd";
            obj.buttonZatwierdzZmiany.Visible = false;
            obj.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                deleteButtonMPojazdy.Enabled = true;
            } else if (e.ColumnIndex == 7)
            {
                EdytujAuto();
            } else if(e.ColumnIndex == 6)
            {
                ScheduleWindow obj = new ScheduleWindow();
                obj.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                CarDetailsWindow obj = new CarDetailsWindow();
                obj.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajAuto();
        }

        private void klasaTestowaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

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
                ScheduleWindow obj = new ScheduleWindow();
                obj.Show();
            }
        }

        private void oTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
                obj.button2.Visible = false;
                obj.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
            obj.button1.Visible = false;
            obj.Show();
        }

        private void mTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
                obj.Text = "Menedżer Floty - Edytuj Zlecenie";
                obj.button2.Visible = false;
                obj.Show();
            }
        }

        private void addButtonMZlecenia_Click(object sender, EventArgs e)
        {
            AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
            obj.Text = "Menedżer Floty - Dodaj Zlecenie";
            obj.button1.Visible = false;
            obj.Show();
        }

        private void mTabelaKierowcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                AddOrEditUserWindow obj = new AddOrEditUserWindow();
                obj.Text = "Menedżer Floty - Edytuj Użytkownika";
                obj.button1.Visible = false;
                obj.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                ScheduleWindow obj = new ScheduleWindow();
                obj.Show();
            }

        }

        private void addButtonMKierowcy_Click(object sender, EventArgs e)
        {
            AddOrEditUserWindow obj = new AddOrEditUserWindow();
            obj.Text = "Menedżer Floty - Dodaj Użytkownika";
            obj.button2.Visible = false;
            obj.Show();
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
                ScheduleWindow obj = new ScheduleWindow();
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
                ScheduleWindow obj = new ScheduleWindow();
                obj.Show();
            }
        }

        private void powiadomieniaLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NotificationsWindow obj = new NotificationsWindow();
            obj.Show();
        }

		private void profilLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ProfileInfo profile = new ProfileInfo();
			profile.Show();
		}
    }
}
