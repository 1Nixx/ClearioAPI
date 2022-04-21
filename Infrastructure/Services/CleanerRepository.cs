using Core.CleanerRepository;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class CleanerRepository : ICleanerRepository
	{
		public Task<int> AddCleanerAsync(CleanerShortInfo cleanerInfo)
		{
			throw new NotImplementedException();
		}

		public Task<List<CleanerInfo>> GetAllCleanersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<CleanerInfo>> GetALLCleanersByAddressAsync(string address)
		{
			throw new NotImplementedException();
		}

		public Task<CleanerInfo> GetCleanerAsync(string address)
		{
			throw new NotImplementedException();
		}

		public Task<CleanerInfo> GetCleanerByIdAsync(int cleanerId)
		{
			return Task.Run(() => new CleanerInfo
			{
				CleanerId = cleanerId,
				CleanerName = $"Nikita{cleanerId}",
				PhoneNumber = $"+3753333551{cleanerId}"
			});
		}

		public Task<List<CleanerInfo>> GetSetOfCleanersAsync(int amount, string address)
		{
			throw new NotImplementedException();
		}

		public Task RemoveCleanerAsync(int cleanerId)
		{
			throw new NotImplementedException();
		}
	}
}
