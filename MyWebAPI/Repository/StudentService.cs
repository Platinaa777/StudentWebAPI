using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.DTOs;
using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetStudentDto>> CreateStudent(AddStudentDto student)
        {
            await _context.Students.AddAsync(_mapper.Map<Student>(student));
            _context.SaveChanges();
            return await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
        }

        public async Task<List<GetStudentDto>>? DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
        }

        public async Task<GetStudentDto>? GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return _mapper.Map<GetStudentDto>(student);
        }

        public async Task<GetStudentDto>? GetStudentByNameAndLastName(string name, string lastname)
        {
            var student = await _context.Students.Where(x =>  x.LastName == lastname && x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<GetStudentDto>(student);
        }

        public async Task<List<GetStudentDto>> GetStudents()
        {
            return await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
        }

        public async Task<GetStudentDto>? UpdateStudent(UpdateStudentDto student)
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
            _context.Students.Update(_mapper.Map<Student>(updatedStudent));
            _context.SaveChanges();
            return _mapper.Map<GetStudentDto>(updatedStudent);
        }
    }
}
