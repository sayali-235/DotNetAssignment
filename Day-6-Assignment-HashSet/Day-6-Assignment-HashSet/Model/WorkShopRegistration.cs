using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Assignment_HashSet.Model
{
    internal class WorkShopRegistration
    {
        HashSet<int> studentRegistrations;
        public WorkShopRegistration() 
        {
            studentRegistrations = new HashSet<int>();
        }
        public void RegisterStudent(int studentId)
        {
            if(studentRegistrations.Add(studentId))
            {
                Console.WriteLine($"Student {studentId} registered successfully");
            }
            else
            {
                Console.WriteLine($"Student {studentId} is already registered");
            }
        }
        public void DisplayRegistrations()
        {
            if(studentRegistrations.Count >0)
            {
                Console.WriteLine("Registered students: "+string.Join(",", studentRegistrations));

            }
            else
            {
                Console.WriteLine("No students registered");
            }
        }

    }
}
