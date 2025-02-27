namespace Assignment_3_StringMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Password: ");
            string password=Console.ReadLine();

            if (password.Length < 6)
            {
                Console.WriteLine("PAssword must be at least 6 characters long");
            }
            else if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain atleast one uppercase letter");
            }
            else if(!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must contain at least one digit");
            }
            else
            {
                Console.WriteLine("Password is Valid");
            }
            
        }
    }
}
