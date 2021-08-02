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
    public class HostLanguageRepository : IRepository<HostLanguage>
    {
        private AirbnbModel context;
        private DbSet<HostLanguage> HostLanguageEntity;
        public HostLanguageRepository(AirbnbModel context)
        {
            this.context = context;
            HostLanguageEntity = context.Set<HostLanguage>();
        }
        public async Task<IEnumerable<HostLanguage>> GetAllAsync()
        {
            return await HostLanguageEntity.ToListAsync();
        }
        public async Task<HostLanguage> GetByIdAsync(int id, string id2)
        {
            return await HostLanguageEntity.SingleOrDefaultAsync(s => s.HostID == id2);
        }
        public async Task<int> InsertAsync(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return 0;
        }
        public async Task UpdateAsync(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            HostLanguage p = await GetByIdAsync(0, id2);
            HostLanguageEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public Task<IEnumerable<HostLanguage>> GetUserReservationsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
