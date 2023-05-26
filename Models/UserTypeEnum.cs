using System;
using System.Text.Json.Serialization;

namespace Interview_Calendar.Models
{
    //Convert to and from string
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserTypeEnum
	{
        interviewer,
        Candidate,
    }
}

