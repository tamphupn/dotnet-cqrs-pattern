namespace CqrsV1.Application.ApplicationServices.V1.OrderAppService.Queries
{
	public class OrderViewModel
	{
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string? Fullname { get; set; }

        public string? EmailAddress { get; set; }

        public DateTimeOffset? CreationTime { get; set; }
    }
}

