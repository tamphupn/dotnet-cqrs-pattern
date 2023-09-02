namespace CqrsV1.DomainShared.BuildingBlocks.CqrsCore
{
    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query, CancellationToken token);
    }
}

