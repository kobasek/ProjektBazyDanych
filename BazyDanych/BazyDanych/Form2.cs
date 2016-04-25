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

    //Okienko główne
    public partial class Form2 : Form
    {
        public char uprawnienia;

        public Form2()
        {
            InitializeComponent();
            InitializeComponentStart();
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

        private void InitializeComponentStart()
        {
            this.tabControl1.Hide();
            this.linkLabel1.Hide();
            this.linkLabel2.Hide();
            this.linkLabel3.Text = "Zaloguj";
        }

        public void InitializeComponentMenadzer()
        {
            this.tabControl1.Show();
            this.linkLabel1.Show();
            this.linkLabel2.Show();
            this.linkLabel3.Text = "Wyloguj";
        }

        public void InitializeComponentOpieka()
        {
            this.tabControl1.Show();
            this.linkLabel1.Show();
            this.linkLabel2.Show();
            this.linkLabel3.Text = "Wyloguj";
        }

        public void InitializeComponentKierowca()
        {
            this.tabControl1.Show();
            this.linkLabel1.Show();
            this.linkLabel2.Show();
            this.linkLabel3.Text = "Wyloguj";
        }
    }
}
