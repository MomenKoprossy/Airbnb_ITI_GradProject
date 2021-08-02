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
    public class PropertyReviewRepository : IRepository<PropertyReview>
    {
        private AirbnbModel context;
        private DbSet<PropertyReview> PropertyReviewEntity;
        public PropertyReviewRepository(AirbnbModel context)
        {
            this.context = context;
            PropertyReviewEntity = context.Set<PropertyReview>();
        }


        public async Task<int> InsertAsync(PropertyReview obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return obj.PropertyID;
        }
        public async Task UpdateAsync(PropertyReview obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            PropertyReview p = await GetByIdAsync(id, "");
            PropertyReviewEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<PropertyReview>> GetAllAsync()
        {
            return await PropertyReviewEntity.ToListAsync();
        }
        public async Task<PropertyReview> GetByIdAsync(int id, string id2)
        {
            return await PropertyReviewEntity.SingleOrDefaultAsync(s => s.PropertyID == id);
        }
        public Task<IEnumerable<PropertyReview>> GetUserReservationsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReview>> GetNearbyPlacesAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PropertyReview>> GetPropertyImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
