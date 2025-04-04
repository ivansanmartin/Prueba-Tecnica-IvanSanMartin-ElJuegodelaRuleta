using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
    
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("{username}")]
        public IActionResult GetByUsername([FromRoute] string username)
        {
            var user = _context.User.FirstOrDefault( user => user.Username == username ) ;

            if (user == null){
                return NotFound();
            }

            return Ok(user);

        }
    }
}