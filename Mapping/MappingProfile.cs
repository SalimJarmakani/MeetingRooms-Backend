using AutoMapper;
using MeetingRooms_Backend.Models.Auth;
using MeetingRooms_Backend.Resources;

namespace MeetingRooms_Backend.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() {

			CreateMap<UserSignUpResource, User>()
			.ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

		}
	}
}
