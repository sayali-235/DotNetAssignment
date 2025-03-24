using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student>GetStudentById(int id);
        Task<int> AddStudent(Student student);
        Task <int>UpdateStudent(Student student);
        Task <int>DeleteStudent(int id);
       
    }
}
