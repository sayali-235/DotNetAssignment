using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course>GetCourseById(int id);
        Task<int> AddCourse(Course course);
        Task<int> UpdateCourse(Course course);
        Task<int> DeleteCourse(int id);

    }
}
