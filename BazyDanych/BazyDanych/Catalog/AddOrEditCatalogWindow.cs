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
    /// Klasa formularza wyświetlającego okno dodawania/edycji katalogu
    /// </summary>
    public partial class AddOrEditCatalogWindow : Form
    {
        private MainWindow mainWindow;
        private Catalog catalog;

        public AddOrEditCatalogWindow()
        {
            InitializeComponent();
        }

        public AddOrEditCatalogWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public AddOrEditCatalogWindow(MainWindow mainWindow, int catalogId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            catalog = Catalog.GetCatalogById(catalogId);
            nameTextBox.Text = catalog.name;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var catallogDto = new CatalogDto();

            if (nameTextBox.Text != "")
            {
                catallogDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę katalogu.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddCatalogToDatabase(catallogDto);
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Dodawanie katalogu nie powiodło się!");
                }
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var catalogDto = new CatalogDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            catalogDto.Id = catalog.id;

            if (nameTextBox.Text != "")
            {
                catalogDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę katalogu.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Catalog.UpdateCatalog(catalogDto);
                    mainWindow.UpdateCatalog();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Edytowanie katalogu nie powiodło się!");
                }
            }
        }
    }
}
