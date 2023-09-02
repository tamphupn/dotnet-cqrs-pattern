using CqrsV1.Application.BuildingBlocks.DbContext;
using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;

namespace CqrsV1.Application.ApplicationServices.V1.OrderAppService.Commands
{
    public class DeleteOrderCommand
    {
        public DeleteOrderCommand(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly ICqrsApplicationDbContext _context;

        public DeleteOrderCommandHandler(ICqrsApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async ValueTask<bool> Handle(DeleteOrderCommand command, CancellationToken token)
        {
            await using (var transaction = await _context.DatabaseInstance.BeginTransactionAsync(token))
            {
                var order = _context.Orders.FirstOrDefault(x => x.Id == command.Id);
                if (order == null)
                {
                    throw new Exception("Not Found");
                }

                _context.Orders.Remove(order);

                await _context.SaveChangesAsync(token);
            }

            return true;
        }
    }
}

