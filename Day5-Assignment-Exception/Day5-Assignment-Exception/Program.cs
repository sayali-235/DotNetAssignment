using Day5_Assignment_Exception.Model;
using Day5_Assignment_Exception.Repository;

namespace Day5_Assignment_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAccountValidator bank = new Bank();
            Console.WriteLine("Enter Beneficiary account number: ");
            string accNo=Console.ReadLine();
            bank.ValidateAccount(accNo);
        }
    }
}
