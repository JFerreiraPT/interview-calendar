using System;
using Interview_Calendar.DTOs;

namespace Interview_Calendar.Services
{
	public interface IUserService
	{
		Task<bool> CreateUser(UserDto userDto);
        Task<UserDto?> GetUserByEmail(string email);
    }
}

