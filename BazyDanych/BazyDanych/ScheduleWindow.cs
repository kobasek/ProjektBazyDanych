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
        private int idCar;
        string[] months;
        int shownMonth;
        int shownYear;
        int firstPanelIndex = 0;
        int lastPanelIndex = 41;
        int firstLabel = 10;
        


        //Terminarz
        public ScheduleWindow(int _idCar)
        {
            this.idCar = _idCar;
            this.months = new string[12] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
            this.shownMonth = DateTime.Now.Month;
            this.shownYear = DateTime.Now.Year;

            InitializeComponent();
            SetTopPanel(shownMonth, shownYear);
            FillPanels();


        }

        private void SetTopPanel(int month, int year)
        {
            this.label8.Text = months[month-1];
            this.label9.Text = year.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shownMonth += 1;
            if (shownMonth > 12)
            {
                shownMonth = 1;
                shownYear += 1;
            }
            UpdateScheduleWindow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shownMonth -= 1;
            if (shownMonth < 1)
            {
                shownMonth = 12;
                shownYear -= 1;
            }
            UpdateScheduleWindow();
        }

        private void UpdateScheduleWindow()
        {

            SetTopPanel(shownMonth, shownYear);
            FillPanels();
        }

        private void FillPanels()
        {
            var data = new DateTime(shownYear, shownMonth, 1);
            int firstLabelPom = firstLabel;
            int firstDayOfMonth = GetDayOfWeek(data.DayOfWeek.ToString());
            int daysInMonth = DateTime.DaysInMonth(shownYear, shownMonth);
            int labelCounter = 1;
            int labelCounterHigher = 1;
            int labelCounterSmaler;
            if (shownMonth == 1)
                labelCounterSmaler = DateTime.DaysInMonth(shownYear-1, 12)-firstDayOfMonth+1;   
            else
                labelCounterSmaler = DateTime.DaysInMonth(shownYear, shownMonth - 1) - firstDayOfMonth + 1;

            for (int i = firstPanelIndex; i <= lastPanelIndex; i++)
            {
                if(i >= firstDayOfMonth && i < firstDayOfMonth + daysInMonth)
                {
                    var panelColour = this.Controls.OfType<Control>()
                    .Where(panel => panel.TabIndex == i)
                    .Select(panel =>
                    {
                        panel.BackColor = Color.Aquamarine;
                        return panel;
                    })
                    .First();
                    Label test = this.Controls.Find("Label" + (firstLabelPom + labelCounter-1).ToString(), true).FirstOrDefault() as Label;
                    test.Text = labelCounter.ToString();
                    labelCounter++;
                }

                else if(i < firstDayOfMonth)
                {
                    var panelColour = this.Controls.OfType<Control>()
                    .Where(panel => panel.TabIndex == i)
                    .Select(panel => { panel.BackColor = Color.White; return panel; })
                    .First();
                    Label test = this.Controls.Find("Label" + firstLabelPom.ToString(), true).FirstOrDefault() as Label;
                    test.Text = labelCounterSmaler.ToString();
                    labelCounterSmaler++;
                    firstLabelPom++;
                }
                else if (i >= firstDayOfMonth + daysInMonth)
                {
                    var panelColour = this.Controls.OfType<Control>()
                    .Where(panel => panel.TabIndex == i)
                    .Select(panel => { panel.BackColor = Color.White; return panel; })
                    .First();
                    Label test = this.Controls.Find("Label" + (firstLabelPom + labelCounter-1).ToString(), true).FirstOrDefault() as Label;
                    test.Text = labelCounterHigher.ToString();
                    labelCounterHigher++;
                    labelCounter++;
                }
            }      
        }

        private int GetDayOfWeek(string day)
        {
            int pom = 9;
            switch(day)
            {
                case "Monday":
                    pom = 0;
                    break;
                case "Tuesday":
                    pom = 1;
                    break;
                case "Wednesday":
                    pom = 2;
                    break;
                case "Thursday":
                    pom = 3;
                    break;
                case "Friday":
                    pom = 4;
                    break;
                case "Saturday":
                    pom = 5;
                    break;
                case "Sunday":
                    pom = 6;
                    break;
            }
            return pom;
        }
    }   
}
