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
        List<Medicine> Medicines { get; set; }


        private MedicinesInMemoryService medicineService;

        public SettingsPageModel()
        {
            //medicineService = new MedicinesInMemoryService();
            //var MedicineList = new ObservableCollection<Medicine>(medicineService.GetAll().Result);
            //Task.Delay(1000);
        }

        public string HelloSettings
        {
            get { return "Hello by FreshMvvm"; }
        }

    }
}
