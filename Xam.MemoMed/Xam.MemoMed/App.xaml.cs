using FreshMvvm;
using Xam.MemoMed.PageModels;
using Xamarin.Forms;

namespace Xam.MemoMed
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var mainPage = new FreshTabbedNavigationContainer();
            mainPage.AddTab<PillboxPageModel>("BOX", null);
            mainPage.AddTab<AddMedicinePageModel>("+MED", null);
            mainPage.AddTab<ContactsPageModel>("Contacts", null);
            mainPage.AddTab<SettingsPageModel>("Settings", null);
            MainPage = mainPage;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
