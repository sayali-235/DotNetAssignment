using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Static_Oops.Model
{
    internal class Manager:Employee
    {
        double pBonus;
        public  double PropertyBonus { get; set; }
        public Manager(int id,string name, double esalary, double pBonus): base(id, name, esalary) 
        {
            this.pBonus = pBonus;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmpID} \tEmployee Name: {EmpName}\t Employee Salary: {Salary}\t Property Bonus: {pBonus}");
        }
    }
}
