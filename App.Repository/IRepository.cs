using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id,string id2);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id,string id2);
        void Save();
    }
}
