using Data.Model;
using DataEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await PropertyEntity.ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id, string id2)
        {
            return await PropertyEntity.SingleOrDefaultAsync(s => s.PropertyID == id);
        }

        public async Task<int> InsertAsync(Property obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return obj.PropertyID;
        }
        public async Task UpdateAsync(Property obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            Property p = await GetByIdAsync(id, "");
            PropertyEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public Task<IEnumerable<Property>> GetUserReservationsAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetNearbyPlacesAsync(string country)
        {
            return await PropertyEntity.Where(x => x.Country == country).ToListAsync();
        }

        public Task<IEnumerable<Property>> GetPropertyImage(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
