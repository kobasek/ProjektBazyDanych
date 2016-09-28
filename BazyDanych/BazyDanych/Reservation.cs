using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazyDanych
{
    class Reservation
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public string CommentsBefore { get; set; }
        public string CommentsAfter { get; set; }
        public char Type { get; set; }
        public decimal Cost { get; set; }
        public string CancellationReason { get; set; }
        public char State { get; set; }
        public int CareId { get; set; }
        public int UserId { get; set; }
    }
}
