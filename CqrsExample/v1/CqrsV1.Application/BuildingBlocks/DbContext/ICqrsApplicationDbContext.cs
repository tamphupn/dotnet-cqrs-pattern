using CqrsV1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CqrsV1.Application.BuildingBlocks.DbContext
{
	public interface ICqrsApplicationDbContext : IDisposable
    {
        DatabaseFacade DatabaseInstance { get; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

