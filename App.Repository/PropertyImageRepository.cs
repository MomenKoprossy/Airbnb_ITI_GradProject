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
        public async Task<PropertyImage> GetByIdAsync(int id, string id2)
        {
            return await PropertyImageEntity.SingleOrDefaultAsync(s => s.PropertyID == id);
        }
        public async Task<int> InsertAsync(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return (obj.PropertyID);
        }
        public async Task UpdateAsync(PropertyImage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            PropertyImage p = await GetByIdAsync(id, "");
            PropertyImageEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public Task<IEnumerable<PropertyImage>> GetUserReservationsAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<PropertyImage>> GetNearbyPlacesAsync(string country)
        {
            throw new System.NotImplementedException();
        }
    }
}
