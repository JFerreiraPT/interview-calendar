using System;
using Interview_Calendar.DTOs;
using Interview_Calendar.Models;

namespace Interview_Calendar.Services
{
	public interface IUserService
	{
		Task<UserDTO?> CreateUserAsync(UserCreateDTO userDto);
        Task<UserDTO?> GetUserByEmailAsync(string email);

    }
}

