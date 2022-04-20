namespace API.DTOs
{
	public class OrderShortInfo
	{
		public int OrderId { get; set; }
		public string OrderName { get; set; }
		public string OrderLocation { get; set; }
		public DateTime OrderStart { get; set; }
		public int Status { get; set; }
	}
}
