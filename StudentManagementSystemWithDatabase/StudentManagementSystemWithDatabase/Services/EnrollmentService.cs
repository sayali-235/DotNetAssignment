
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Repository;

namespace StudentManagementSystemWithDatabase.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentId(int studentId)
        {
            return await _enrollmentRepository.GetEnrollmentsByStudentId(studentId);

        }
        public async Task<int> EnrollStudent(int studentId, int courseId)
        {
            return await _enrollmentRepository.EnrollStudent(studentId, courseId);
        }

        public async Task WithdrawStudent(int studentId, int courseId)
        {
            await _enrollmentRepository.WithdrawStudent(studentId, courseId);
        }
    }
}
