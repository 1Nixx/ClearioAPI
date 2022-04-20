using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAllAsync();
        Task UpdateEntityAsync(T entity);
        Task AddEntityAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
