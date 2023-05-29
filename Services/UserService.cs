using System;
using AutoMapper;
using Interview_Calendar.Data;
using Interview_Calendar.DTOs;
using Interview_Calendar.Helpers;
using Interview_Calendar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Interview_Calendar.Services
{
	public class UserService : IUserService
	{
        private readonly IMongoCollection<User> _userCollection;
        private readonly IMapper _mapper;
        private readonly PasswordHasher _passwordHasher;

        public UserService(IOptions<UserDBConfiguration> userConfiguration, IMapper mapper, PasswordHasher hasher)
		{
            _mapper = mapper;
            _passwordHasher = hasher;
            var mongoClient = new MongoClient(userConfiguration.Value.ConnectionString);
            var userDatabase = mongoClient.GetDatabase(userConfiguration.Value.DatabaseName);
            _userCollection = userDatabase.GetCollection<User>(userConfiguration.Value.UserCollectionName);

        }

        public async Task<UserDto?> CreateUserAsync(UserCreateDto userDto)
        {
            var checkIfUserExists = _userCollection.Find(x => x.Email == userDto.Email).FirstOrDefault();

            if (checkIfUserExists != null)
            {
                return null;
            }

            //Encript passwprd
            userDto.Password = _passwordHasher.Hash(userDto.Password);

            try
            {
                await _userCollection.InsertOneAsync(_mapper.Map<User>(userDto));

                return _mapper.Map<UserDto>(userDto);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email) => _mapper.Map<UserDto>(await _userCollection.FindAsync(x => x.Email == email).Result.FirstOrDefaultAsync());
    }
}

