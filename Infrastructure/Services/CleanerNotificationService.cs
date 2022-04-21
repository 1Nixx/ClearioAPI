using Core.CleanerNotificationService;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class CleanerNotificationService : ICleanerNotificationService
	{
		private readonly IGenericRepository<Order> _orderRepository;
		public CleanerNotificationService(IGenericRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task UpdateCleanerConditionAsync(CleanerNotificationInfo cleanerInfo)
		{
			var spec = new OrdersWithCleanersForNotification(cleanerInfo.ObjectId);
			var order = await _orderRepository.GetEntityWithSpec(spec);

			foreach (var cleaner in order.Cleaners)
			{
				if (cleaner.CleanerId == cleanerInfo.ClenerId)
				{
					if (cleaner.IsStartingWorking)
					{
						cleaner.IsFinishedWorking = true;
						cleaner.EndWorking = DateTimeOffset.FromUnixTimeSeconds(cleanerInfo.UnixTime).LocalDateTime;
					}
					else
					{
						cleaner.IsStartingWorking = true;
						cleaner.StartWorking = DateTimeOffset.FromUnixTimeSeconds(cleanerInfo.UnixTime).LocalDateTime;
					}
					break;
				}			
			}
			await _orderRepository.UpdateEntityAsync(order);
		}
	}
}
