using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Services
{
    public class UsersInMemoryService
    {
        private static List<User> users = new List<User>
        {
            new User
            {
                Name="Pille",
                FirstName="Serge",
                Age=47,
                Email="serge@pille.be",
                Phone="0471/276717"
            },
            new User
            {
                Name="Mortelé",
                FirstName="Nathalie",
                Age = 39,
                Email="nathalie.mortele@telenet.be",
                Phone="0477/609074"
            }
        };

        public async Task<User> GetUserById(Guid id)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return users.FirstOrDefault(u => u.Id == id);
        }

        public async Task SaveUser(User user)
        {
            var oldUser = await GetUserById(user.Id);
            oldUser = user;
        }

    }
}
