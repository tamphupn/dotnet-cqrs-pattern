using CqrsV1.API.BuildingBlocks.CqrsCore;
using CqrsV1.Application.ApplicationServices.V1.OrderAppService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CqrsV1.API.Controllers
{
    public partial class OrderController: ControllerBase
    {
		public async Task<ActionResult<OrderViewModel>> GetByIdAsync(int id)
		{
			var order = await GetContext.SendCommand<GetOrderByIdQuery, OrderViewModel>(new GetOrderByIdQuery(id));
			if (order == null)
			{
				return NotFound();
			}

            return Ok(order);
        }
	}
}

