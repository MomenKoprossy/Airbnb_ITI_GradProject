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
    public class WishlistRepository : IRepository<Wishlist>
    {
        private AirbnbModel context;
        private DbSet<Wishlist> WishlistEntity;
        public WishlistRepository(AirbnbModel context)
        {
            this.context = context;
            WishlistEntity = context.Set<Wishlist>();
        }
       
        
        public async void Insert(Wishlist obj)
        {
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        public async void Update(Wishlist obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async void Delete(int id, string id2)
        {
            Wishlist p = await GetByIdAsync(id, "");
            WishlistEntity.Remove(p);
            await context.SaveChangesAsync();
        }
     

        public async Task<IEnumerable<Wishlist>> GetAllAsync()
        {
            return await WishlistEntity.ToListAsync();
        }

        public async Task<Wishlist> GetByIdAsync(int id, string id2)
        {
            return await WishlistEntity.SingleOrDefaultAsync(s => s.WishlistID == id);
        }

        public Task<IEnumerable<Wishlist>> GetUserReservations(string id)
        {
            throw new NotImplementedException();
        }
    }
}
