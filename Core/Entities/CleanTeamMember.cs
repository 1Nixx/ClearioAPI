namespace Core.Entities
{
	public class CleanTeamMember
	{
		public int CleanTeamMemberId { get; set; }
		public bool IsStartingWorking { get; set; }
		public bool IsFinishedWorking { get; set; }
		public string CleanerName { get; set; }
		public int CleanerId { get; set; }
		public string PhoneNumber { get; set; }

		public DateTime StartWorking { get; set; }
		public DateTime EndWorking { get; set; }

	}
}