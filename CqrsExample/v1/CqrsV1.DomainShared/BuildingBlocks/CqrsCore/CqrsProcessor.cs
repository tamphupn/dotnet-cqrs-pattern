using System;
namespace CqrsV1.DomainShared.BuildingBlocks.CqrsCore
{
	public static class CqrsProcessor
	{
		//public static ICommandHandler<T, TResult> GetCommandHandler<T>(this HttpContext )
		public static ValueTask<TResult> SendCommand(this HttpContext)
	}
}

