using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.MemoMed.Domain.Models
{
    public class Timeslot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeslotStart { get; set; }
        public TimeSpan TimeslotEnd { get; set; }
    }
}
