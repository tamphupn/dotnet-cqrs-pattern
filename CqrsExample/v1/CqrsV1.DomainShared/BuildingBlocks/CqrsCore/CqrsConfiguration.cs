using Microsoft.Extensions.DependencyInjection;

namespace CqrsV1.DomainShared.BuildingBlocks.CqrsCore
{
	public static class CqrsConfiguration
	{
		public static IServiceCollection AddCommandHandler<TCommand, TCommandResult, TCommandHandler>(this IServiceCollection serviceCollections) where TCommandHandler: class, ICommandHandler<TCommand, TCommandResult>
		{
			return serviceCollections.AddTransient<TCommandHandler>()
				.AddTransient<ICommandHandler<TCommand, TCommandResult>>(sp => sp.GetRequiredService<TCommandHandler>());
        }

        public static IServiceCollection AddQueryHandler<TQuery, TQueryResult, TQueryHandler>(this IServiceCollection serviceCollections) where TQueryHandler : class, IQueryHandler<TQuery, TQueryResult>
        {
            return serviceCollections.AddTransient<TQueryHandler>()
                .AddTransient<IQueryHandler<TQuery, TQueryResult>>(sp => sp.GetRequiredService<TQueryHandler>());
        }

        public static IServiceCollection AddEventHandler<TEvent, TEventHandler>(this IServiceCollection serviceCollections) where TEventHandler : class, IEventHandler<TEvent>
        {
            return serviceCollections.AddTransient<TEventHandler>()
                .AddTransient<IEventHandler<TEvent>>(sp => sp.GetRequiredService<TEventHandler>());
        }
    }
}