using Core.CleanerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ICleanerRepository
	{
		Task<List<CleanerInfo>> GetALLCleanersByAddressAsync(string address);
		Task<List<CleanerInfo>> GetAllCleanersAsync();
		Task<List<CleanerInfo>> GetSetOfCleanersAsync(int amount, string address);
		Task<CleanerInfo> GetCleanerAsync(string address);
		Task<CleanerInfo> GetCleanerByIdAsync(int cleanerId);
		Task<int> AddCleanerAsync(CleanerShortInfo cleanerInfo);
		Task RemoveCleanerAsync(int cleanerId);
	}
}
