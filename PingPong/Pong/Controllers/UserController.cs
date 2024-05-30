using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pong.PongDbContext.Tables;

namespace Pong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDbContextFactory<PongDbContext.PongDbContext> contextFactory;

        public UserController(IDbContextFactory<PongDbContext.PongDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }

        [HttpPost("/addUsers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Users>))]
        public IActionResult AddUser(string name)
        {
            using var context = contextFactory.CreateDbContext();
            var user = new Users
            {
                Id = Guid.NewGuid().ToString(),
                Name = name
            };
            context.Users.Add(user);
            context.SaveChanges();

            return Ok(new ServiceResponse<Users> { Response = user });
        }
    }
}
