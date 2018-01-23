using FreshMvvm;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services.Abstract;
using Xamarin.Forms;

namespace Xam.MemoMed.PageModels
{
    public class SearchContactPageModel : FreshBasePageModel
    {
        public string SearchYourContact
        {
            get { return "Search your contact"; }
        }

        public IEnumerable<User> PhoneContacts { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            IUserInfoService service = DependencyService.Get<IUserInfoService>();
            PhoneContacts = service.GetDeviceContacts();
        }

        public ICommand SelectContactCommand => new Command<User>(
            async (User selectedContact) => 
            {
                //Debug.WriteLine(selectedContact.Name);
                await CoreMethods.PopPageModel(selectedContact, true, true);
            }
        );


    }
}
