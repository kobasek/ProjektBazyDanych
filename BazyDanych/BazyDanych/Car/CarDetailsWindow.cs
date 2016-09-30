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
    /// Klasa formularza wyświetlającego okno szczegółów samochodu
    /// </summary>
	public partial class CarDetailsWindow : Form
	{
		private Car car;
		public CarDetailsWindow()
		{
			InitializeComponent();
		}

		public CarDetailsWindow(int carId)
		{
			InitializeComponent();
			car = Car.GetCarById(carId);
			SetCarDetails();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			vehicleCondition obj = new vehicleCondition();
			obj.Show();
		}

		private void SetCarDetails()
		{
			var model = Model.GetModelById(car.modelId);
			var brand = Brand.GetBrandById(model.brandId);

			textBox1.Text = brand.name;
			textBox2.Text = model.name;
			textBox3.Text = car.vin;
			textBox4.Text = car.registrationNumber;
			textBox5.Text = car.costOfPurchase.ToString();
			textBox6.Text = car.dateOfPurchase.ToString();
			textBox7.Text = car.dateOfScrapping.ToString();
			textBox8.Text = "Janusz";
			textBox9.Text = car.engineCapacity.ToString();
			textBox10.Text = car.typeOfFuel.ToString();
			textBox11.Text = car.automaticGearBox ? "TAK" : "NIE";
			textBox12.Text = car.airCondition ? "TAK" : "NIE";
			textBox13.Text = car.assistance ? "TAK" : "NIE";
			textBox14.Text = car.electricWindows ? "TAK" : "NIE";
		}
	}
}
