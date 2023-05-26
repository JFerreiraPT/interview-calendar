using System;
namespace Interview_Calendar.Data
{
	public class UserDBConfiguration
	{
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserCollectionName { get; set; }

        public UserDBConfiguration()
		{
		}
	}
}

