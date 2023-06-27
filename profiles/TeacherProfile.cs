using AutoMapper;
using TeachersPet.Entities;
using TeachersPet.Models;

namespace TeachersPet.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, UserDto>();
            CreateMap<UserDto, Teacher>();
            CreateMap<RegisterDto, Teacher>();
        }
    }
}