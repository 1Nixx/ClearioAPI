using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class OrderWithCleaners: BaseSpecification<Order>
	{
		public OrderWithCleaners(int id) : base(x => x.Id == id)
		{
			AddInclude(x => x.Cleaners);
		}
	}
}
