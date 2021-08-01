using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public interface IRepository<T>
    {
        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, string id2);
        Task<IEnumerable<T>> GetUserReservations(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id,string id2);
        

    }
}
