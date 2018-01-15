using FreshMvvm;
using Xam.MemoMed.Domain.Services.Abstract;

namespace Xam.MemoMed.PageModels
{
    public class ContactsPageModel : FreshBasePageModel
    {
        IUsersService usersService;

        public ContactsPageModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public string HelloSettings
        {
            get { return "Hello by FreshMvvm"; }
        }

    }
}
