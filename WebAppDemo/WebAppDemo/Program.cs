using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContext context = new StudentContext();
            ////creating database schema if not existing
            context.Database.EnsureCreated();

            ////Create Grade Object
            Grade grade = new Grade() { GradeName = "Electronics" };
            Student student = new Student() { Name = "Vanishree", Grade = grade };

            ////add student to database(StudentsTable)
            context.Students.Add(student);
            context.SaveChanges();

            ////Get All Students
            foreach (var item in context.Students)
            {
                Console.WriteLine($"Name::{item.Name} Grade::{item.GradeId}");
            }
        }
    }
}
