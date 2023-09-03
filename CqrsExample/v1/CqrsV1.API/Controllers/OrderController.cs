using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CqrsV1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class OrderController: ControllerBase
	{
        private readonly IHttpContextAccessor _context;

        public OrderController(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public HttpContext GetContext => _context.HttpContext ?? throw new ArgumentNullException(nameof(_context.HttpContext));
    }
}

