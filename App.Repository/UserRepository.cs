using Data.Model;
using DataEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class UserRepository : IUserRepository
    {
        private AirbnbModel context;
        private DbSet<User> UserEntity;

        public UserRepository(AirbnbModel context)
        {
            this.context = context;
            UserEntity = context.Set<User>();
        }

        public void DeleteUser(string id)
        {
            User user = GetUser(id);
            UserEntity.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(string id)
        {
            return UserEntity.SingleOrDefault(s => s.Id == id);
        }

        public void SaveUser(User user)
        {
            context.Entry(user).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.SaveChanges();
        }
    }
}
