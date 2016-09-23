using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class OrderDto
    {
        public int Id { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int CounterStatusBefore { get; set; }
        public int CounterStatusAfter { get; set; }
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
