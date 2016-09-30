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
    /// Klasa formularza wyświatlającego wybór daty rezerwecja pojazu
    /// </summary>
    public partial class ReservationWindow : Form
    {
        /// <summary>
        /// Bezparametrowy konstruktor klasy formularza wyświatlającego wybór daty rezerwecja pojazu
        /// </summary>
        public ReservationWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event Handler dla przycisku akceptacji wyboru daty rezerwacji pojazdu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W tym oknie możesz dokonać rezerwacji samochodu w dniach od wybranej początkowej daty do końcowej daty. Do końcowej reserwacji dojdzie jeśli zgodzi się na to administrator", "Rezerwacja Pomoc");
        }
    }
}
