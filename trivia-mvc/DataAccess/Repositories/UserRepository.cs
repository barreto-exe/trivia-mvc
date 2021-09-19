using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_mvc.DataAccess.Interfaces;
using trivia_mvc.Models;

namespace trivia_mvc.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TriviaContext triviaContext;
        public UserRepository(TriviaContext triviaContext)
        {
            this.triviaContext = triviaContext;
        }

        public async Task<IEnumerable<User>> Get()
        {
            var users = await triviaContext.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetById(int id)
        {
            var user = await triviaContext.Users.SingleOrDefaultAsync(u => u.IdUser == id);
            return user;
        }
        public async Task Add(User user)
        {
            triviaContext.Users.Add(user);
            await triviaContext.SaveChangesAsync();
        }
        public async Task Edit(User user)
        {
            var outdatedUser = await GetById(user.IdUser);
            if (outdatedUser == null) return;

            outdatedUser.Username = user.Username;
            outdatedUser.DateBirth = user.DateBirth;

            await triviaContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user == null) return;

            triviaContext.Users.Remove(user);

            await triviaContext.SaveChangesAsync();
        }
    }
}
