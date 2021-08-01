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
       
       
        public async Task<IEnumerable<Reservation>> GetUserReservations(string id)
        {
            return await ReservationEntity.Where(x => x.UserID == id).ToListAsync();

        }
        public async void Insert(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        public async void Update(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async void Delete(int id, string id2)
        {
            Reservation p = await GetByIdAsync(id, "");
            ReservationEntity.Remove(p);
            await context.SaveChangesAsync();
        }
       

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await ReservationEntity.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id, string id2)
        {
            return await ReservationEntity.SingleOrDefaultAsync(s => s.ReservationID == id);
        }
    }
}
