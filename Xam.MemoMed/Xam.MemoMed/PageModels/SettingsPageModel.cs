using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;

namespace Xam.MemoMed.PageModels
{
    public class SettingsPageModel : FreshBasePageModel
    {
        MedicinesInMemoryService medicineService;

        public SettingsPageModel()
        {
            this.medicineService = new MedicinesInMemoryService();
            //get all medicines
            var medicineList = medicineService.GetAll().Result;
            //bind IEnumerable<Bucket> to the ListView's ItemSource
            Medicines = null;    //Important! ensure the list is empty first to force refresh!
            Medicines = new ObservableCollection<Medicine>(medicineList);
        }

        private ObservableCollection<Medicine> medicines;
        public ObservableCollection<Medicine> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                RaisePropertyChanged(nameof(Medicines));
            }
        }

        private async Task RefreshMedicines()
        {
            //get all medicines
            var medicineList = medicineService.GetAll().Result;
            //bind IEnumerable<Bucket> to the ListView's ItemSource
            Medicines = null;    //Important! ensure the list is empty first to force refresh!
            Medicines = new ObservableCollection<Medicine>(medicineList);
        }


        public string HelloSettings
        {
            get { return "List of Medicines"; }
        }

    }
}
