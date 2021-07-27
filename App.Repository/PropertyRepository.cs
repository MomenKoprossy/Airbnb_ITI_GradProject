using Data.Model;
using DataEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.Repository
{
    public class PropertyRepository : IRepository<Property>
    {
        private AirbnbModel context;
        private DbSet<Property> PropertyEntity;
        public PropertyRepository(AirbnbModel context)
        {
            this.context = context;
            PropertyEntity = context.Set<Property>();
        }
        public IEnumerable<Property> GetAll()
        {
            return PropertyEntity.AsEnumerable();
        }
        public Property GetById(int id)
        {
            return PropertyEntity.SingleOrDefault(s => s.PropertyId == id);
        }
        public void Insert(Property obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(Property obj)
        {
            Property p = GetById(obj.PropertyId.Value);
            context.Entry(p).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            Property p = GetById(id);
            PropertyEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
