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
        public IEnumerable<Reservation> GetAll()
        {
            return ReservationEntity.AsEnumerable();
        }
        public Reservation GetById(int id, string id2)
        {
            return ReservationEntity.SingleOrDefault(s => s.ReservationID == id);
        }
        public void Insert(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(Reservation obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            Reservation p = GetById(id, "");
            ReservationEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
