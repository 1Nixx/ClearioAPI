using Core.CleanerNotificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class CleanerNotificationService : ICleanerNotificationService
	{
		public CleanerNotificationService()
		{

		}

		public Task UpdateCleanerConditionAsync(CleanerNotificationInfo cleanerInfo)
		{
			return null;
		}
	}
}
