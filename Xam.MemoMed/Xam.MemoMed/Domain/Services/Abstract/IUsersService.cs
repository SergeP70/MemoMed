using System;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services.Abstract
{
    public interface IUsersService
    {
        Task<User> GetUserById(int id);
        Task SaveUser(User user);
    }
}
