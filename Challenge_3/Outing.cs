using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum OutingType { Golf, Bowling, Concert, Park}
    public class Outing
    {
        public OutingType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerPerson { get; set; }

        public Outing(OutingType eventType, int attendance, DateTime date, decimal totalCost, decimal costPerPerson)
        {
            EventType = eventType;
            Attendance = attendance;
            Date = date;
            TotalCost = totalCost;
            CostPerPerson = costPerPerson;
        }

        public Outing()
        {
            
        }
    }

}
