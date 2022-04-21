using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CleanerNotificationService
{
	public class CleanerNotificationInfo
	{
		public int ObjectId { get; set; }
		public int ClenerId { get; set; }
		public int UnixTime { get; set; }
	}
}
