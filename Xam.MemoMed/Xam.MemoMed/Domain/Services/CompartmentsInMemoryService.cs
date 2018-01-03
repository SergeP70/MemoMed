using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;

namespace Xam.MemoMed.Domain.Services
{
    TimeslotInMemoryService timeslotService;

    public class CompartmentsInMemoryService
    {
        //private static List<Timeslot> timeslots = new List<Timeslot>
        //{
        //    new Timeslot
        //    {
        //        Name="Ochtend",
        //        TimeslotStart=new TimeSpan(7,0,0),
        //        TimeslotEnd=new TimeSpan(9,0,0),
        //    },
        //    new Timeslot
        //    {
        //        Name="Middag",
        //        TimeslotStart=new TimeSpan(12,0,0),
        //        TimeslotEnd=new TimeSpan(14,0,0),
        //    },
        //    new Timeslot
        //    {
        //        Name="Avond",
        //        TimeslotStart=new TimeSpan(18,0,0),
        //        TimeslotEnd=new TimeSpan(20,0,0),
        //    },
        //    new Timeslot
        //    {
        //        Name="Nacht",
        //        TimeslotStart=new TimeSpan(22,0,0),
        //        TimeslotEnd=new TimeSpan(24,0,0),
        //    },
        //};


        private static List<Compartment> compartments = new List<Compartment>
        {
            new Compartment
            {
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Id == 1).FirstOrDefault(),
                Consumer = new User
                {
                    Name="Pille",
                    FirstName="Serge",
                    Age=47,
                    Email="serge@pille.be",
                    Phone="0471/276717"
                },
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = new Medicine
                        {
                            Name = "Dafalgan bruistabletten 40x 500mg",
                            MppCv = "3391505",
                            ContentQuantity = 40,
                            Ingredient="Paracetamol",
                            IngredientQuantity=500,
                            Price=7.57
                        },
                        Quantity = 2
                    }
                }
            }
        };
    }
}
