using System;
using System.ComponentModel.DataAnnotations;

namespace Interview_Calendar.DTOs
{
	public class UserCreateDto : UserDto
	{
		[Required]
		[MinLength(8)]
        public string Password { get; set; } = default!;
        public UserCreateDto()
		{
		}
	}
}

