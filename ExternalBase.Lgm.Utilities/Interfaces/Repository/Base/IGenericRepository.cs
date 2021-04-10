using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalBase.Lgm.Utilities.Interfaces.Repositories.Base
{
    public interface IGenericRepositor<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<int> AddRangeAsync(IEnumerable<T> list);
        Task ReplaceAsync(T t);
        Task<int> AddAsync(T t);
    }
}
