namespace CqrsV1.Domain.Entities
{
	public class Order
	{
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string? Fullname { get; set; }

        public string? EmailAddress { get; set; }

        public DateTimeOffset? CreationTime { get; set; }
    }
}

