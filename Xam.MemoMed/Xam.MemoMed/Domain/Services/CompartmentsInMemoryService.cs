using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;

namespace Xam.MemoMed.Domain.Services
{
    public class CompartmentsInMemoryService
    {
        // Seeding the Timeslots
        private static List<Timeslot> timeslots = new List<Timeslot>
        {
            new Timeslot
            {
                Name="Ochtend",
                TimeslotStart=new TimeSpan(7,0,0),
                TimeslotEnd=new TimeSpan(9,0,0),
            },
            new Timeslot
            {
                Name="Middag",
                TimeslotStart=new TimeSpan(12,0,0),
                TimeslotEnd=new TimeSpan(14,0,0),
            },
            new Timeslot
            {
                Name="Avond",
                TimeslotStart=new TimeSpan(18,0,0),
                TimeslotEnd=new TimeSpan(20,0,0),
            },
            new Timeslot
            {
                Name="Nacht",
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

        // Seeding the Users, For starters we only use one User
        private static List<User> users = new List<User>
        {
            new User
            {
                Name="Pille",
                FirstName="Serge",
                Age=47,
                Email="serge@pille.be",
                Phone="0471/276717"
            }
        };

        public async Task<User> GetUserById(Guid id)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task SaveUser(User user)
        {
            var oldUser = await GetUserById(user.Id);
            oldUser = user;
        }


        // Seeding the Medicines
        private static List<Medicine> medicines = new List<Medicine>
        {
            new Medicine
            {
                Name = "Dafalgan bruistabletten 40x 500mg",
                MppCv = "3391505",
                ContentQuantity = 40,
                Ingredient="Paracetamol",
                IngredientQuantity=500,
                Price=7.57
            },
            new Medicine
            {
                Name = "Seretide 25/50 dosisaerosol susp. 120dos.",
                MppCv = "1593094",
                ContentQuantity = 1,
                Ingredient="Salmeterol fluticason",
                IngredientQuantity=120,
                Price=25.48
            },
            new Medicine
            {
                Name = "Xyzall siroop oploss. 200ml 2,5mg/5ml",
                MppCv = "2402915",
                ContentQuantity = 1,
                Ingredient="Levocetirizine",
                IngredientQuantity=200,
                Price=11.90
            },
            new Medicine
            {
                Name = "Ferricure 100mg/5ml oploss. 60ml 225mg/5ml",
                MppCv = "1000280",
                ContentQuantity = 1,
                Ingredient="Ijzer",
                IngredientQuantity=60,
                Price=9.11
            },
            new Medicine
            {
                Name = "Ventolin dosisaerosol susp. 200dos. 100Âµg/1dos.",
                MppCv = "135913",
                ContentQuantity = 1,
                Ingredient="Salbutamol",
                IngredientQuantity=200,
                Price=6.54
            },
        };

        public async Task<Medicine> GetMedicinById(int id)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return medicines.FirstOrDefault(m => m.Id == id);
        }

        public async Task SaveMedicin(Medicine medicine)
        {
            var oldMedicine = await GetMedicinById(medicine.Id);
            oldMedicine = medicine;
        }


        private static List<Compartment> compartments = new List<Compartment>
        {
            new Compartment
            {
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Ochtend").FirstOrDefault(),
                Consumer = users.Where(u => u.Name=="Pille").FirstOrDefault(),
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "2402915").FirstOrDefault(),
                        Quantity = 2
                    },
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "1593094").FirstOrDefault(),
                        Quantity = 2
                    }
                }
            },
            new Compartment
            {
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Middag").FirstOrDefault(),
                Consumer = users.Where(u => u.Name=="Pille").FirstOrDefault(),
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "1000280").FirstOrDefault(),
                        Quantity = 15
                    }
                }
            },
            new Compartment
            {
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Avond").FirstOrDefault(),
                Consumer = users.Where(u => u.Name=="Pille").FirstOrDefault(),
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "1593094").FirstOrDefault(),
                        Quantity = 15
                    },
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "2402915").FirstOrDefault(),
                        Quantity = 15
                    }

                }
            },
            new Compartment
            {
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Nacht").FirstOrDefault(),
                Consumer = users.Where(u => u.Name=="Pille").FirstOrDefault(),
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "3391505").FirstOrDefault(),
                        Quantity = 1
                    }
                }
            }
        };

        public async Task<IEnumerable<Compartment>> GetCompartmentsForUser(Guid userid)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return compartments.Where(c => c.Consumer.Id == userid);
        }

        public async Task<Compartment> GetCompartment(int compartmentId)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return compartments.FirstOrDefault(c => c.Id == compartmentId);
        }

        public async Task SaveCompartment(Compartment pillbox)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            var savedCompartment = compartments.FirstOrDefault(c => c.Id == pillbox.Id);
            if (savedCompartment == null) // this is a new compartment
            {
                savedCompartment = pillbox;
                savedCompartment.Id = 1;
                compartments.Add(savedCompartment);
            }
            savedCompartment.Date = pillbox.Date;
            savedCompartment.Timeslot = pillbox.Timeslot;
            savedCompartment.Consumer = pillbox.Consumer;
            savedCompartment.Status = pillbox.Status;
            savedCompartment.Details = pillbox.Details;
        }

        public async Task DeleteCompartment(int compartmentId)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            Compartment pillbox = compartments.FirstOrDefault(c => c.Id == compartmentId);
            compartments.Remove(pillbox);
        }
    }
}
