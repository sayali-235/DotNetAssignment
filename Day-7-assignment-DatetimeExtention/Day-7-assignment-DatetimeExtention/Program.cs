using Day_7_assignment_DatetimeExtention.Model;

namespace Day_7_assignment_DatetimeExtention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Sayali", new DateTime(2018, 3, 3));

            int experince = emp.GetYearsOfExperience();

            Console.WriteLine($"Employee:{emp.Name}");
            Console.WriteLine($"Joining Date: {emp.JoiningDate.ToShortDateString()}");
            Console.WriteLine($"Years of Experince: {experince}");
        }
    }
}
