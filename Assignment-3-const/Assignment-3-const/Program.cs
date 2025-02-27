using Assignment_3_const.Model;

namespace Assignment_3_const
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car(101,"toyoyo","abc",2002,200000);
            c.GetAllDetails();
            Console.ReadLine();
        }
    }
}
