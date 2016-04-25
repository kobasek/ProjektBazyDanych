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
    public partial class Form1 : Form
    {
        private Form2 obj;
        public Form1(Form2 obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            obj.tabControl1.Show();
            obj.linkLabel1.Show();
            obj.linkLabel2.Show();
            obj.linkLabel3.Text = "Wyloguj";
            this.Close();
          
        }
    }
}
