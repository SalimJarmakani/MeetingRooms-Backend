using Microsoft.AspNetCore.Identity;

namespace MeetingRooms_Backend.Models.Auth
{
	public class User : IdentityUser<Guid>
	{

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
