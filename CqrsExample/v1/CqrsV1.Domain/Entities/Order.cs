using CqrsV1.Domain.Common;

namespace CqrsV1.Domain.Entities
{
	public class Order: BaseEntity
    {
        public decimal TotalPrice { get; set; }

        public string? Fullname { get; set; }

        public string? EmailAddress { get; set; }
    }
}

