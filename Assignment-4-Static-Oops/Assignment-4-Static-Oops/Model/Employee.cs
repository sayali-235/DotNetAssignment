using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Static_Oops.Model
{
    internal class Employee
    {
        
        public Employee(int id, string name, double salary)
        {
             EmpID = id;
             EmpName = name;
             Salary = salary;
        }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; } 

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmpID} \tEmployee Name: {EmpName}\t Employee Salary: {Salary}");
        }
        
    }
}
