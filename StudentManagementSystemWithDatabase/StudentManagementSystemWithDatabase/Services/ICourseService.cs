using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<int> AddCourse(Course course);
        Task<Course> GetCourseById(int id);
        Task<int> UpdateCourse(Course course);
        Task<int> DeleteCourse(int id);
    }
}
