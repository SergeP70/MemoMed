using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;
using Xam.MemoMed.Domain.Services.Abstract;

namespace Xam.MemoMed.Domain.Services.Mock
{
    public class CompartmentsInMemoryService : ICompartmentsService
    {
        // Seeding the Timeslots
        private static List<Timeslot> timeslots = new List<Timeslot>
        {
            new Timeslot
            {
                Id=1,
                Name="Morning",
                TimeslotStart=new TimeSpan(7,0,0),
                TimeslotEnd=new TimeSpan(9,0,0),
            },
            new Timeslot
            {
                Id=2,
                Name="Noon",
                TimeslotStart=new TimeSpan(12,0,0),
                TimeslotEnd=new TimeSpan(14,0,0),
            },
            new Timeslot
            {
                Id=3,
                Name="Evening",
                TimeslotStart=new TimeSpan(18,0,0),
                TimeslotEnd=new TimeSpan(20,0,0),
            },
            new Timeslot
            {
                Id=4,
                Name="Night",
                TimeslotStart=new TimeSpan(22,0,0),
                TimeslotEnd=new TimeSpan(24,0,0),
            },
        };

        public async Task<Timeslot> GetTimeslotById(int id)
        {
            await Task.Delay(0);
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
                Id=1,
                Name="Pille",
                FirstName="Serge",
                Age=47,
                Email="serge@pille.be",
                Phone="0471/276717"
            }
        };

        public async Task<User> GetUserById(int id)
        {
            await Task.Delay(0);
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            await Task.Delay(0);
            return users;
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
                Id=1,
                Name = "Dafalgan bruistabletten 40x 500mg",
                NickName="Dafalgan",
                MppCv = "3391505",
                ContentQuantity = 40,
                Unit="tablet(s)",
                Ingredient="Paracetamol",
                IngredientQuantity=500,
                Price=7.57
            },
            new Medicine
            {
                Id=2,
                Name = "Seretide 25/50 dosisaerosol susp. 120dos.",
                NickName="Seretide",
                MppCv = "1593094",
                ContentQuantity = 1,
                Unit="puff(s)",
                Ingredient="Salmeterol fluticason",
                IngredientQuantity=120,
                Price=25.48
            },
            new Medicine
            {
                Id=3,
                Name = "Xyzall siroop oploss. 200ml 2,5mg/5ml",
                NickName="Xyzall",
                MppCv = "2402915",
                ContentQuantity = 1,
                Unit="ml.",
                Ingredient="Levocetirizine",
                IngredientQuantity=200,
                Price=11.90
            },
            new Medicine
            {
                Id=4,
                Name = "Ferricure 100mg/5ml oploss. 60ml 225mg/5ml",
                NickName="Ferricure",
                MppCv = "1000280",
                ContentQuantity = 1,
                Unit="drups",
                Ingredient="Ijzer",
                IngredientQuantity=60,
                Price=9.11
            },
            new Medicine
            {
                Id=5,
                Name = "Ventolin dosisaerosol susp. 200dos. 100Âµg/1dos.",
                NickName="Ventolin",
                MppCv = "135913",
                ContentQuantity = 1,
                Unit="puff(s)",
                Ingredient="Salbutamol",
                IngredientQuantity=200,
                Price=6.54
            },
        };

        public async Task<Medicine> GetMedicineById(int id)
        {
            await Task.Delay(0);
            return medicines.FirstOrDefault(m => m.Id == id);
        }

        public async Task<Medicine> GetMedicineByMppCv(string mppCv)
        {
            await Task.Delay(0);
            return medicines.Where(m => m.MppCv == mppCv).FirstOrDefault();
        }


        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            await Task.Delay(0);
            return medicines;
        }


        public async Task SaveMedicin(Medicine medicine)
        {
            var oldMedicine = await GetMedicineById(medicine.Id);
            oldMedicine = medicine;
        }


        private static List<Compartment> compartments = new List<Compartment>
        {
            new Compartment
            {
                Id=1,
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Morning").FirstOrDefault(),
                Consumer = users.Where(u => u.Name=="Pille").FirstOrDefault(),
                Status = false,
                Details = new List<CompartmentDetail>
                {
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "135913").FirstOrDefault(),
                        Quantity = 2
                    },
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "1593094").FirstOrDefault(),
                        Quantity = 2
                    },
                    new CompartmentDetail
                    {
                        Medication = medicines.Where(m => m.MppCv == "2402915").FirstOrDefault(),
                        Quantity = 2
                    },
                }
            },
            new Compartment
            {
                Id=2,
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Noon").FirstOrDefault(),
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
                Id=3,
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Evening").FirstOrDefault(),
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
                Id=4,
                Date= new DateTime(2018,01,01),
                Timeslot= timeslots.Where(t => t.Name == "Night").FirstOrDefault(),
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

        public async Task<IEnumerable<Compartment>> GetCompartmentsForUser(int userid)
        {
            await Task.Delay(0);
            return compartments.Where(c => c.Consumer.Id == userid);
        }

        public async Task<Compartment> GetCompartment(string timeSlot)
        {
            await Task.Delay(0);
            var ts = timeslots.FirstOrDefault(t => t.Name == timeSlot);
            return compartments.FirstOrDefault(c => c.Timeslot == ts);
        }

        public async Task SaveCompartment(Compartment pillbox)
        {
            await Task.Delay(0);
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
            await Task.Delay(0);
            Compartment pillbox = compartments.FirstOrDefault(c => c.Id == compartmentId);
            compartments.Remove(pillbox);
        }
    }
}
