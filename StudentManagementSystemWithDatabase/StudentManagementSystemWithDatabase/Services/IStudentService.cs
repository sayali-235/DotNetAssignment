using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Services
{
    public interface IStudentService
    {
        Task<int> AddStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
        Task<int> UpdateStudent(Student student);
        Task<Student> GetStudentById(int id);
        Task<int> DeleteStudent(int id);
    }
}
