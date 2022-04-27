using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<int> CountAllAsync();
        Task<int> UpdateEntityAsync(T entity);
        Task<int> AddEntityAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task DeleteWithSpec(ISpecification<T> spec);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
