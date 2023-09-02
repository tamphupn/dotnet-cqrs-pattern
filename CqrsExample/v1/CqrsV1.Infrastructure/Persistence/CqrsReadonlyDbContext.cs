using CqrsV1.Application.BuildingBlocks.DbContext;
using Microsoft.EntityFrameworkCore;

namespace CqrsV1.Infrastructure.Persistence
{
    public class CqrsReadonlyDbContext : CqrsBaseContext, ICqrsReadonlyDbContext
    {
        public CqrsReadonlyDbContext(DbContextOptions<CqrsReadonlyDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new InvalidOperationException("This is Readonly DbContext, we can not save change on this!");
        }
    }
}

