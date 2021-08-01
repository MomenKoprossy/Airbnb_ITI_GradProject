using Data.Model;
using DataEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<PropertyImage>> GetAllAsync()
        {
            return await PropertyImageEntity.ToListAsync();
        }
        public IEnumerable<PropertyImage> GetAll()
        {
            return PropertyImageEntity.AsEnumerable();
        }
        public async Task<PropertyImage> GetByIdAsync(int id, string id2)
        {
            return await PropertyImageEntity.SingleOrDefaultAsync(s => s.PropertyID == id);
        }
        public async void Insert(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        public async void Update(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async void Delete(int id, string id2)
        {
            PropertyImage p = await GetByIdAsync(id, "");
            PropertyImageEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public async void Save()
        {
           await  context.SaveChangesAsync();
        }

        public PropertyImage GetById(int id, string id2)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PropertyImage>> GetUserReservations(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
