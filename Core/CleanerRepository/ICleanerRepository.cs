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
		List<CleanerInfo> GetALLCleaners(string address);
		List<CleanerInfo> GetSetOfCleaners(int amount, string address);
		CleanerInfo GetCleaner(string address);
		CleanerInfo GetCleanerById(int cleanerId);
		int AddCleaner(CleanerInfo cleanerInfo);
		void RemoveCleaner(int cleanerId);
	}
}
