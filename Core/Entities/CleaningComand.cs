namespace Core.Entities
{
	public class CleaningComand
	{
		public int CleaningComandId { get; set; }
		public bool IsApproved { get; set; }
		public List<CleanTeamMember> TeamMembers { get; set; }
	}
}