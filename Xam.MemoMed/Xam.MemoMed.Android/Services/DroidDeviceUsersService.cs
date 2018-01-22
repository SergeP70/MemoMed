using Android.Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Contacts;
using System.Threading.Tasks;
using System.Linq;
using Xam.MemoMed.Domain.Services.Abstract;
using Xam.MemoMed.Domain.Models;

[assembly: Dependency(typeof(Xam.MemoMed.Droid.Services.DroidDeviceUsersService))]

namespace Xam.MemoMed.Droid.Services
{
    public class DroidDeviceUsersService : IUserInfoService
    {
        private readonly Xamarin.Contacts.AddressBook _book;
        private static IEnumerable<User> _contacts;

        public DroidDeviceUsersService()
        {
            _book = new Xamarin.Contacts.AddressBook(Forms.Context.ApplicationContext);
        }

        public IEnumerable<User> GetDeviceContacts()
        {

            var contacts = new List<User>();

            foreach (var contact in _book) // Filtering the Contact's that has E-Mail addresses
            {
                var searchEmail = contact.Emails.FirstOrDefault();
                if (searchEmail != null)
                {
                var searchPhone = contact.Phones.FirstOrDefault();
                contacts.Add(new User()
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Phone = searchPhone.Number,
                        Email = searchEmail.Address,
                    });
                }
            };

            _contacts = (from c in contacts orderby c.FirstName select c).ToList();
            return _contacts;
        }

        //public List<MobileUserContact> Find(string searchString)
        //{
        //    var ResultContacts = new List<MobileUserContact>();

        //    foreach (var currentContact in _contacts)
        //    {
        //        // Running a basic String Contains() search through all the 
        //        // fields in each Contact in the list for the given search string
        //        if ((currentContact.Contact_FirstName != null && currentContact.Contact_FirstName.ToLower().Contains(searchString.ToLower())) ||
        //            (currentContact.Contact_LastName != null && currentContact.Contact_LastName.ToLower().Contains(searchString.ToLower())) ||
        //            (currentContact.Contact_EmailId != null && currentContact.Contact_EmailId.ToLower().Contains(searchString.ToLower())))
        //        {
        //            ResultContacts.Add(currentContact);
        //        }
        //    }

        //    return ResultContacts;
        //}

        public IEnumerable<User> GetDeviceContactsOld()
        {
            var phoneContacts = new List<User>();

            using (var phones = Android.App.Application.Context.ContentResolver.Query(ContactsContract.CommonDataKinds.Phone.ContentUri, null, null, null, null))
            {
                if (phones != null)
                {
                    while (phones.MoveToNext())
                    {
                        try
                        {
                            string name = phones.GetString(phones.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                            string phoneNumber = phones.GetString(phones.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number));
                            string email = phones.GetString(phones.GetColumnIndex(ContactsContract.CommonDataKinds.Email.Address));

                            string[] words = name.Split(' ');
                            var contact = new User();
                            contact.FirstName = words[0];
                            if (words.Length > 1)
                                contact.LastName = words[1];
                            else
                                contact.LastName = ""; //no last name
                            contact.Phone = phoneNumber;
                            contact.Email = email;
                            phoneContacts.Add(contact);
                        }
                        catch (Exception ex)
                        {
                            //something wrong with one contact, may be display name is completely empty, decide what to do
                            Debug.WriteLine(ex.Message);
                        }
                    }
                    phones.Close();
                }
                // if we get here, we can't access the contacts. Consider throwing an exception to display to the user
            }

            return phoneContacts;
        }
    }
}