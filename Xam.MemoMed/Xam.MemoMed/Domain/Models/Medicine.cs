using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.MemoMed.Domain.Models
{
    public class Medicine
    {
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
