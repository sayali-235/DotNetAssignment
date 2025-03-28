using Microsoft.EntityFrameworkCore;
using StudentManagementSystemWithDatabase.Context;
using StudentManagementSystemWithDatabase.Exception;
using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Repository
{
    public class StudentRepository : IStudentRepository
    {
       readonly StudentManegementDbContext _studentManagementContext;
        public StudentRepository(StudentManegementDbContext studentManegementDbContext)
        {
            _studentManagementContext = studentManegementDbContext;
        }
        public async Task<int> AddStudent(Student student)
        {
            await _studentManagementContext.Students.AddAsync(student);
            return await _studentManagementContext.SaveChangesAsync();
        }



        public async Task<int> DeleteStudent(int id)
        {
            var res=await _studentManagementContext.Students.FindAsync(id);
            if (res == null) 
            {
                throw new StudentNotFoundException($"Id{id} not found");
            }
            _studentManagementContext.Students.Remove(res);
          return  await _studentManagementContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentManagementContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _studentManagementContext.Students.FindAsync(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with Id {id} not found");
            }
            return student;
        }

        public async Task<int> UpdateStudent(Student student)
        {
             
            Student updateStudent = await GetStudentById(student.Id);
            if (updateStudent != null)
            {
                updateStudent.FirstName = student.FirstName;
                updateStudent.LastName = student.LastName;
                updateStudent.Email = student.Email;
                updateStudent.DateOfBirth = student.DateOfBirth;
                updateStudent.Enrollments = student.Enrollments;
                _studentManagementContext.Students.Update(updateStudent);
                return await _studentManagementContext.SaveChangesAsync();
            }
            return 0;



        }
    }
}


