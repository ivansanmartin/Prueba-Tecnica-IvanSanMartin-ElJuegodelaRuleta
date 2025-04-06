using backend.Controllers.Dtos;
using backend.Data;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
    
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public IActionResult GetByUsername([FromRoute] string username)
        {
            var user = _userService.GetByUsername(username);

            if (user == null){
                return StatusCode(404, new {ok = false, message = "Not found user profile", code = "NOT_FOUND_PROFILE"});
            }

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.CreateUser(userDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userService.UpdateUser(userDto);

            return Ok(result);

        }
    }
}