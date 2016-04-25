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
    //Okienko odpowiedzialne za logowanie
    public partial class Form1 : Form
    {
        private Form2 obj;
        public Form1(Form2 obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        //m - menadżer, o - opiekun, k - kierowca
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (this.usernameTextBox.Text == "")
                MessageBox.Show("W pole Login wpisz uprawnienia: \nm - aby zalogować się jako menadżer\no - aby zalogować się jako opiekun\nk - aby zalogować się jako kierowca");

            else if (this.usernameTextBox.Text == "m")
            {
                obj.InitializeComponentMenadzer();
                this.Close();
            }
            else if (this.usernameTextBox.Text == "o")
            {
                obj.InitializeComponentOpieka();
                this.Close();
            }

            else if (this.usernameTextBox.Text == "k")
            {
                obj.InitializeComponentKierowca();
                this.Close();
            }
               
            
          
        }
    }
}
