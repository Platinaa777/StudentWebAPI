using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> GetStudentByNameAndLastName(string name, string lastname);
        Task<List<Student>> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<List<Student>> DeleteStudent(int id);
    }
}
