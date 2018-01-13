using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.PageModels
{
    public class InfoMedicinePageModel : FreshBasePageModel
    {

        public override void Init(object initData)
        {
            base.Init(initData);

            var currentMedicine = initData as Medicine;
            Name = currentMedicine.Name;
            NickName = currentMedicine.NickName;
            MppCv = currentMedicine.MppCv;
            ContentQuantity = currentMedicine.ContentQuantity;
            Unit = currentMedicine.Unit;
            Ingredient = currentMedicine.Ingredient;
            IngredientQuantity = currentMedicine.IngredientQuantity;
            Price = currentMedicine.Price;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string MppCv { get; set; }
        public int ContentQuantity { get; set; }
        public string Unit { get; set; }
        public string Ingredient { get; set; }
        public double IngredientQuantity { get; set; }
        public double Price { get; set; }


    }
}
