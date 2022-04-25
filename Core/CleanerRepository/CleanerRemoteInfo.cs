using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CleanerRepository
{
	public class CleanerRemoteInfo
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string city { get; set; }
		public string phonenumber { get; set; }
		public bool isworking { get; set; }
		public int rating { get; set; }
	}
}
