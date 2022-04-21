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
		List<CleanerInfo> GetALLCleanersByAddress(string address);
		List<CleanerInfo> GetAllCleaners();
		List<CleanerInfo> GetSetOfCleaners(int amount, string address);
		CleanerInfo GetCleaner(string address);
		CleanerInfo GetCleanerById(int cleanerId);
		int AddCleaner(CleanerShortInfo cleanerInfo);
		void RemoveCleaner(int cleanerId);
	}
}
