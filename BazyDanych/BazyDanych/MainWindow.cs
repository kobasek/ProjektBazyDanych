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
			var list = Car.GetCarList();
			foreach (var car in list)
			{
				var model = Model.GetModelById(car.modelId);
				var brand = Brand.GetBrandById(model.brandId);
				klasaTestowaBindingSource.Add(new KlasaTestowa(car.id, brand.name, model.name, "Janusz"));
			}
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
			obj.buttonDodajPojazd.Visible = false;
			obj.buttonWczytajSzablon.Visible = false;
			obj.buttonZapiszSzablon.Visible = false;
			obj.Show();
		}

		private void DodajAuto()
		{
			var obj = new AddOrEditCarWindow(this);
			obj.Text = "Menedżer Floty - Dodaj pojazd";
			obj.buttonZatwierdzZmiany.Visible = false;
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
				EdytujAuto();
			}
			else if (e.ColumnIndex == 6)
			{
				ScheduleWindow obj = new ScheduleWindow();
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
			ProfilWindow obj = new ProfilWindow();
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
					klasaTestowaBindingSource.Add(new KlasaTestowa(car.id, brand.name, model.name, "Janusz"));
				}

			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				throw ex;
			}
		}
	}
}
