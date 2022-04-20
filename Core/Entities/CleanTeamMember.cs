namespace Core.Entities
{
	public class CleanTeamMember
	{
		public int CleanTeamMemberId { get; set; }
		public bool IsApproved { get; set; }
		public string CleanerName { get; set; }
		public int CleanerId { get; set; }
		public string PhoneNumber { get; set; }

	}
}