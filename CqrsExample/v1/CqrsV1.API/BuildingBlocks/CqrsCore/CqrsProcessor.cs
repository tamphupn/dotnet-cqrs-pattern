using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;

namespace CqrsV1.API.BuildingBlocks.CqrsCore
{
    public static class CqrsProcessor
    {
        public static ICommandHandler<T, TResult> GetCommandHandler<T, TResult>(this HttpContext context) => context.RequestServices.GetRequiredService<ICommandHandler<T, TResult>>();

        //public static ICommandHandler<T, TResult> GetCommandHandler<T>(this HttpContext )
        public static ValueTask<TResult> SendCommand<TCommand, TResult>(this HttpContext context, TCommand command)
        {
            return context.GetCommandHandler<TCommand, TResult>().Handle(command, context.RequestAborted);
        }
    }
}

