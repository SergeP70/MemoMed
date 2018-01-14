using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Abstract
{
    public interface IMedicinesService
    {
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> GetMedicineByMppCv(string mppCv);
        Task<IEnumerable<Medicine>> GetAll();
        Task SaveMedicin(Medicine medicine);
    }
}
