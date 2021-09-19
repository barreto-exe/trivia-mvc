using System.Collections.Generic;
using System.Threading.Tasks;
using trivia_mvc.Models;

namespace trivia_mvc.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetById(int id);
        Task Add(User user);
        Task Edit(User user);
        Task Delete(int id);
    }
}
