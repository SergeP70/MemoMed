using FreshMvvm;
using Xamarin.Forms;

namespace Xam.MemoMed.PageModels
{
    public class AddMedicinePageModel : FreshBasePageModel
    {
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


    }
}
