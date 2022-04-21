using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class OrderWithFullInfo : BaseSpecification<Order>
	{
		public OrderWithFullInfo(int id) : base (x => x.Id == id)
		{
			AddInclude(x => x.CleaningObject);
			AddInclude(x => x.Cleaners);
		}
	}
}
