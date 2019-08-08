using AutoMapper;
using UserRegistration.Api.ViewModels;
using UserRegistration.Data.Entities;

namespace UserRegistration.Api.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
