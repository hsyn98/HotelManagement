using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IUserRepository
    {
        User Add(User user);
        User Update(User userChanges);
        User Delete(int id);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
    }
}
