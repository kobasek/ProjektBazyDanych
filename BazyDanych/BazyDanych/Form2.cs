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
            this.Column6.Selected = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            klasaTestowaBindingSource.Add(new KlasaTestowa(1, "Opel", "Astra", "Janusz"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(2, "Mercedes", "Vito", "Filip"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(3, "Fiat", "Panda", "Marek"));
  
     
        }
       
        


        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        
    }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
        }

       
        private void klasaTestowaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString());
        }
    }
}
