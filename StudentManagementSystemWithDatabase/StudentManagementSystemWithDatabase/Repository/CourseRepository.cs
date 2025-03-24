using Microsoft.EntityFrameworkCore;
using StudentManagementSystemWithDatabase.Context;
using StudentManagementSystemWithDatabase.Exception;
using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public class CourseRepository : ICourseRepository
    {
        readonly StudentManegementDbContext _studentManagementContext;
        public CourseRepository(StudentManegementDbContext studentManegementDbContext)
        {
            _studentManagementContext = studentManegementDbContext;
        }
        public async Task <int>AddCourse(Course course)
        {
             await _studentManagementContext.Courses.AddAsync(course);
            return await _studentManagementContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCourse(int id)
        {
            var res = await _studentManagementContext.Courses.FindAsync(id);
            if (res == null)
            {
                throw new CourseNotFoundException($"Id{id} not found");
            }
            _studentManagementContext.Courses.Remove(res);
            return await _studentManagementContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _studentManagementContext.Courses.Include(b=>b.Enrollments).ToListAsync();
           
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _studentManagementContext.Courses.FindAsync(id);
            if (course == null)
            {
                throw new CourseNotFoundException($"Course with Id {id} not found");
            }
            return course;
        }

        public async Task<int> UpdateCourse(Course course)
        {
            
            Course updateCourse=await GetCourseById(course.Id);
            if (updateCourse != null)
            {
                updateCourse.CourseName = course.CourseName;
                updateCourse.Description = course.Description;
                updateCourse.Credits= course.Credits;
                updateCourse.Enrollments= course.Enrollments;
                _studentManagementContext.Courses.Update(updateCourse);
                return await _studentManagementContext.SaveChangesAsync();
            }
            return 0;

        }
    }
}
