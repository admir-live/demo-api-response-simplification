using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Mutable.Process.Infrastructure.Database;

namespace Demo.SimplifyingApi.Orders.Api.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class UserController : ControllerBase
    {
        public UserController(DemoContext context)
        {
            Context = context;
        }

        public DemoContext Context { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await Context.Users.AsNoTracking().ToListAsync(cancellationToken: Request.HttpContext.RequestAborted);
            return Ok(value: users);
        }
    }
}