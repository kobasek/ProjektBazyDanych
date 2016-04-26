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
    public partial class MainWindow : Form
    {
        public char uprawnienia;

        public MainWindow()
        {
            InitializeComponent();
            InitializeComponentStart();
        }


        
        private void Form2_Load(object sender, EventArgs e)
        {
            klasaTestowaBindingSource.Add(new KlasaTestowa(1, "Opel", "Astra", "Janusz"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(2, "Mercedes", "Vito", "Filip"));
            klasaTestowaBindingSource.Add(new KlasaTestowa(3, "Fiat", "Panda", "Marek"));
  
     
        }




        private void InitializeComponentStart()
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
            LoginWindow obj = new LoginWindow(this);
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

        private void EdytujAuto()
        {
            AddCarWindow obj = new AddCarWindow();
            obj.Text = "Menedżer Floty - Edytuj pojazd";
            obj.label14.Visible = false;
            obj.dateTimePicker2.Visible = false;
            obj.buttonDodajPojazd.Visible = false;
            obj.buttonWczytajSzablon.Visible = false;
            obj.buttonZapiszSzablon.Visible = false;
            obj.Show();
        }

        private void DodajAuto()
        {
            AddCarWindow obj = new AddCarWindow();
            obj.Text = "Menedżer Floty - Dodaj pojazd";
            obj.buttonZatwierdzZmiany.Visible = false;
            obj.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                deleteButtonMPojazdy.Enabled = true;
            } else if (e.ColumnIndex == 7)
            {
                EdytujAuto();
            } else if(e.ColumnIndex == 5)
            {
                ScheduleWindow obj = new ScheduleWindow();
                obj.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajAuto();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void klasaTestowaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void oTabelaPojazdy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void oTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
                obj.button2.Visible = false;
                obj.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
            obj.button1.Visible = false;
            obj.Show();
        }

        private void mTabelaZlecenia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
                obj.button2.Visible = false;
                obj.Show();
            }
        }

        private void addButtonMZlecenia_Click(object sender, EventArgs e)
        {
            AddOrEditOrderWindow obj = new AddOrEditOrderWindow();
            obj.button1.Visible = false;
            obj.Show();
        }
    }
}
