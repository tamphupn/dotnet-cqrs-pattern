using System;
namespace CqrsV1.Domain.Common
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTimeOffset? CreationTime { get; set; }
		public DateTimeOffset? UpdatedTime { get; set; }
    }
}

