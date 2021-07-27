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
    public class AmenityRepository : IRepository<Amenity>
    {
        private AirbnbModel context;
        private DbSet<Amenity> AmenityEntity;
        public AmenityRepository(AirbnbModel context)
        {
            this.context = context;
            AmenityEntity = context.Set<Amenity>();
        }
        public IEnumerable<Amenity> GetAll()
        {
            return AmenityEntity.AsEnumerable();
        }
        public Amenity GetById(int id, string id2)
        {
            return AmenityEntity.SingleOrDefault(s => s.AmenityId == id);
        }
        public void Insert(Amenity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(Amenity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            Amenity p = GetById(id, "");
            AmenityEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
