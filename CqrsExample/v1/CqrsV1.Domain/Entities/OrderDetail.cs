namespace CqrsV1.Domain.Entities
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public string? ProductName { get; set; }
		public decimal? Price { get; set; }
        public DateTimeOffset? CreationTime { get; set; }
		public int OrderId { get; set; }
    }
}

