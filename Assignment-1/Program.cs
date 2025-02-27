namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            String name;
            int age;
            double percentage;
            Console.WriteLine("Student Mnagement");
            Console.WriteLine("Please Enter");

            Console.WriteLine("Name: ");
            name=Console.ReadLine();

            Console.WriteLine("Age: ");
            bool isProper;
            isProper=int.TryParse(Console.ReadLine(),out age);
            //Console.WriteLine(isProper ? age : "Invalid Age");
            if (isProper)
            {
                Console.WriteLine(age);
            }
            else
            {
                Console.WriteLine("Invalid Age");
            }

            Console.WriteLine("Percentage: ");
            percentage=Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Name is  {name},age is {age}, percentage is {percentage}");
            #endregion

            #region 

            String email;
            Console.WriteLine("Enter Email: ");
            email=Console.ReadLine();
            
            if(email.Length >0)
            {
                Console.WriteLine(email);

            }
            else
            {
                Console.WriteLine("Email can not be empty");
            }
            #endregion


            #region

            Console.WriteLine("Hospital Management ");
            String date;
            Console.WriteLine("Enter the discharged Date: ");
            date=Console.ReadLine();
            if(date.Length >0)
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("Not Discharged");
            }


            #endregion
        }
    }
}
