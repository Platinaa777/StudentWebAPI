using MyWebAPI.DTOs;
using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public interface IStudentService
    {
        Task<List<GetStudentDto>> GetStudents();
        Task<GetStudentDto> GetStudent(int id);
        Task<GetStudentDto> GetStudentByNameAndLastName(string name, string lastname);
        Task<List<GetStudentDto>> CreateStudent(AddStudentDto student);
        Task<GetStudentDto> UpdateStudent(UpdateStudentDto student);
        Task<List<GetStudentDto>> DeleteStudent(int id);
    }
}
