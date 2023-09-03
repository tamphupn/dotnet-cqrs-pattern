using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;

namespace CqrsV1.API.BuildingBlocks.CqrsCore
{
    public static class CqrsProcessor
    {
        public static ICommandHandler<T, TResult> GetCommandHandler<T, TResult>(this HttpContext context) => context.RequestServices.GetRequiredService<ICommandHandler<T, TResult>>();
        public static IQueryHandler<T, TResult> GetQueryHandler<T, TResult>(this HttpContext context) => context.RequestServices.GetRequiredService<IQueryHandler<T, TResult>>();

        public static ValueTask<TResult> SendCommand<TCommand, TResult>(this HttpContext context, TCommand command)
        {
            return context.GetCommandHandler<TCommand, TResult>().Handle(command, context.RequestAborted);
        }

        public static ValueTask<TResult> SendQuery<TQuery, TResult>(this HttpContext context, TQuery query)
        {
            return context.GetQueryHandler<TQuery, TResult>().Handle(query, context.RequestAborted);
        }
    }
}

