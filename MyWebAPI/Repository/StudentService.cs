using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            _context.SaveChanges();
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>>? DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return await _context.Students.ToListAsync();
        }

        public async Task<Student>? GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<Student>? GetStudentByNameAndLastName(string name, string lastname)
        {
            var student = await _context.Students.Where(x =>  x.LastName == lastname && x.Name == name).FirstOrDefaultAsync();
            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student>? UpdateStudent(Student student)
        {
            var updatedStudent = await _context.Students.FindAsync(student.Id);
            if (updatedStudent == null)
            {
                return null;
            }
            updatedStudent.Name = student.Name;
            updatedStudent.LastName = student.LastName;
            updatedStudent.Age = student.Age;
            updatedStudent.Class = student.Class;
            _context.Students.Update(updatedStudent);
            _context.SaveChanges();
            return updatedStudent;
        }
    }
}
