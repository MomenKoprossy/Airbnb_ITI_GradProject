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
    public class UserGeneric<T> : IRepository<T> where T : User
    {
        private AirbnbModel context;
        private DbSet<T> UserEntity;

        public UserGeneric(AirbnbModel context)
        {
            this.context = context;
            UserEntity = context.Set<T>();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            T user = GetById(id);
            UserEntity.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return UserEntity.AsEnumerable();
        }





        public T GetById(string id)
        {
            return UserEntity.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            UserEntity.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
