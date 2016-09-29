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
    public partial class AddOrEditBrandWindow : Form
    {
        private MainWindow mainWindow;
        private Brand brand;

        public AddOrEditBrandWindow()
        {
            InitializeComponent();
        }

        public AddOrEditBrandWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public AddOrEditBrandWindow(MainWindow mainWindow, int brandId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            brand = Brand.GetBrandById(brandId);
            nameTextBox.Text = brand.name;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var brandDto = new BrandDto();

            if (nameTextBox.Text != "")
            {
                brandDto.name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę marki.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddBrandToDatabase(brandDto);
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Dodawanie marki nie powiodło się!");
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var brandDto = new BrandDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            brandDto.id = brand.id;

            if (nameTextBox.Text != "")
            {
                brandDto.name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę marki.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Brand.UpdateBrand(brandDto);
                    mainWindow.UpdateBrand();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {
                    MessageBox.Show("Edytowanie marki nie powiodło się!");
                }
            }
        }
    }
}
