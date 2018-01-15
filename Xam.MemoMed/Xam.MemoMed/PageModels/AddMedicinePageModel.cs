using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services.Abstract;
using Xam.MemoMed.Domain.Services.Mock;
using Xamarin.Forms;
using ZXing.Mobile;

namespace Xam.MemoMed.PageModels
{
    public class AddMedicinePageModel : FreshBasePageModel
    {
        ICompartmentsService medicinesService;
        Medicine currentMedicine;
        Compartment currentCompartment;

        public AddMedicinePageModel(ICompartmentsService medicinesService)
        {
            this.medicinesService = medicinesService;

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



        public Command ShowBarcodePageCommand
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        string scannedBarcode = "135913";
                        //var scanner = new MobileBarcodeScanner();
                        //var msg = "Geen Barcode!";
                        //string scannedBarcode = "";
                        //scanner.TopText = "Scan uw medicijn";
                        //scanner.BottomText = "Wacht tot de barcode automatisch gescand wordt";

                        //var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                        //options.PossibleFormats = new List<ZXing.BarcodeFormat>()
                        //{
                        //    ZXing.BarcodeFormat.MSI,
                        //    ZXing.BarcodeFormat.EAN_8,
                        //    ZXing.BarcodeFormat.EAN_13,
                        //    ZXing.BarcodeFormat.CODE_39,
                        //    ZXing.BarcodeFormat.CODE_128,
                        //};

                        ////This will start scanning
                        //ZXing.Result result = await scanner.Scan(options);

                        ////Show the result returned.
                        //if (result != null)
                        //{
                        //    scannedBarcode = result.Text;
                        //    // verwijderen checksumdigit bij MSI
                        //    if (result.BarcodeFormat.ToString() == "MSI")
                        //        scannedBarcode = scannedBarcode.Remove(scannedBarcode.Length - 1);
                        //    msg = "Barcode: " + scannedBarcode + " (" + result.BarcodeFormat + ")";
                        //}

                        //await CoreMethods.DisplayAlert("Resultaat", msg, "Ok");

                        var scannedMedicine = medicinesService.GetMedicineByMppCv(scannedBarcode).Result;
                        currentMedicine = medicinesService.GetMedicineByMppCv(scannedBarcode).Result;
                        MedName = currentMedicine.Name;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw;
                    }
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

        public Command PutMedInCompartment
        {
            get
            {
                return new Command(async () =>
                {
                    await Task.Delay(0);
                    try
                    {
                        // Standaardgebruiker en Timeslot = noon
                        Timeslot ts = medicinesService.GetTimeslotById(2).Result;
                        User user = medicinesService.GetUserById(1).Result;

                        currentCompartment = medicinesService.GetCompartment("Noon").Result;
                        currentCompartment.Details.Add(new CompartmentDetail
                        {
                            Medication = currentMedicine,
                            Quantity = 2
                        });

                        var test = currentCompartment.DayOfTheWeek;
                        var test2 = currentCompartment.Consumer;

                        //CoreMethods.PushPageModel<PillboxPageModel>(null, true);

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw;
                    }

                });
            }
        }



    }
}
