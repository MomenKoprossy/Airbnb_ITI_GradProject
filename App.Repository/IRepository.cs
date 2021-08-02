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
        Task<IEnumerable<T>> GetUserReservationsAsync(string id);
        Task<IEnumerable<T>> GetNearbyPlacesAsync(string country);
        Task<IEnumerable<T>> GetPropertyImage(int id);
        Task<int> InsertAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(int id, string id2);
    }
}
