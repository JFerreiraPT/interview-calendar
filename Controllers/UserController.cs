using System;
using Interview_Calendar.DTOs;
using Interview_Calendar.Models;
using Interview_Calendar.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Calendar.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreate)
		{
			var user = await _userService.CreateUserAsync(userCreate);
			return CreatedAtAction(nameof(Create), new { nameof = user.Name }, user);
		}

		[HttpGet("{email}")]
		public async Task<IActionResult> GetByEmail(string email)
		{
			var user = await _userService.GetUserByEmailAsync(email);
			return Ok(user);
		}
	}
}

