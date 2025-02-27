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
        public int carId;

        public string brand;
        public string model;
        public int year;
        public double price;

        //public Car()
        //{


        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        //}
        public Car(int carId, string brand, string model, int year, double price)
        {
            this.carId = carId;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
        }



        public string GetAllDetails()
        {
            return $"CarID: {carID}, Brand: {brand} Model: {model}, Price: {price}";
        }        //public Car()
        //{


        //}
        public Car(int carId, string brand, string model, int year, double price)
        {
            this.carId = carId;
            this.brand = brand;
            this.model = model;
            this.year = year;
            double price = price;
        }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int year { get; set; }
        public double Price { get; set; }



        public string GetAllDetails()
        {
            return $"CarID: {carID}, Brand: {brand} Model: {model}, Price: {price}";
        }
    }
}
