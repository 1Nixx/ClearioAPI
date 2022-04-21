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
			return Task.FromResult(Random.Shared.Next(50));
		}

		public Task<List<CleanerInfo>> GetAllCleanersAsync()
		{
			var cleaners = new List<CleanerInfo>();
			for (int i = 0; i < 25; i++)
			{
				cleaners.Add(new CleanerInfo
				{
					CleanerId = i,
					CleanerName = $"Nikita{i}",
					PhoneNumber = $"+375_{i}"
				});
			};
			return Task.FromResult(cleaners);
		}

		public Task<List<CleanerInfo>> GetALLCleanersByAddressAsync(string address)
		{
			var cleaners = new List<CleanerInfo>();
			for (int i = 0; i < 25; i++)
			{
				cleaners.Add(new CleanerInfo
				{
					CleanerId = i,
					CleanerName = $"Nikita{i}",
					PhoneNumber = $"+375_{i}"
				});
			};
			return Task.FromResult(cleaners);
		}

		public Task<CleanerInfo> GetCleanerAsync(string address)
		{
			int x = Random.Shared.Next(50);
			return Task.FromResult(new CleanerInfo
			{
				CleanerId = x,
				CleanerName = $"Nikita{x}",
				PhoneNumber = $"+3753333551{x}"
			});
		}

		public Task<CleanerInfo> GetCleanerByIdAsync(int cleanerId)
		{
			return Task.FromResult(new CleanerInfo
			{
				CleanerId = cleanerId,
				CleanerName = $"Nikita{cleanerId}",
				PhoneNumber = $"+3753333551{cleanerId}"
			});
		}

		public Task<List<CleanerInfo>> GetSetOfCleanersAsync(int amount, string address)
		{
			var cleaners = new List<CleanerInfo>();
			for (int i = 0; i < amount; i++)
			{
				cleaners.Add(new CleanerInfo
				{
					CleanerId = i,
					CleanerName = $"Nikita{i}",
					PhoneNumber = $"+375_{i}"
				});
			};
			return Task.FromResult(cleaners);
		}

		public Task RemoveCleanerAsync(int cleanerId)
		{
			return Task.CompletedTask;
		}
	}
}
