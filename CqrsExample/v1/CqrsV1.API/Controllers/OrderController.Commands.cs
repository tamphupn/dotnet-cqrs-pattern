using CqrsV1.API.BuildingBlocks.CqrsCore;
using CqrsV1.Application.ApplicationServices.V1.OrderAppService.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CqrsV1.API.Controllers
{
    public partial class OrderController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] CreateOrderCommand command)
		{
			var isSuccess = await GetContext.SendCommand<CreateOrderCommand, bool>(command);

			if (isSuccess)
			{
				return Ok(isSuccess);
			}

			return BadRequest();
        }
	}
}

