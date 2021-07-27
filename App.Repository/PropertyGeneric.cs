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
    public class PropertyGeneric<T> : IRepository<T> where T : Property
    {
        private AirbnbModel context;
        private DbSet<T> PropertyEntity;
        public PropertyGeneric(AirbnbModel context)
        {
            this.context = context;
            PropertyEntity = context.Set<T>();
        }
       
      

        public void Delete(string id)
        {
            T Property = GetById(id);
            PropertyEntity.Remove(Property);
            context.SaveChanges();
        }

       

        public IEnumerable<T> GetAll()
        {
            return PropertyEntity.AsEnumerable();
        }

        public T GetById(string id)
        {
            int ID = int.Parse(id);
            return PropertyEntity.SingleOrDefault(s => s.PropertyId == ID);
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
            PropertyEntity.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
