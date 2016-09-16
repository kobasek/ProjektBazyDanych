﻿using System;
using System.Windows.Forms;

namespace BazyDanych
{
	//Okno dodawania oraz edycji pojazdu
	public partial class AddOrEditCarWindow : Form
	{
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
			comboBoxModel.Items.Clear();
			var markaId = (int)((ComboBoxItem) comboBoxMarka.SelectedItem).Value;

			var modelList = Model.GetModelListForBrand(markaId);
			foreach (var model in modelList)
			{
				var comboBoxItem = new ComboBoxItem();
				comboBoxItem.Text = model.name;
				comboBoxItem.Value = model.id;
				comboBoxModel.Items.Add(comboBoxItem);
			}
		}
	}
}
