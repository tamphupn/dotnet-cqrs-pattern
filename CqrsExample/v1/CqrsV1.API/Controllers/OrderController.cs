using System;
using CqrsV1.API.BuildingBlocks.CqrsCore;
using CqrsV1.Application.ApplicationServices.V1.OrderAppService.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CqrsV1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
		private readonly IHttpContextAccessor _context;
		public OrderController(IHttpContextAccessor context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
        }

		public async Task<ActionResult<bool>> CreateAsync([FromBody] CreateOrderCommand command)
		{
			var context = _context.HttpContext ?? throw new ArgumentNullException(nameof(_context));

			var isSuccess = await context.SendCommand<CreateOrderCommand, bool>(command);

			if (isSuccess)
			{
				return Ok(isSuccess);
			}

			return BadRequest();
        }
	}
}

