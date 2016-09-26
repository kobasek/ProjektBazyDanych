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
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string CancellationReason { get; set; }
        public string State { get; set; }
        public int CareId { get; set; }
        public int UserId { get; set; }

        public OrderTableElement(int id, DateTime plannedStartDate, DateTime plannedEndDate, DateTime actualStartDate, DateTime actualEndDate, int counterStatusBefore, int counterStatusAfter, string commentsBefore, string commentsAfter, char type, decimal cost, string cancellationReason, char state, int careId, int userId)
        {
            Id = id;
            PlannedStartDate = plannedStartDate;
            PlannedEndDate = plannedEndDate;
            ActualStartDate = actualStartDate;
            ActualEndDate = actualEndDate;
            CounterStatusBefore = counterStatusBefore;
            CounterStatusAfter = counterStatusAfter;
            CommentsBefore = commentsBefore;
            CommentsAfter = commentsAfter;
            switch (type)
            {
                case '1':
                    Type = "1. Rodzaj";
                    break;
                case '2':
                    Type = "2. Rodzaj";
                    break;
                case '3':
                    Type = "3. Rodzaj";
                    break;
            }
            switch (state)
            {
                case 'a':
                    State = "Aktywny";
                    break;
                case 'z':
                    State = "Zakończony";
                    break;
                case 'o':
                    State = "Odwołany";
                    break;
            }
            Cost = cost;
            CancellationReason = cancellationReason;
            CareId = careId;
            UserId = userId;
        }
    }
}
