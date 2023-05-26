using System;
namespace Interview_Calendar.DTOs
{
	public class UserCreateDto : UserDto
	{
        public string Password { get; set; } = default!;
        public UserCreateDto()
		{
		}
	}
}

