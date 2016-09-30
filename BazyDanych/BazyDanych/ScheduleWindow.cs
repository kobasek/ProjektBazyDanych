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
    /// <summary>
    /// Klasa formularza wyświatlającego terminarz
    /// </summary>
    public partial class ScheduleWindow : Form
    {
        private int id;
        private char type;
        string[] months;
        int shownMonth;
        int shownYear;
        int firstPanelIndex = 0;
        int lastPanelIndex = 41;
        int firstLabel = 10;



        /// <summary>
        /// Dwuparametrowy konstruktor klasy formularza wyświatlającego terminarz
        /// </summary>
        /// <param name="_id">ID kierowcy bądź samochodu dla którego terminarz ma być wygenerowany</param>
        /// <param name="_type">Pole określające, czy terminarz wyświetlany jest dla kierowcy (D) czy dla samochodu (C)</param>
        public ScheduleWindow(int _id, char _type)
        {
            this.id = _id;
            this.type = _type;
            this.months = new string[12] { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
            this.shownMonth = DateTime.Now.Month;
            this.shownYear = DateTime.Now.Year;

            InitializeComponent();
            SetTopPanel(shownMonth, shownYear);
            FillPanels();


        }
        /// <summary>
        /// Metoda ustawiająca nagłówek dla terminarza
        /// </summary>
        /// <param name="month">Wyświetlany miesiąc</param>
        /// <param name="year">Wyświetlany rok</param>
        private void SetTopPanel(int month, int year)
        {
            this.label8.Text = months[month-1];
            this.label9.Text = year.ToString();
        }
        /// <summary>
        /// Event Handler dla przycisku przełączającego miesiąc na kolejny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Event Handler dla przycisku przełączającego miesiąc na poprzedni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Aktualizacja terminarzu po zmianie miesiąca
        /// </summary>
        private void UpdateScheduleWindow()
        {

            SetTopPanel(shownMonth, shownYear);
            FillPanels();
        }
        /// <summary>
        /// Metoda wypełniająca terminarz. Na podstawie ID kierowcy bądź samochodu pobierane są informacje o przypisanych zleceniach i usługach serwisowych. Pobierane są ich okresy i na ich podstawie wypełniane są poszczególne pola terminarza.
        /// </summary>
        private void FillPanels()
        {

            var orderList = Order.GetOrderByCare(Care.GetCarebyCar(id));
            if (type == 'D')
                orderList = Order.GetOrderByDriver(id);
            var orderDays = new List<DateTime>();
            var ColorDays = new List<Color>();
            foreach(var order in orderList)
            {
                DateTime pom = order.plannedStartDate;
                while (pom <= order.plannedEndDate)
                {
                    orderDays.Add(pom);
                    pom = pom.AddDays(1);
                    if (Service.GetIdServiceByOrder(order.id) == 0)
                        ColorDays.Add(Color.Yellow);
                    else
                        ColorDays.Add(Color.Green);
                }
            }
            var data = new DateTime(shownYear, shownMonth, 1);
            int firstLabelPom = firstLabel;
            int firstDayOfMonth = GetDayOfWeek(data.DayOfWeek.ToString());
            int daysInMonth = DateTime.DaysInMonth(shownYear, shownMonth);
            int labelCounter = 1;
            int labelCounterHigher = 1;
            int labelCounterSmaler;
            int pomIndex = 1;
            bool pomBool = false;
            int pomColor2 = 0;
            if (shownMonth == 1)
                labelCounterSmaler = DateTime.DaysInMonth(shownYear-1, 12)-firstDayOfMonth+1;   
            else
                labelCounterSmaler = DateTime.DaysInMonth(shownYear, shownMonth - 1) - firstDayOfMonth + 1;

            for (int i = firstPanelIndex; i <= lastPanelIndex; i++)
            {
                if(i >= firstDayOfMonth && i < firstDayOfMonth + daysInMonth)
                {
                    var dateInMonth = new DateTime(shownYear, shownMonth, pomIndex);
                    int pomColor = 0;
                    foreach (var day in orderDays)
                    {
                        if(dateInMonth == day)
                        {
                            pomColor2 = pomColor;
                            pomBool = true;
                        }
                        pomColor++;
                    }
                    if(pomBool == true)
                    {
                        Color dayColor = ColorDays[pomColor2];
                        var panelColour = this.Controls.OfType<Control>()
                        .Where(panel => panel.TabIndex == i)
                        .Select(panel =>
                        {
                            panel.BackColor = dayColor;
                            return panel;
                        })
                        .First();
                        

                    }
                    else
                    {
                        var panelColour = this.Controls.OfType<Control>()
                        .Where(panel => panel.TabIndex == i)
                        .Select(panel =>
                        {
                            panel.BackColor = Color.Aquamarine;
                            return panel;
                        })
                        .First();
                    }
                    
                    Label test = this.Controls.Find("Label" + (firstLabelPom + labelCounter-1).ToString(), true).FirstOrDefault() as Label;
                    test.Text = labelCounter.ToString();
                    labelCounter++;
                    pomIndex++;
                    pomBool = false;
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
        /// <summary>
        /// Na podstawie podanego dnia tygodnia zwracany jest jego index
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
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

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tym oknie widzisz terminarz z wyszczególnionymi zdarzeniami w dniach za pomocą kolorów, wg legendy na dole okna", "Terminarz Pomoc");
        }
    }   
}
