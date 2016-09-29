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
    /// Klasa formularza wyświetlającego okno dodawania/edycji szablonu
    /// </summary>
    public partial class AddOrEditTemplateWindow : Form
    {
        private MainWindow mainWindow;
        private Template template;

        /// <summary>
        /// Bezparametrowy konstruktor klasy formularza wyświatlającego okno dodawania/edycji szablonu
        /// </summary>
        public AddOrEditTemplateWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Jednoparametrowy konstruktor klasy formularza wyświatlającego okno dodawania/edycji szablonu
        /// </summary>
        /// <param name="mainWindow">Uchwyt do głównego okna programu</param>
        public AddOrEditTemplateWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        /// <summary>
        /// Dwuparametrowy konstruktor klasy formularza wyświatlającego okno dodawania/edycji szablonu
        /// </summary>
        /// <param name="mainWindow">Uchwyt do głównego okna programu</param>
        /// <param name="templateId">ID szablonu, który chcemy edytować</param>
        public AddOrEditTemplateWindow(MainWindow mainWindow, int templateId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            template = Template.GetTemplateById(templateId);
            nameTextBox.Text = template.name;
        }

        /// <summary>
        /// Event Handler przycisku potwierdzającego dodanie szablonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            var errorNumber = 0;
            var errorMessage = "";
            var isError = false;
            var templateDto = new TemplateDto();

            if (nameTextBox.Text != "")
            {
                templateDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Należy podać nazwę szablonu.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    mainWindow.AddTemplateToDatabase(templateDto);
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {
                    MessageBox.Show("Dodawanie szablonu nie powiodło się!");
                }
            }
        }

        /// <summary>
        /// Event Handler przycisku potwierdzającego edycję szablonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptButton_Click(object sender, EventArgs e)
        {
            var templateDto = new TemplateDto();
            var isError = false;
            var errorNumber = 0;
            var errorMessage = "";

            templateDto.Id = template.id;

            if (nameTextBox.Text != "")
            {
                templateDto.Name = nameTextBox.Text;
            }
            else
            {
                isError = true;
                errorNumber++;
                errorMessage += errorNumber + ". Podaj nazwę szablonu.\n";
            }

            if (isError)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                try
                {
                    Template.UpdateTemplate(templateDto);
                    mainWindow.UpdateTemplate();
                    Close();
                }
                #pragma warning disable 0168
                catch (MySql.Data.MySqlClient.MySqlException ex)
                #pragma warning restore 0168
                {

                    MessageBox.Show("Edytowanie szablonu nie powiodło się!");
                }
            }
        }
    }
}
