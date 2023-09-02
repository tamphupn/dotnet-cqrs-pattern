using CqrsV1.Application.BuildingBlocks.DbContext;
using CqrsV1.Domain.Entities;
using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;

namespace CqrsV1.Application.ApplicationServices.V1.OrderAppService.Commands
{
	public class CreateOrderCommand
	{
		public CreateOrderCommand(
            string fullname,
            IList<OrderDetail> details)
		{
            Fullname = fullname;
            Details = details;
		}

        public string Fullname { get; }

        public IList<OrderDetail> Details { get; }
	}

    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, bool>
    {
        private readonly ICqrsApplicationDbContext _context;

        public CreateOrderCommandHandler(ICqrsApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async ValueTask<bool> Handle(CreateOrderCommand command, CancellationToken token)
        {
            await using (var transaction = await _context.DatabaseInstance.BeginTransactionAsync(token))
            {
                var insertedOrder = new Order()
                {
                    Fullname = command.Fullname,
                    TotalPrice = 0,
                    CreationTime = DateTimeOffset.UtcNow
                };
                await _context.Orders.AddAsync(insertedOrder, token);

                List<OrderDetail> details = command.Details.Select(x =>
                {
                    x.OrderId = insertedOrder.Id;
                    x.CreationTime = DateTimeOffset.UtcNow;
                    return x;
                }).ToList();

                await _context.OrderDetails.AddRangeAsync(details);

                await _context.SaveChangesAsync(token);
            }

            return true;
        }
    }
}








