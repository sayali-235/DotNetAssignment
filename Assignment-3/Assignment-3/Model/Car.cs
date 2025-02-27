using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3.Model
{
    internal class Car
    {
        public int carID;
        public string brand;
        public string model;
        public int year;
        public double price;

        public void ReceiveInfo()
        {
            Console.WriteLine("Enter the CarID: ");
            carID=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Brand Name:");
            brand = Console.ReadLine();

            Console.WriteLine("Enter the Model Name: ");
            model = Console.ReadLine();

            Console.WriteLine("Enter the Year: ");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the price: ");
            price = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Recieve The Car Information");
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Your Car details are follow: ");
            Console.WriteLine($"CarId : {carID} \nCar brand:{brand} \nCar Model: {model}\nYear: {year}\nCar Price: {price}");
        }
    }
}
