using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class CleaningObject : BaseEntity
	{
		public string ObjectName { get; set; }
		public int ObjectSquare { get; set; }
		public string ObjectLocation { get; set; }
		public string ContactTelephone { get; set; }
		public int UsualTeamSize { get; set; }
	}
}
