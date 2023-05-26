using System;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IOptions<UserDBConfiguration> userConfiguration, IMapper mapper)
		{
            _mapper = mapper;
            var mongoClient = new MongoClient(userConfiguration.Value.ConnectionString);
            var userDatabase = mongoClient.GetDatabase(userConfiguration.Value.DatabaseName);
            _userCollection = userDatabase.GetCollection<User>(userConfiguration.Value.UserCollectionName);

        }

        public async Task<UserDto?> CreateUserAsync(UserDto userDto)
        {
            var checkIfUserExists = _userCollection.Find(x => x.Email == userDto.Email);

            if (checkIfUserExists != null)
            {
                return null;
            }

            //=> await _userCollection.InsertOneAsync(_mapper.Map<User>(userDto))
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email) => _mapper.Map<UserDto>(await _userCollection.FindAsync(x => x.Email == email));
    }
}

