using CqrsV1.Application.BuildingBlocks.DbContext;
using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;
using Microsoft.EntityFrameworkCore;

namespace CqrsV1.Application.ApplicationServices.V1.OrderAppService.Queries
{
    public class GetOrderByIdQuery
    {
        public GetOrderByIdQuery(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class DeleteOrderCommandHandler : IQueryHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly ICqrsApplicationDbContext _context;

        public DeleteOrderCommandHandler(ICqrsReadonlyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async ValueTask<OrderViewModel> Handle(GetOrderByIdQuery command, CancellationToken token)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == command.Id, token);
            if (order == null)
            {
                throw new Exception("Not Found");
            }

            return new OrderViewModel()
            {
                Id = order.Id,
                Fullname = order.Fullname,
                CreationTime = order.CreationTime,
                TotalPrice = order.TotalPrice
            };
        }
    }
}

