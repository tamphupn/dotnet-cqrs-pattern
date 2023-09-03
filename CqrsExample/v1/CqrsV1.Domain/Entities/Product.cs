using System;
using CqrsV1.Domain.Common;

namespace CqrsV1.Domain.Entities
{
	public class Product: BaseEntity
    {
		public string? Name { get; set; }
		public int? Quantity { get; set; }
		public decimal? Price { get; set; }
	}
}

