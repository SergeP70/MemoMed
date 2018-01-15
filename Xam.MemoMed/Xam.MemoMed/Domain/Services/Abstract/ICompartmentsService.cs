using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services.Abstract
{
    public interface ICompartmentsService
    {
        Task<Timeslot> GetTimeslotById(int id);
        Task SaveTimeslot(Timeslot timeslot);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task SaveUser(User user);
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> GetMedicineByMppCv(string mppCv);
        Task<IEnumerable<Medicine>> GetAllMedicines();
        Task SaveMedicin(Medicine medicine);
        Task<IEnumerable<Compartment>> GetCompartmentsForUser(int userid);
        Task<Compartment> GetCompartment(string timeSlot);
        Task SaveCompartment(Compartment pillbox);
        Task DeleteCompartment(int compartmentId);
        
    }
}
