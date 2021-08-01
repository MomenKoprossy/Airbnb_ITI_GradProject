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
            return await PropertyEntity.SingleOrDefaultAsync(s => s.PropertyId == id);
        }
       
        public async void Insert(Property obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        public async void Update(Property obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async void Delete(int id, string id2)
        {
            Property p = await GetByIdAsync(id, "");
            PropertyEntity.Remove(p);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<Property>> GetUserReservations(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
