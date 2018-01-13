using FreshMvvm;
using System.Collections.Generic;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services;
using Xamarin.Forms;
using ZXing.Mobile;

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

        //public ICommand SaveBucketItemCommand => new Command(
        //    async () => {
        //        try
        //        {
        //            SaveItemState();

        //            if (Validate(currentItem))
        //            {
        //                if (currentItem.Id == Guid.Empty)
        //                {
        //                    currentItem.Bucket.Items.Add(currentItem);
        //                    currentItem.Id = Guid.NewGuid();
        //                }
        //                //use coremethodes to Pop pages in FreshMvvm!
        //                await CoreMethods.PopPageModel(currentItem, false, true);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.Message);
        //            throw;
        //        }
        //    }
        //);



        public Command ShowBarcodePageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //CoreMethods.PushPageModel<BarcodePageModel>(null,true);

                    var scanner = new MobileBarcodeScanner();
                    var msg = "Geen Barcode!";
                    scanner.TopText = "Scan uw medicijn";
                    scanner.BottomText = "Wacht tot de barcode automatisch gescand wordt";

                    var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                    options.PossibleFormats = new List<ZXing.BarcodeFormat>()
                    {
                        ZXing.BarcodeFormat.MSI,
                        ZXing.BarcodeFormat.EAN_8,
                        ZXing.BarcodeFormat.EAN_13,
                        ZXing.BarcodeFormat.CODE_39,
                        ZXing.BarcodeFormat.CODE_128,
                    };

                    //This will start scanning
                    ZXing.Result result = await scanner.Scan(options);

                    //Show the result returned.
                    if (result != null)
                    {
                        msg = "Barcode: " + result.Text + " (" + result.BarcodeFormat + ")";
                    }

                    await CoreMethods.DisplayAlert("Resultaat", msg, "Ok");
                    
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
