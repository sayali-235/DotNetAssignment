using System.Diagnostics;
using System.Xml.Linq;
using Day_7_Assignment_LINQ.Model;

namespace Day_7_Assignment_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
            new Product { ProductID = 1, ProductName = "Smartphone", Category = "Electronics", Price = 15000 },
            new Product { ProductID = 2, ProductName = "Laptop", Category = "Electronics", Price = 50000 },
            new Product { ProductID = 3, ProductName = "Washing Machine", Category = "Home Appliances", Price = 20000 },
            new Product { ProductID = 4, ProductName = "Headphones", Category = "Electronics", Price = 1200 },
            new Product { ProductID = 5, ProductName = "Book", Category = "Stationery", Price = 500 },
            new Product { ProductID = 6, ProductName = "Tablet", Category = "Electronics", Price = 8000 }
            };
            var filterProducts = products.Where(p => p.Category == "Electronics" && p.Price > 1000);

            Console.WriteLine("Electronics products costing more than Rs.1000: ");
            foreach (var  product in filterProducts)
            {
                Console.WriteLine($"ID: {product.ProductID},Name: {product.ProductName}");
            }
            var mostExpensiveProduct = products.OrderByDescending(p => p.Price).First();
            Console.Writeline("\nMost Expensive Product: ");
            Console.Writeline($"ID: {mostExpensiveProduct.ProductID},Name: {mostExpensiveProduct.ProductName}, Price: {mostExpensiveProduct.Price}");
        }
    }
}
