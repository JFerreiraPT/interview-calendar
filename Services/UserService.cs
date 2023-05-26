using System;
using Interview_Calendar.Data;
using Interview_Calendar.DTOs;
using Interview_Calendar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Interview_Calendar.Services
{
	public class UserService : IUserService
	{
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<UserDBConfiguration> userConfiguration)
		{
		}

        public Task<bool> CreateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}

