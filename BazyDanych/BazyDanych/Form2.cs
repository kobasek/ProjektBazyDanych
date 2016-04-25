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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            tabControl1.Hide();
            linkLabel1.Hide();
            linkLabel2.Hide();
            linkLabel3.Text = "Zaloguj";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1(this);
            obj.Show();
        }
    }
}
