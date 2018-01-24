using FluentValidation;
using FreshMvvm;
using PCLStorage;
using Plugin.Messaging;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
            // for now: just get user 1
            if (contactPerson == null)
                contactPerson = usersService.GetUserById(1).Result;
            //LoadContactXML();
        }


        /// <summary>
        /// This methods is called when the View is appearing
        /// </summary>
        protected async override void ViewIsAppearing(object sender, System.EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            // (enkel) bij opstart wordt deze methode 2x uitgevoerd
            await CoreMethods.DisplayAlert("Page is appearing", "", "Ok");

            //bind contact to the Page's ItemSource
            LoadContactsState();
        }

        private async void LoadContactXML()
        {
            // load contact from XML
            string fileName = "contactPerson.xml";
            IFolder folder = FileSystem.Current.LocalStorage;
            ExistenceCheckResult result = await folder.CheckExistsAsync(fileName);
            if (result == ExistenceCheckResult.FileExists)
            {
                try
                {
                    IFile file = await folder.GetFileAsync(fileName);
                    string text = await file.ReadAllTextAsync();
                    using (var reader = new StringReader(text))
                    {
                        var serializer = new XmlSerializer(typeof(User));
                        contactPerson = (User)serializer.Deserialize(reader);
                        await Task.Delay(0);
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine($"Error reading settings: {ex.Message}");
                }
            }
        }

        public async override void Init(object initData)
        {
            base.Init(initData);
            // load contact from XML
            string fileName = "contactPerson.xml";
            IFolder folder = FileSystem.Current.LocalStorage;
            ExistenceCheckResult result = await folder.CheckExistsAsync(fileName);
            if (result == ExistenceCheckResult.FileExists)
            {
                try
                {
                    IFile file = await folder.GetFileAsync(fileName);
                    string text = await file.ReadAllTextAsync();
                    using (var reader = new StringReader(text))
                    {
                        var serializer = new XmlSerializer(typeof(User));
                        contactPerson = (User)serializer.Deserialize(reader);
                        await Task.Delay(0);
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine($"Error reading settings: {ex.Message}");
                }
            }

        }


        /// <summary>
        /// Executed when returning to this Model from a previous model
        /// </summary>
        /// <param name="returnedData"></param>
        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
            if (returnedData is User)
            {
                //refresh list, to update this item visually
                Debug.WriteLine(returnedData.ToString());
                contactPerson = (User)returnedData;
                LoadContactsState();
            }
        }


        /// <summary>
        /// Loads the contacts properties into the VM properties for display in UI
        /// </summary>
        private void LoadContactsState()
        {
            ContactFirstName = contactPerson.FirstName;
            ContactLastName = contactPerson.LastName;
            ContactEmail = contactPerson.Email;
            ContactPhone = contactPerson.Phone;
        }


        /// <summary>
        /// Saves the VM properties back to the current contacts
        /// </summary>
        private void SaveContactsState()
        {
            contactPerson.FirstName = ContactFirstName;
            contactPerson.LastName = ContactLastName;
            contactPerson.Email = ContactEmail;
            contactPerson.Phone = ContactPhone;
            // To remove the validation errors when corrected:
            ContactFirstNameError = "";
            ContactLastNameError = "";
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
                        var smsMessenger = CrossMessaging.Current.SmsMessenger;
                        var emailMessenger = CrossMessaging.Current.EmailMessenger;
                        if (smsMessenger.CanSendSmsInBackground)
                        {
                            smsMessenger.SendSmsInBackground("0471501136",
                                "Bericht van MemoMed: U krijgt deze automatische SMS omdat u aangeduid bent als contactpersoon van Serge Pille");
                        }
                        await CoreMethods.DisplayAlert("Contactpersoon is opgeslagen ontvangt een SMS ter bevestiging", "", "Ok");
                        if (emailMessenger.CanSendEmail)
                        {
                            emailMessenger.SendEmail("serge.pille@telenet.be", "Nieuwe contactpersoon van MemoMed", "Beste contact, u bent gekozen als contactpersoon van MemoMed.");
                        }
                        // saving settings tot XML file
                        var serializer = new XmlSerializer(typeof(User));
                        string userAsXml = "";
                        using (var stringWriter = new StringWriter())
                        using (var writer = XmlWriter.Create(stringWriter))
                        {
                            serializer.Serialize(writer, contactPerson);
                            userAsXml = stringWriter.ToString();
                        }
                        IFolder folder = FileSystem.Current.LocalStorage;
                        IFile file = await folder.CreateFileAsync("contactPerson.xml",
                            CreationCollisionOption.ReplaceExisting);
                        await file.WriteAllTextAsync(userAsXml);
                    }

                });
            }
        }

        public Command SearchContactCommand
        {
            get
            {
                return new Command(() =>
                {
                    CoreMethods.PushPageModel<SearchContactPageModel>(null, true);
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
                if (error.PropertyName == nameof(user.FirstName))
                {
                    ContactFirstNameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.LastName))
                {
                    ContactLastNameError = error.ErrorMessage;
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


        private string contactFirstName;
        public string ContactFirstName
        {
            get { return contactFirstName; }
            set
            {
                contactFirstName = value;
                RaisePropertyChanged(nameof(ContactFirstName));
            }
        }

        private string contactLastName;
        public string ContactLastName
        {
            get { return contactLastName; }
            set
            {
                contactLastName = value;
                RaisePropertyChanged(nameof(ContactLastName));
            }
        }

        private string contactFirstNameError;
        public string ContactFirstNameError
        {
            get { return contactFirstNameError; }
            set
            {
                contactFirstNameError = value;
                RaisePropertyChanged(nameof(ContactFirstNameError));
                RaisePropertyChanged(nameof(ContactFirstNameErrorVisible));
            }
        }

        public bool ContactFirstNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ContactFirstNameError); }
        }


        private string contactLastNameError;
        public string ContactLastNameError
        {
            get { return contactLastNameError; }
            set
            {
                contactLastNameError = value;
                RaisePropertyChanged(nameof(ContactLastNameError));
                RaisePropertyChanged(nameof(ContactLastNameErrorVisible));
            }
        }

        public bool ContactLastNameErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ContactLastNameError); }
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
