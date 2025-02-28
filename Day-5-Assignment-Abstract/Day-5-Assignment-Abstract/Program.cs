using Day_5_Assignment_Abstract.Model;

namespace Day_5_Assignment_Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
             VehicleInsurance bike=new TwoWheelerInsurance(5000);
            VehicleInsurance car = new FourWheelerInsurance(10000);
            VehicleInsurance truck = new CommercialInsurance(20000);

            bike.DisplayPremium();
            car.DisplayPremium();
            truck.DisplayPremium();


        }
    }
}
