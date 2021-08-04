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
    public class ReservationRepository : IRepository<Reservation>
    {
        private AirbnbModel context;
        private DbSet<Reservation> ReservationEntity;
        public ReservationRepository(AirbnbModel context)
        {
            this.context = context;
            ReservationEntity = context.Set<Reservation>();
        }
        public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(string id)
        {
            return await ReservationEntity.Where(x => x.UserID == id).Include(x => x.Property).Include(x => x.User).ToListAsync();
        }
        public async Task<int> InsertAsync(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            return obj.ReservationID;
        }
        public async Task UpdateAsync(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, string id2)
        {
            Reservation p = await GetByIdAsync(id, "");
            ReservationEntity.Remove(p);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await ReservationEntity.Include(x => x.Property).Include(x => x.User).ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id, string id2)
        {
            return await ReservationEntity.Include(x => x.Property).Include(x => x.User).SingleOrDefaultAsync(s => s.ReservationID == id);
        }

        public Task<IEnumerable<Reservation>> GetNearbyPlacesAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetPropertyImage(int id)
        {
            throw new NotImplementedException();
        }
    }
}
