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
    public partial class ScheduleWindow : Form
    {
        string[] months;


        //Terminarz
        public ScheduleWindow()
        {
            months = new string[12] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };


            InitializeComponent();
            
        }

        private string GetActualMonth()
        {
            
            return months[DateTime.Now.Month];
        }

        private void SetMonthPanel()
        {

        }
    }

    
}
