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
        public IEnumerable<Wishlist> GetAll()
        {
            return WishlistEntity.AsEnumerable();
        }
        public Wishlist GetById(int id, string id2)
        {
            return WishlistEntity.SingleOrDefault(s => s.WishlistID == id);
        }
        public void Insert(Wishlist obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(Wishlist obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            Wishlist p = GetById(id, "");
            WishlistEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
