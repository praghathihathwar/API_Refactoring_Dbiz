using LegacyApp.Contracts;
using LegacyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LegacyApp.Api.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly ILogger<UsersController> _logger;
		private readonly IUserService _userService;
		public UsersController(ILogger<UsersController> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(User request, CancellationToken token)
		{
			try
			{
				var result = await _userService.AddUser(request.Firstname, request.Surname, request.EmailAddress, request.DateOfBirth, request.ClientId);
				var clientStatus = result.Client.ClientStatus.ToString();
				return Ok(new { result.Id, result.Firstname, result.Surname, clientStatus, result.CreditLimit, result.EmailAddress });
			}
			catch (Exception ex)
			{
				_logger.LogError("error while creating user -"+ex.Message,ex);
				return BadRequest(ex.Message);
			}
		}
	}
}
