using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class OrdersWithCleaners : BaseSpecification<Order>
	{
		public OrdersWithCleaners(int objectId) : base (x => x.CleaningObjectId == objectId)
		{
			AddInclude(x => x.Cleaners);
		}
	}
}
