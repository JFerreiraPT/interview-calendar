using System;
using Interview_Calendar.DTOs;
using Interview_Calendar.Models;

namespace Interview_Calendar.Services
{
	public interface IUserService
	{
		Task<UserDto?> CreateUserAsync(UserCreateDto userDto);
        Task<UserDto?> GetUserByEmailAsync(string email);

    }
}

