using System;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.Json;
using AutoMapper;
using Interview_Calendar.Data;
using Interview_Calendar.DTOs;
using Interview_Calendar.Helpers;
using Interview_Calendar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<UserDTO?> CreateUserAsync(UserCreateDTO userDto)
        {
            var userExists = _userCollection.Find(x => x.Email == userDto.Email).Any();

            if (userExists)
            {
                return null;
            }

            //Encript passwprd
            userDto.Password = _passwordHasher.Hash(userDto.Password);


            User user = null;

            //Get types with reflexion
            var userType = userDto.UserType;
            var targetType = Assembly.GetExecutingAssembly()
                                    .GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals(userType.ToString(), StringComparison.OrdinalIgnoreCase));

            if (targetType != null)
            {
                user = (User)Activator.CreateInstance(targetType);
                _mapper.Map(userDto, user);
            }
            else
            {
                //Todo:Throw exception
            }

            try
            {
                await _userCollection.InsertOneAsync(user);

                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                //Todo:Throw exception
                return null;
            }
            
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email) => _mapper.Map<UserDTO>(await _userCollection.FindAsync(x => x.Email == email).Result.FirstOrDefaultAsync());

    }
}

