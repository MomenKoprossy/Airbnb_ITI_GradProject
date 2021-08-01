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
       
       
        public async void Insert(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        public async void Update(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async void Delete(int id, string id2)
        {
            HostLanguage p = await GetByIdAsync(0, id2);
            HostLanguageEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public async Task<IEnumerable<HostLanguage>> GetAllAsync()
        {
            return await HostLanguageEntity.ToListAsync();
        }

        public async Task<HostLanguage> GetByIdAsync(int id, string id2)
        {
            return await HostLanguageEntity.SingleOrDefaultAsync(s => s.HostID == id2);
        }

        public Task<IEnumerable<HostLanguage>> GetUserReservations(string id)
        {
            throw new NotImplementedException();
        }
    }
}
