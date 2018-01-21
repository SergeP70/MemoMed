using FreshMvvm;
using Xam.MemoMed.Domain.Services.Abstract;
using Xam.MemoMed.Domain.Services.Mock;
using Xam.MemoMed.PageModels;
using Xamarin.Forms;
using ZXing.Mobile;

namespace Xam.MemoMed
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Registatie van de abstradte interfaces met een IoC Container
            FreshIOC.Container.Register<IMedicinesService>(new MedicinesInMemoryService());
            FreshIOC.Container.Register<ICompartmentsService>(new CompartmentsInMemoryService());
            FreshIOC.Container.Register<IUsersService>(new UsersInMemoryService());
            FreshIOC.Container.Register<ITimeslotsService>(new TimeslotInMemoryService());

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
