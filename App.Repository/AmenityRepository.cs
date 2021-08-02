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
        public async Task<IEnumerable<Amenity>> GetAllAsync()
        {
            return await AmenityEntity.ToListAsync();
        }
        public async Task<Amenity> GetByIdAsync(int id, string id2)
        {
            return await AmenityEntity.SingleOrDefaultAsync(s => s.AmenityId == id);
        }
        public async Task<int> InsertAsync(Amenity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return obj.AmenityId;
        }
        public async Task UpdateAsync(Amenity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            Amenity p = await GetByIdAsync(id, "");
            AmenityEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public Task<IEnumerable<Amenity>> GetUserReservationsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetNearbyPlacesAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetPropertyImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
