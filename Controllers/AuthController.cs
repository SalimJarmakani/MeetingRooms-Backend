using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingRooms_Backend.Models.Auth;
using MeetingRooms_Backend.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyMusic.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public AuthController(IMapper mapper, UserManager<User> userManager)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		[HttpPost("signup")]
		public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
		{
			var user = _mapper.Map<UserSignUpResource, User>(userSignUpResource);

			var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

			if (userCreateResult.Succeeded)
			{
				return Created(string.Empty, string.Empty);
			}

			return Problem(userCreateResult.Errors.First().Description, null, 500);
		}


		[HttpPost("SignIn")]
		public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
		{
			var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
			if (user is null)
			{
				return NotFound("User not found");
			}

			var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

			if (userSigninResult)
			{
				return Ok();
			}

			return BadRequest("Email or password incorrect.");
		}
	}
}