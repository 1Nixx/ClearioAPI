using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Order : BaseEntity
	{
		public CleaningObject CleaningObject { get; set; }
		public int CleaningObjectId { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }
		public List<CleanTeamMember> Cleaners { get; set; }
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
