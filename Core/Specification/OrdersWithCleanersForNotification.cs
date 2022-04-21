using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class OrdersWithCleanersForNotification : BaseSpecification<Order>
	{
		public OrdersWithCleanersForNotification(int objectId) : base (x => x.CleaningObjectId == objectId && x.OrderStatus != OrderStatus.CleaningFinished)
		{
			AddInclude(x => x.Cleaners);
		}
	}
}
