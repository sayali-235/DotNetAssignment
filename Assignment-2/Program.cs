namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question1-Net Salary Computation
            //Console.WriteLine("Enter the basic salary: ");
            //double basicSalary=Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Enter the rating 1-10");
            //double rating=Convert.ToDouble(Console.ReadLine());

            //double taxDec = basicSalary * 0.10;
            //double bonus = 0;

            //if(rating >= 8)
            //{
            //    bonus = basicSalary * 0.20;
            //}
            //else if(rating >= 5)
            //{
            //    bonus = basicSalary * 0.10;
            //}
            //else
            //{
            //    Console.WriteLine("No Bonus");
            //}

            //double netSalary = basicSalary - taxDec + bonus;
            //Console.WriteLine($"Net salary after tax and bonus: {netSalary}");
            //Console.ReadLine();

            #endregion


            #region Question2-Train Ticket Booking
            //Console.WriteLine("Welcome to online train ticket booking system");
            //Console.WriteLine("Ticket Prices: ");
            //Console.WriteLine("1. General : 200Rs");
            //Console.WriteLine("2. Sleeper : 500Rs");
            //Console.WriteLine("3. AC : 1000Rs");

            //double totalCost = 0;
            //while (true)
            //{
            //    Console.WriteLine("Enter the Ticket type \nGeneral/Sleeper/AC or type exit to finish ticket:");
            //    String ticketType=Console.ReadLine().Trim().ToLower();

            //    if(ticketType=="exit")
            //    {
            //        break;
            //    }
            //    double price = 0;
            //    switch(ticketType)
            //    {
            //        case "general":
            //            price = 200;
            //            break;

            //        case "sleeper":
            //            price = 500;
            //            break;

            //        case "ac":
            //            price = 1000;
            //            break;

            //        default:
            //            Console.WriteLine("Invalid TicketType");
            //            continue;
            //    }
            //    Console.WriteLine("Enter the number of tickets you want: ");
            //    //int quantity=Convert.ToInt32(Console.ReadLine());

            //    if(!int.TryParse(Console.ReadLine(), out int quantity) || quantity <=0)
            //    {
            //        Console.WriteLine("Invalid Number");
            //        continue ;
            //    }
            //    double cost=price* quantity;
            //    totalCost += cost;

            //    Console.WriteLine($"Booking Confirmed {ticketType}\t{quantity} and cost for ticket {cost}");


            //}

            //Console.WriteLine($"Total Cost ofyour booking is {totalCost}");
            //Console.WriteLine("Thank for train ticket bokking \nHappy Journey!!!!!");
            //Console.ReadLine();
            #endregion


            #region Question3-Shopping Center
            int[] userIds = { 101, 102, 103, 104, 105 };
            decimal[] walletsBal = { 250.75m, 125.50m, 500.00m, 78.30m };

            Console.WriteLine("Online Shopping Center");

            int userID;
            bool isValidUser = false;

            while (!isValidUser)
            {
                Console.WriteLine("Please enter the userID : ");
                bool isNumeric=int.TryParse(Console.ReadLine(), out userID);

                if (isNumeric)
                {
                    for (int i = 0; i < userIds.Length; i++)
                    {
                        if (userID == userIds[i])
                        {
                            isValidUser = true;
                            Console.WriteLine($"Your UserID is {userID} and your Wallet balance is : ${walletsBal[i]:0.00}");
                            break;
                        }
                    }
                    if(!isValidUser)
                    {
                        Console.WriteLine("Invalid UserID please try agian");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }


            }
            Console.WriteLine("Thank you");
            Console.ReadLine();
            #endregion

           
        }
    }
}
