using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class OrdersWithObjectData: BaseSpecification<Order>
	{
		public OrdersWithObjectData(): base()
		{
			AddInclude(x => x.CleaningObject);
		}
	}
}
