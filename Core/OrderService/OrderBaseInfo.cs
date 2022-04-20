using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrderService
{
	public class OrderBaseInfo
	{
		public int ObjectId { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }
		public List<int> CleanerId { get; set; }
	}
}
