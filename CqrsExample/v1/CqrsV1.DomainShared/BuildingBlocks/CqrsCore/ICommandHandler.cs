namespace CqrsV1.DomainShared.BuildingBlocks.CqrsCore
{
	public interface ICommandHandler<in T, TResult>
	{
		ValueTask<TResult> Handle(T command, CancellationToken token);
	}
}

