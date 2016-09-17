﻿using System;
using System.Windows.Forms;

namespace BazyDanych
{
	//Okno dodawania oraz edycji pojazdu
	public partial class AddOrEditCarWindow : Form
	{
		private Car car;

		public AddOrEditCarWindow(int carId)
		{
			InitializeComponent();
			EditInitialize(carId);
		}

		public AddOrEditCarWindow()
		{
			InitializeComponent();
			var brandList = Brand.GetBrandList();
			foreach (var brand in brandList)
			{
				var comboBoxItem = new ComboBoxItem();
				comboBoxItem.Text = brand.name;
				comboBoxItem.Value = brand.id;
				comboBoxMarka.Items.Add(comboBoxItem);
			}
		}

		public AddOrEditCarWindow(MainWindow mainWindow)
		{
			InitializeComponent();
			main = mainWindow;
			var brandList = Brand.GetBrandList();
			foreach (var brand in brandList)
			{
				var comboBoxItem = new ComboBoxItem();
				comboBoxItem.Text = brand.name;
				comboBoxItem.Value = brand.id;
				comboBoxMarka.Items.Add(comboBoxItem);
			}
		}

		private void buttonDodajPojazd_Click(object sender, EventArgs e)
		{
			var errorNumber = 0;
			var errorMessage = "";
			var isError = false;
			var carDto = new CarDto();

			if (comboBoxModel.SelectedItem != null)
			{
				carDto.ModelId = (int)((ComboBoxItem)comboBoxModel.SelectedItem).Value; ;
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Należy wybrać model.\n";
			}

			if (textBoxVIN.TextLength == 17)
			{
				carDto.Vin = textBoxVIN.Text;
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Niepoprawny numer VIN.\n";
			}

			if (comboBoxTypNadwozia.SelectedItem != null)
			{
				carDto.TypeOfBody = comboBoxTypNadwozia.Text;
			}

			if (textBox1.TextLength == 7)
			{
				carDto.RegistrationNumber = textBox1.Text;
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Niepoprawny numer rejestracyjny.\n";
			}

			if (textBoxKoszt.TextLength != 0)
			{
				try
				{
					carDto.CostOfPurchase = decimal.Parse(textBoxKoszt.Text);
				}
				catch (FormatException)
				{
					isError = true;
					errorNumber++;
					errorMessage += errorNumber + ". Niepoprawna wartość w polu Koszt.\n";
				}
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Należy podać koszt.\n";
			}

			carDto.DateOfPurchase = dateTimePicker1.Value;

			if (textBoxPojemnosc.TextLength != 0)
			{
				try
				{
					carDto.EngineCapacity = float.Parse(textBoxPojemnosc.Text);
				}
				catch (FormatException)
				{
					isError = true;
					errorNumber++;
					errorMessage += errorNumber + ". Niepoprawna wartość w polu Pojemność silnika.\n";
				}
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Należy podać pojemność.\n";
			}

			switch (comboBoxPaliwo.SelectedIndex)
			{
				case 0:
					carDto.TypeOfFuel = 'D';
					break;
				case 1:
					carDto.TypeOfFuel = 'B';
					break;
				case 2:
					carDto.TypeOfFuel = 'L';
					break;
				case 3:
					carDto.TypeOfFuel = 'G';
					break;
				case 4:
					carDto.TypeOfFuel = 'E';
					break;
				case 5:
					carDto.TypeOfFuel = 'H';
					break;
			}

			carDto.AutomaticGearBox = comboBoxSkrzynia.SelectedIndex == 0;

			carDto.AirCondition = comboBoxKlimatyzacja.SelectedIndex == 0;

			carDto.Assistance = comboBoxWspomaganie.SelectedIndex == 0;

			carDto.ElectricWindows = comboBoxSzyby.SelectedIndex == 0;

			if (isError)
			{
				MessageBox.Show(errorMessage);
			}
			else
			{
				try
				{
					main.AddCarToDatabase(carDto);
					Close();
				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{

					MessageBox.Show("Dodawanie pojazdu nie powiodło się!");
				}
				
			}
		}

		private void comboBoxMarka_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			var markaId = (int)((ComboBoxItem) comboBoxMarka.SelectedItem).Value;

			comboBoxModel.Items.Clear();
			var modelList = Model.GetModelListForBrand(markaId);
			foreach (var model in modelList)
			{
				var comboBoxItem = new ComboBoxItem();
				comboBoxItem.Text = model.name;
				comboBoxItem.Value = model.id;
				comboBoxModel.Items.Add(comboBoxItem);
			}
		}

