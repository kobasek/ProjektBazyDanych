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


        private void InitializeComponentStart()
        private void Form2_Load(object sender, EventArgs e)
        {
            klasaTestowaBindingSource.Add(new KlasaTestowa(1, "Opel", "Astra", "Janusz"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(2, "Mercedes", "Vito", "Filip"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(3, "Fiat", "Panda", "Marek"));
  
     
        }
       
        


        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.panelS.Visible = true;
            this.panelM.Visible = false;
            this.panelO.Visible = false;
            this.panelK.Visible = false;
        }

        public void InitializeComponentMenadzer()
        {
            this.panelS.Visible = false;
            this.panelM.Visible = true;
        }

        public void InitializeComponentOpieka()
        {
            this.panelS.Visible = false;
            this.panelO.Visible = true;
        }

        public void InitializeComponentKierowca()
        {
            this.panelS.Visible = false;
            this.panelK.Visible = true;
        }

        private void zalogujSLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 obj = new Form1(this);
            obj.Show();
        }

        private void wylogujKLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panelS.Visible = true;
            this.panelM.Visible = false;
            this.panelO.Visible = false;
            this.panelK.Visible = false;
        }

        private void powiadomieniaKLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void profilKLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void wylogujOLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panelS.Visible = true;
            this.panelM.Visible = false;
            this.panelO.Visible = false;
            this.panelK.Visible = false;
        }

        private void powiadomieniaOLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void profilOLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void profilMLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void wylogujMLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panelS.Visible = true;
            this.panelM.Visible = false;
            this.panelO.Visible = false;
            this.panelK.Visible = false;
        }

        private void powiadomieniaMLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
