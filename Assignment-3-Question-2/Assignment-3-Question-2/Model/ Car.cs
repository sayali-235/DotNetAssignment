using System;

public class Car.Model
{
	public Car()
	{
		int carID;
		string brand;
		string model;
		int year;
		double price;

		public Car()
		{
			
		}
		public Car(int carId, string brand, string model, int year,double price)
		{
			this.carId = carId;
			this.brand=brand;
			this.model=model;
			this.year=year;
			double price;
		}
		public int CarId { get;set; }
		public string Brand { get;set; } 
		public string Model { get;set; }
		public int year { get;set; }
		public double Price { get;set; }

		public void display()
		{
	     Console.WriteLine($"CarId: {carId} Brand: {brand} Model: {model} Year: {year} Price: {price}");
		}
	}
}
