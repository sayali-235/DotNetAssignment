using Assignment_4_Static_Oops.Model;

namespace Assignment_4_Static_Oops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Manager(101,"sayali",200000,50.0);
            e.DisplayDetails();
            Employee e1 = new Employee(1012, "abc", 30000);
            e1.DisplayDetails();

        }
    }
}
