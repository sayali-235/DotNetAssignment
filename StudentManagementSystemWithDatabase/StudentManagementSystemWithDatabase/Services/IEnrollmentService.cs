using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Services
{
    public interface IEnrollmentService
    {
        Task WithdrawStudent(int studentId, int courseId);
        Task<int> EnrollStudent(int studentId, int courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int studentId);
    }
}
