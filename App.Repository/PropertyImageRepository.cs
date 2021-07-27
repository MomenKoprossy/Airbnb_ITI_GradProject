using Data.Model;
using DataEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.Repository
{
    public class PropertyImageRepository : IRepository<PropertyImage>
    {
        private AirbnbModel context;
        private DbSet<PropertyImage> PropertyImageEntity;
        public PropertyImageRepository(AirbnbModel context)
        {
            this.context = context;
            PropertyImageEntity = context.Set<PropertyImage>();
        }
        public IEnumerable<PropertyImage> GetAll()
        {
            return PropertyImageEntity.AsEnumerable();
        }
        public PropertyImage GetById(int id, string id2)
        {
            return PropertyImageEntity.SingleOrDefault(s => s.PropertyID == id);
        }
        public void Insert(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            PropertyImage p = GetById(id, "");
            PropertyImageEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
