using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private CleaningContext _context { get; set; }
		public GenericRepository(CleaningContext context)
		{
			_context = context;
		}

		public async Task<int> CountAllAsync()
		{
			return await _context.Set<T>().CountAsync();
		}

		public async Task DeleteByIdAsync(int id)
		{
			var entity = await _context.Set<T>().FindAsync(id);
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task UpdateEntityAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task AddEntityAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}
	}
}
