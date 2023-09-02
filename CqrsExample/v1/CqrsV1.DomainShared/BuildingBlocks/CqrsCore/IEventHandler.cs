namespace CqrsV1.DomainShared.BuildingBlocks.CqrsCore
{
	public interface IEventHandler<T>
	{
		ValueTask Handle<T>(T @event, CancellationToken token);
	}
}

