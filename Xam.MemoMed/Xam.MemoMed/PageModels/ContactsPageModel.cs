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
            // for now: just get user 2
            contactPerson = usersService.GetUserById(2).Result;
        }


        /// <summary>
        /// This methods is called when the View is appearing
        /// </summary>
        protected override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            // (enkel) bij opstart wordt deze methode 2x uitgevoerd
            //CoreMethods.DisplayAlert("Page is appearing", "", "Ok");
            //bind contact to the Page's ItemSource
            LoadContactsState();
        }

        /// <summary>
        /// Loads the contacts properties into the VM properties for display in UI
        /// </summary>
        private void LoadContactsState()
        {
            ContactName = contactPerson.Name;
            ContactEmail = contactPerson.Email;
            ContactPhone = contactPerson.Phone;
        }


        /// <summary>
        /// Saves the VM properties back to the current contacts
        /// </summary>
        private void SaveContactsState()
        {
            contactPerson.Name = ContactName;
            contactPerson.Email = ContactEmail;
            contactPerson.Phone = ContactPhone;
            // To remove the validation errors when corrected:
            ContactNameError = "";
            ContactPhoneError = "";
            ContactEmailError = "";
        }

        public Command SaveContactCommand
        {
            get
            {
                return new Command(async () =>
                {
                    SaveContactsState();
                    if (Validate(contactPerson))
                    {
                        await CoreMethods.DisplayAlert("Contactpersoon is bewaard", "", "Ok");
                    }
                });
            }
        }

        /// <summary>
        /// Validates the user using the validator
        /// </summary>
        /// <param name="user">The user to validate</param>
        /// <returns></returns>
        private bool Validate(User user)
        {
            var validationResult = userValidator.Validate(user);
            //loop through error to identify properties
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(user.Name))
                {
                    ContactNameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.Email))
                {
                    ContactEmailError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.Phone))
                {
                    ContactPhoneError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
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

        private string contactNameError;
        public string ContactNameError
        {
            get { return contactNameError; }
            set
            {
                contactNameError = value;
                RaisePropertyChanged(nameof(ContactNameError));
                RaisePropertyChanged(nameof(ContactNameErrorVisible));
            }
        }

        public bool ContactNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ContactNameError); }
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
        private string contactEmailError;
        public string ContactEmailError
        {
            get { return contactEmailError; }
            set
            {
                contactEmailError = value;
                RaisePropertyChanged(nameof(ContactEmailError));
                RaisePropertyChanged(nameof(ContactEmailErrorVisible));
            }
        }

        public bool ContactEmailErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ContactEmailError); }
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

        private string contactPhoneError;
        public string ContactPhoneError
        {
            get { return contactPhoneError; }
            set
            {
                contactPhoneError = value;
                RaisePropertyChanged(nameof(ContactPhoneError));
                RaisePropertyChanged(nameof(ContactPhoneErrorVisible));
            }
        }

        public bool ContactPhoneErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ContactPhoneError); }
        }

    }
}
