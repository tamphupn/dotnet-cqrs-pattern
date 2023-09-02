using CqrsV1.Application.BuildingBlocks.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CqrsV1.Infrastructure.Persistence
{
	public class CqrsApplicationDbContext: CqrsBaseContext, ICqrsApplicationDbContext
    {
        public CqrsApplicationDbContext(DbContextOptions<CqrsApplicationDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

