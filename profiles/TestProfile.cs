using AutoMapper;
using TeachersPet.Entities;
using TeachersPet.Models;

namespace TeachersPet.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test, TestDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<TestDto, Test>();
            CreateMap<QuestionDto, Question>();
            CreateMap<AnswerDto, Answer>();
        }
    }
}