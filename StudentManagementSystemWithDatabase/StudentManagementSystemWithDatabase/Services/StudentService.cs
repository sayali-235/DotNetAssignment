using StudentManagementSystemWithDatabase.Exception;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Repository;

namespace StudentManagementSystemWithDatabase.Services
{
    public class StudentService : IStudentService
    {
        readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }
        public async Task<int> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<int> UpdateStudent(Student student)
        {
            return await _studentRepository.UpdateStudent(student);
        }
        public async Task<Student> GetStudentById(int id)
        {
            var student=await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with id{id} not found");

            }
            return student;

        }

        public async Task<int> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }
    }
}
