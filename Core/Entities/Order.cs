using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public CleaningObject CleaningObject { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }
		public CleaningComand Comand { get; set; }
		public OrderStatus OrderStatus { get; set; }
	}

	public enum OrderStatus
	{
		WaitingCleaningBeninings,
		CleanerDelayed,
		CleanerNotCome,
		CleaningInProcess,
		CleaningFinished,
		Error
	}
}
