using AutoMapper;
using TeachersPet.Entities;
using TeachersPet.Models;

namespace TeachersPet.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<RegisterDto, User>();
        }
    }
}