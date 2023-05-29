using System;
namespace Interview_Calendar.DTOs
{
	public class InterviewerResponseDTO : UserDTO
	{
        public Dictionary<DateOnly, List<int>> Availability = default!;
        public List<DateTime> Interviews = default!;

	}
}

