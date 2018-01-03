using System;
using System.Collections.Generic;

namespace Xam.MemoMed.Domain.Models
{
    public class Compartment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Timeslot Timeslot { get; set; }
        public User Consumer { get; set; }
        public bool Status { get; set; }
        public string DayOfTheWeek
        {
            get
            {
                return Date.DayOfWeek.ToString();
            }
        }
        public virtual ICollection<CompartmentDetail> Details { get; set; }
        
    }
}
