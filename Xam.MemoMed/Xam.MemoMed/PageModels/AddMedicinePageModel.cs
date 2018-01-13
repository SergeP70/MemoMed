using FreshMvvm;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;
using Xamarin.Forms;

namespace Xam.MemoMed.PageModels
{
    public class AddMedicinePageModel : FreshBasePageModel
    {
        CompartmentsInMemoryService medicinesService;
        Medicine currentMedicine;

        public AddMedicinePageModel()
        {
            this.medicinesService = new CompartmentsInMemoryService();

            //get first medicine
            currentMedicine = medicinesService.GetMedicineById(2).Result;
            //bind medicine to the Page's ItemSource
            // MedName = 0;    //Important! ensure the list is empty first to force refresh!
            MedName = currentMedicine.Name;

        }

        private int medId;
        public int MedId
        {
            get { return medId; }
            set
            {
                medId = value;
                RaisePropertyChanged(nameof(MedId));
            }
        }

        private string medName;
        public string MedName
        {
            get { return medName; }
            set
            {
                medName = value;
                RaisePropertyChanged(nameof(MedName));
            }
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



        public string HelloSettings
        {
            get { return "Hello by FreshMvvm"; }
        }

        public Command ShowBarcodePageCommand
        {
            get
            {
                return new Command(() =>
                {
                    CoreMethods.PushPageModel<BarcodePageModel>(null,true);
                });
            }
        }

        public Command ShowInfoMedicinePageCommand
        {
            get
            {
                return new Command(() =>
                {
                    CoreMethods.PushPageModel<InfoMedicinePageModel>(currentMedicine, true);
                });
            }
        }

        public Command ShowTimeToTakePageCommand
        {
            get
            {
                return new Command(() =>
                {
                    CoreMethods.PushPageModel<TimeToTakePageModel>(null, true);
                });
            }
        }



    }
}
