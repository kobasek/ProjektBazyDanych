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
    public partial class AddOrEditTemplateWindow : Form
    {
        private MainWindow mainWindow;
        private Template template;

        public AddOrEditTemplateWindow()
        {
            InitializeComponent();
        }

        public AddOrEditTemplateWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public AddOrEditTemplateWindow(MainWindow mainWindow, int templateId)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            template = Template.GetTemplateById(templateId);
            nameTextBox.Text = template.name;
        }

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

                    MessageBox.Show("Edytowanie pojazdu nie powiodło się!");
                }
            }
        }
    }
}
