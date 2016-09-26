using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    class OrderTableElement
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

        public OrderTableElement(int id, DateTime plannedStartDate, DateTime plannedEndDate, DateTime actualStartDate, DateTime actualEndDate, int counterStatusBefore, int counterStatusAfter, string commentsBefore, char type, decimal cost, string cancellationReason, char state, int careId, int userId)
        {
            Id = id;
            PlannedStartDate = plannedStartDate;
            PlannedEndDate = plannedEndDate;
            ActualStartDate = actualStartDate;
            ActualEndDate = actualEndDate;
            CounterStatusBefore = counterStatusBefore;
            CounterStatusAfter = counterStatusAfter;
            CommentsBefore = commentsBefore;
            CommentsAfter = CommentsAfter;
            Type = type;
            Cost = cost;
            CancellationReason = cancellationReason;
            State = state;
            CareId = careId;
            UserId = userId;
        }
    }
}
