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
		public int AddCleaner(CleanerShortInfo cleanerInfo)
		{
			throw new NotImplementedException();
		}

		public List<CleanerInfo> GetALLCleaners(string address)
		{
			throw new NotImplementedException();
		}

		public List<CleanerInfo> GetAllCleaners()
		{
			throw new NotImplementedException();
		}

		public List<CleanerInfo> GetALLCleanersByAddress(string address)
		{
			throw new NotImplementedException();
		}

		public CleanerInfo GetCleaner(string address)
		{
			throw new NotImplementedException();
		}

		public CleanerInfo GetCleanerById(int cleanerId)
		{
			return new CleanerInfo
			{
				CleanerId = cleanerId,
				CleanerName = $"Nikita{cleanerId}",
				PhoneNumber = $"+3753333551{cleanerId}"
			};
		}

		public List<CleanerInfo> GetSetOfCleaners(int amount, string address)
		{
			throw new NotImplementedException();
		}

		public void RemoveCleaner(int cleanerId)
		{
			throw new NotImplementedException();
		}
	}
}
