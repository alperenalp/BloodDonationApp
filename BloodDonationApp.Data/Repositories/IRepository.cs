using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationApp.Data.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task<bool> IsExistsAsync(int id);
    }
}
