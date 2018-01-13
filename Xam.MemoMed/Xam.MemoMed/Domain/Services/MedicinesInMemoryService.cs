using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services
{
    public class MedicinesInMemoryService
    {
        private static List<Medicine> medicines = new List<Medicine>
        {
            new Medicine
            {
                Id=1,
                Name = "Dafalgan bruistabletten 40x 500mg",
                NickName="Dafalgan",
                MppCv = "3391505",
                ContentQuantity = 40,
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
                Ingredient="Salbutamol",
                IngredientQuantity=200,
                Price=6.54
            },
        };

        public async Task<Medicine> GetMedicinById(int id)
        {
            await Task.Delay(0);
            return medicines.FirstOrDefault(m => m.Id == id);
        }

        public async Task<IEnumerable<Medicine>> GetAll()
        {
            await Task.Delay(0);
            return medicines;
        }

        public async Task SaveMedicin(Medicine medicine)
        {
            var oldMedicine = await GetMedicinById(medicine.Id);
            oldMedicine = medicine;
        }

    }
}
