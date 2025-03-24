using Microsoft.EntityFrameworkCore;
using StudentManagementSystemWithDatabase.Context;
using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        readonly StudentManegementDbContext _studentManegementDbContext;
        public EnrollmentRepository(StudentManegementDbContext studentManegementDbContext)
        {
            _studentManegementDbContext = studentManegementDbContext;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int studentId)
        {
           
            
                var student= await _studentManegementDbContext.Enrollments
                 
                 //.Include(e=>e.Student)

                 .Include(e=>e.Course)
                 .Where(e => e.StudentId== studentId)
                 .ToListAsync();
            return student;
            
        }
        public async Task<int> EnrollStudent(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };
            await _studentManegementDbContext.Enrollments.AddAsync(enrollment);
            return await _studentManegementDbContext.SaveChangesAsync();
        }

        public async Task WithdrawStudent(int studentId, int courseId)
        {
            var enrollment = await _studentManegementDbContext.Enrollments
           .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment != null)
            {
                _studentManegementDbContext.Enrollments.Remove(enrollment);
                await _studentManegementDbContext.SaveChangesAsync();
            }
        }
    }
}
