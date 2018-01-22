using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services.Abstract
{
    public interface IUserInfoService
    {
        IEnumerable<User> GetDeviceContacts();

    }
}
