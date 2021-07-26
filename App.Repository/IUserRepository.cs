using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public interface IUserRepository
    {
        void SaveUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUser(string id);
        void DeleteUser(string id);
        void UpdateUser(User user);

    }
}