		private void EditInitialize(int carId)
		{
			car = Car.GetCarById(carId);
			var model = Model.GetModelById(car.modelId);
			var brand = Brand.GetBrandById(model.brandId);

			var comboBoxBr = new ComboBoxItem(brand.name, brand.id);
			var comboBoxMod = new ComboBoxItem(model.name, model.id);


			label10.Text = "Data złomowania";
			label10.Location = new System.Drawing.Point(73, 151);

			comboBoxMarka.Items.Insert(0, comboBoxBr);
			comboBoxMarka.SelectedIndex = 0;
			comboBoxMarka.Enabled = false;

			comboBoxModel.Items.Insert(0, comboBoxMod);
			comboBoxModel.SelectedIndex = 0;
			comboBoxModel.Enabled = false;

			textBoxVIN.Text = car.vin;
			textBoxVIN.Enabled = false;

			textBox1.Text = car.registrationNumber;

			textBoxKoszt.Text = car.costOfPurchase.ToString();
			textBoxKoszt.Enabled = false;

			dateTimePicker1.ShowCheckBox = true;
			dateTimePicker1.Checked = false;

			comboBox1.Text = "Janusz";

			textBoxPojemnosc.Text = car.engineCapacity.ToString();
			textBoxPojemnosc.Enabled = false;

			comboBoxTypNadwozia.Text = car.typeOfBody;
			comboBoxTypNadwozia.Enabled = false;

			switch (car.typeOfFuel)
			{
				case 'D':
					comboBoxPaliwo.Text = "ROPA";
					comboBoxPaliwo.Enabled = false;
					break;
				case 'B':
					comboBoxPaliwo.Items.Clear();
					comboBoxPaliwo.Items.AddRange(new object[] { "BENZYNA", "BENZYNA + LPG" });
					comboBoxPaliwo.Text = "BENZYNA";
					break;
				case 'L':
					comboBoxPaliwo.Text = "LPG";
					comboBoxPaliwo.Enabled = false;
					break;
				case 'G':
					comboBoxPaliwo.Text = "BENZYNA + LPG";
					comboBoxPaliwo.Enabled = false;
					break;
				case 'E':
					comboBoxPaliwo.Text = "ENERGIA ELEKTRYCZNA";
					comboBoxPaliwo.Enabled = false;
					break;
				case 'H':
					comboBoxPaliwo.Text = "HYBRYDA";
					comboBoxPaliwo.Enabled = false;
					break;
			}

			comboBoxKlimatyzacja.Text = car.airCondition ? "TAK" : "NIE";
			comboBoxKlimatyzacja.Enabled = false;

			comboBoxSkrzynia.Text = car.automaticGearBox ? "TAK" : "NIE";
			comboBoxSkrzynia.Enabled = false;

			comboBoxSzyby.Text = car.electricWindows ? "TAK" : "NIE";
			comboBoxSzyby.Enabled = false;

			comboBoxWspomaganie.Text = car.assistance ? "TAK" : "NIE";
			comboBoxWspomaganie.Enabled = false;
		}

		private void buttonZatwierdzZmiany_Click(object sender, EventArgs e)
		{
			var carDto = new CarDto();
			var isError = false;
			var errorNumber = 0;
			var errorMessage = "";

			carDto.Id = car.id;

			if (textBox1.TextLength == 7)
			{
				carDto.RegistrationNumber = textBox1.Text;
			}
			else
			{
				isError = true;
				errorNumber++;
				errorMessage += errorNumber + ". Niepoprawny numer rejestracyjny.\n";
			}

			carDto.DateOfScrapping = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?) null;

			if (comboBoxPaliwo.Enabled)
			{
				switch (comboBoxPaliwo.SelectedIndex)
				{
					case 0:
						carDto.TypeOfFuel = 'B';
						break;
					case 1:
						carDto.TypeOfFuel = 'L';
						break;
				}
			}
			else
			{
				carDto.TypeOfFuel = car.typeOfFuel;
			}

			if (isError)
			{
				MessageBox.Show(errorMessage);
			}
			else
			{
				try
				{
					Car.UpdateCar(carDto);
					Close();
				}
				catch (MySql.Data.MySqlClient.MySqlException ex)
				{

					MessageBox.Show("Edytowanie pojazdu nie powiodło się!");
				}

			}
		}
	}
}
