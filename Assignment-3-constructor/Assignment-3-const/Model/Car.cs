using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_const.Model
{
    internal class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        
        public Car(int carId, string brand, string model, int year, double price)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }



        public void GetAllDetails()
        {
            //return $"CarID: {carID}, Brand: {brand} Model: {model}, Price: {price}";
            Console.WriteLine($"CarID: {CarId}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Price: {Price}");
        }         
    }
}
