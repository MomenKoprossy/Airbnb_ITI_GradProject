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
        private  AirbnbModel context;
        private DbSet<User> UserEntity;
        
        public UserRepository(AirbnbModel context)
        {
            this.context = context;
            UserEntity = context.Set<User>();
        }

        public void DeleteUser(int id)
        {
            User user = GetUser(id);
            UserEntity.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserEntity.AsEnumerable();
        }

        public User GetUser(int id)
        {
            return UserEntity.SingleOrDefault(s => s.UserId == id);
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
