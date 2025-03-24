using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public interface IEnrollmentRepository
    {
        Task<int> EnrollStudent(int studentId, int courseId);
        Task WithdrawStudent(int studentId, int courseId);

        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int studentId);
    }
}
