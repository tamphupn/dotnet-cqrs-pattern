using CqrsV1.Domain.Common;

namespace CqrsV1.Domain.Entities
{
	public class OrderDetail: BaseEntity
    {
		public int ProductId { get; set; }
		public decimal? Price { get; set; }
		public int OrderId { get; set; }
    }
}

