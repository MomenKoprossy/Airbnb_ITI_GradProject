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
        public IEnumerable<HostLanguage> GetAll()
        {
            return HostLanguageEntity.AsEnumerable();
        }
        public HostLanguage GetById(int id, string id2)
        {
            return HostLanguageEntity.SingleOrDefault(s => s.HostID == id2);
        }
        public void Insert(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(HostLanguage obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            HostLanguage p = GetById(0, id2);
            HostLanguageEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
