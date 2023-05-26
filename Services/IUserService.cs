using System;
using Interview_Calendar.DTOs;

namespace Interview_Calendar.Services
{
	public interface IUserService
	{
		Task<UserDto?> CreateUserAsync(UserCreateDto userDto);
        Task<UserDto?> GetUserByEmailAsync(string email);
    }
}

