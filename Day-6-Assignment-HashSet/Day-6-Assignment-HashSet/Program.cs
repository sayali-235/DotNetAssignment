using Day_6_Assignment_HashSet.Model;

namespace Day_6_Assignment_HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
             WorkShopRegistration  aiWorkshop = new WorkShopRegistration();
             WorkShopRegistration webWorkshop= new WorkShopRegistration();

            aiWorkshop.RegisterStudent(101);
            aiWorkshop.RegisterStudent(102);
            aiWorkshop.RegisterStudent(103);
            aiWorkshop.RegisterStudent(101);

            aiWorkshop.RegisterStudent(104);

            Console.WriteLine("\n AI Workshop Registration: ");

            aiWorkshop.DisplayRegistrations();

            Console.WriteLine("\n Web Development workshop registrations: ");
            webWorkshop.DisplayRegistrations();
        }
    }
}
