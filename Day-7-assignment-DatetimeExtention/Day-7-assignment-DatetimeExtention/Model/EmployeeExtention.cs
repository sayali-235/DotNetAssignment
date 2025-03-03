using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7_assignment_DatetimeExtention.Model
{
    static class EmployeeExtention
    {
        public static int GetYearsOfExperience(this Employee employee)
        {
            int currentYear = DateTime.Now.Year;
            int joiningYear = employee.JoiningDate.Year;
            return currentYear - joiningYear;
        }
    }
}
