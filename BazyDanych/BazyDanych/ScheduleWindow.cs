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
        string[] Months;


        //Terminarz
        public ScheduleWindow()
        {
            InitializeComponent();
            Months = new string[12] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
        }

        private string GetActualMonth()
        {
            return "month";
        }
    }

    
}
