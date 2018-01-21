using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services.Abstract;
using Xamarin.Forms;

namespace Xam.MemoMed.Domain.Services.Mock
{
    public class TimeslotInMemoryService : ITimeslotsService
    {
        public static List<Timeslot> timeslots = new List<Timeslot>
        {
            new Timeslot
            {
                Name="Morning",
                TimeslotStart=new TimeSpan(7,0,0),
                TimeslotEnd=new TimeSpan(9,0,0),
            },
            new Timeslot
            {
                Name="Noon",
                TimeslotStart=new TimeSpan(12,0,0),
                TimeslotEnd=new TimeSpan(14,0,0),
            },
            new Timeslot
            {
                Name="Evening",
                TimeslotStart=new TimeSpan(18,0,0),
                TimeslotEnd=new TimeSpan(20,0,0),
            },
            new Timeslot
            {
                Name="Night",
                TimeslotStart=new TimeSpan(22,0,0),
                TimeslotEnd=new TimeSpan(24,0,0),
            },
        };

        public async Task<Timeslot> GetTimeslotById(int id)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return timeslots.FirstOrDefault(t => t.Id == id);
        }

        public async Task SaveTimeslot(Timeslot timeslot)
        {
            var oldTimeslot = await GetTimeslotById(timeslot.Id);
            oldTimeslot = timeslot;
        }


    }
}
