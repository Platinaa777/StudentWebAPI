using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyWebAPI.DTOs;
using MyWebAPI.Models;

namespace MyWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<UpdateStudentDto, GetStudentDto>();
        }
    }
}
