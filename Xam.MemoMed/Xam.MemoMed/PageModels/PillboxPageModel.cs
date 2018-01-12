using FreshMvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;

namespace Xam.MemoMed.PageModels
{
    public class PillboxPageModel : FreshBasePageModel
    {
        CompartmentsInMemoryService compartmentsService;

        public PillboxPageModel()
        {
            this.compartmentsService = new CompartmentsInMemoryService();
            
            //get all medicines in the morning
            var compartmentMorning = compartmentsService.GetCompartment("Morning").Result;
            //bind IEnumerable<Bucket> to the ListView's ItemSource
            MedicinesInMorning = null;    //Important! ensure the list is empty first to force refresh!
            MedicinesInMorning = new ObservableCollection<CompartmentDetail>(compartmentMorning.Details);

            //get all medicines in the noon
            var compartmentNoon = compartmentsService.GetCompartment("Noon").Result;
            MedicinesInNoon = null;   
            MedicinesInNoon = new ObservableCollection<CompartmentDetail>(compartmentNoon.Details);

            //get all medicines in the evening
            var compartmentEvening = compartmentsService.GetCompartment("Evening").Result;
            MedicinesInEvening = null;   
            MedicinesInEvening = new ObservableCollection<CompartmentDetail>(compartmentEvening.Details);

            //get all medicines in the night
            var compartmentNight = compartmentsService.GetCompartment("Night").Result;
            MedicinesInNight = null;  
            MedicinesInNight = new ObservableCollection<CompartmentDetail>(compartmentNight.Details);
        }

        private ObservableCollection<CompartmentDetail> medicinesInMorning;
        public ObservableCollection<CompartmentDetail> MedicinesInMorning
        {
            get { return medicinesInMorning; }
            set
            {
                medicinesInMorning = value;
                RaisePropertyChanged(nameof(MedicinesInMorning));
            }
        }

        private ObservableCollection<CompartmentDetail> medicinesInNoon;
        public ObservableCollection<CompartmentDetail> MedicinesInNoon
        {
            get { return medicinesInNoon; }
            set
            {
                medicinesInNoon = value;
                RaisePropertyChanged(nameof(MedicinesInNoon));
            }
        }
        private ObservableCollection<CompartmentDetail> medicinesInEvening;
        public ObservableCollection<CompartmentDetail> MedicinesInEvening
        {
            get { return medicinesInEvening; }
            set
            {
                medicinesInEvening = value;
                RaisePropertyChanged(nameof(MedicinesInEvening));
            }
        }
        private ObservableCollection<CompartmentDetail> medicinesInNight;
        public ObservableCollection<CompartmentDetail> MedicinesInNight
        {
            get { return medicinesInNight; }
            set
            {
                medicinesInNight = value;
                RaisePropertyChanged(nameof(MedicinesInNight));
            }
        }


        //private async Task RefreshMedicines()
        //{
        //    //get all medicines
        //    var medicineList = medicineService.GetAll().Result;
        //    //bind IEnumerable<Bucket> to the ListView's ItemSource
        //    Medicines = null;    //Important! ensure the list is empty first to force refresh!
        //    Medicines = new ObservableCollection<Medicine>(medicineList);
        //}


    }
}
