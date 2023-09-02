using CqrsV1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CqrsV1.Infrastructure.Persistence
{
	public class CqrsBaseContext: DbContext
	{
		public CqrsBaseContext(DbContextOptions options):base(options)
		{
		}
        public DatabaseFacade DatabaseInstance => base.Database;
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

