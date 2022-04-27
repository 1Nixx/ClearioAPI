using Core.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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

		public async Task<int> UpdateEntityAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<int> AddEntityAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public async Task<int> CountAsync(ISpecification<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
		}

		public async Task DeleteWithSpec(ISpecification<T> spec)
		{
			var order = await ApplySpecification(spec).FirstOrDefaultAsync();
			if (order != null)
			{
				_context.Set<T>().Remove(order);
				await _context.SaveChangesAsync();
			}
;		}
	}
}
