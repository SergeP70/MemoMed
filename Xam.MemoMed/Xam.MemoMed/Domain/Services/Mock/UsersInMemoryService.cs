using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;
using Xam.MemoMed.Domain.Services.Abstract;

namespace Xam.MemoMed.Domain.Services.Mock
{
    public class UsersInMemoryService : IUsersService
    {
        private static List<User> users = new List<User>
        {
            new User
            {
                Id=1,
                LastName = "Pille",
                FirstName="Serge",
                Age=47,
                Email="serge.pille@telenet.be",
                Phone="0471501136"
            },
            new User
            {
                Id=2,
                LastName="Pille",
                FirstName="Arthur",
                Age = 5,
                Email="arthur.pille@telenet.be",
                Phone="0477/609074"
            },
            new User
            {
                Id=3,
                LastName="Vandewalle",
                FirstName="Dr. Christiaan",
                Age = 58,
                Email="dr.vandewalle@telenet.be",
                Phone="0475/123456"
            }
        };

        public async Task<User> GetUserById(int id)
        {
            await Task.Delay(0);
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task SaveUser(User user)
        {
            var oldUser = await GetUserById(user.Id);
            oldUser = user;
        }

    }
}
