using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CleanerRepository
{
	public class ByoneRemoteInfo
	{
		public Links links { get; set; }
		public int count { get; set; }
		public CleanerRemoteInfo[] results { get; set; }
	}

	public class Links
	{
		public string? next { get; set; }
		public string? previous { get; set; }
	}
}
