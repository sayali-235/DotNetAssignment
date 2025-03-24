using StudentManagementSystemWithDatabase.Exception;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Repository;

namespace StudentManagementSystemWithDatabase.Services
{
    public class CourseService : ICourseService
    {
        readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> AddCourse(Course course)
        {
           return await _courseRepository.AddCourse(course);
        }

        public Task<int> DeleteCourse(int id)
        {
             return _courseRepository.DeleteCourse(id);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses(); 
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course=await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                throw new CourseNotFoundException($"Course with Id{id} not found");
            }
            return course;
        }

        public async Task<int> UpdateCourse(Course course)
        {
            return await _courseRepository.UpdateCourse(course);
        }
    }
}
