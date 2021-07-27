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
        public IEnumerable<PropertyReview> GetAll()
        {
            return PropertyReviewEntity.AsEnumerable();
        }
        public PropertyReview GetById(int id, string id2)
        {
            return PropertyReviewEntity.SingleOrDefault(s => s.PropertyID == id);
        }
        public void Insert(PropertyReview obj)
        {
            context.Entry(obj).State = EntityState.Added;
            Save();
        }
        public void Update(PropertyReview obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id, string id2)
        {
            PropertyReview p = GetById(id, "");
            PropertyReviewEntity.Remove(p);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
