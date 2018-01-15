using FluentValidation;
using FreshMvvm;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services.Abstract;
using Xam.MemoMed.Domain.Validators;
using Xamarin.Forms;

namespace Xam.MemoMed.PageModels
{
    public class ContactsPageModel : FreshBasePageModel
    {
        IUsersService usersService;
        User contactPerson;
        private IValidator userValidator;


        public ContactsPageModel(IUsersService usersService)
        {
            this.usersService = usersService;
            userValidator = new UserValidator();
            //get user 2
            contactPerson = usersService.GetUserById(2).Result;
            //bind contact to the Page's ItemSource
            // MedName = 0;    //Important! ensure the list is empty first to force refresh!
            ContactName = contactPerson.Name;
            ContactEmail = contactPerson.Email;
            ContactPhone = contactPerson.Phone;
        }

        public Command SaveContactCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await CoreMethods.PushPageModel<TimeToTakePageModel>(null, true);
                });
            }
        }


        private string contactName;
        public string ContactName
        {
            get { return contactName; }
            set
            {
                contactName = value;
                RaisePropertyChanged(nameof(ContactName));
            }
        }

        private string contactEmail;
        public string ContactEmail
        {
            get { return contactEmail; }
            set
            {
                contactEmail = value;
                RaisePropertyChanged(nameof(ContactEmail));
            }
        }

        private string contactPhone;
        public string ContactPhone
        {
            get { return contactPhone; }
            set
            {
                contactPhone = value;
                RaisePropertyChanged(nameof(ContactPhone));
            }
        }
    }
}
