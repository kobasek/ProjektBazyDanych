using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do przechowywania danych o zleceniu
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Id zlecenia
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Planowana data rozpoczęcia zlecenia
        /// </summary>
        public DateTime PlannedStartDate { get; set; }
        /// <summary>
        /// Planowana data zakończenia zlecenia
        /// </summary>
        public DateTime PlannedEndDate { get; set; }
        /// <summary>
        /// Rzeczywista data rozpoczęcia zlecenia
        /// </summary>
        public DateTime ActualStartDate { get; set; }
        /// <summary>
        /// Rzeczywista data zakończenia zlecenia
        /// </summary>
        public DateTime ActualEndDate { get; set; }
        /// <summary>
        /// Stan licznika przed zleceniem
        /// </summary>
        public int CounterStatusBefore { get; set; }
        /// <summary>
        /// Stan licznika po zleceniu
        /// </summary>
        public int CounterStatusAfter { get; set; }
        /// <summary>
        /// Komentarz przed zleceniem
        /// </summary>
        public string CommentsBefore { get; set; }
        /// <summary>
        /// Komentarz po zleceniu
        /// </summary>
        public string CommentsAfter { get; set; }
        /// <summary>
        /// Typ zlecenia
        /// </summary>
        public char Type { get; set; }
        /// <summary>
        /// Koszt zlecenia
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Powód anulowania zlecenia
        /// </summary>
        public string CancellationReason { get; set; }
        /// <summary>
        /// Stan zlecenia
        /// </summary>
        public char State { get; set; }
        /// <summary>
        /// Id opieki zlecenia
        /// </summary>
        public int CareId { get; set; }
        /// <summary>
        /// Id kierowcy wykonywującego zlecenie
        /// </summary>
        public int UserId { get; set; }
    }
}
