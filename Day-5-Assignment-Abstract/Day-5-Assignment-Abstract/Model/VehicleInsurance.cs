using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Assignment_Abstract.Model
{
    abstract class VehicleInsurance
    {
        public string VehicleType {  get; set; }
        public double BasePremium {  get; set; }

        public VehicleInsurance(string vehicleType,double basePreminum) 
        {
            VehicleType = vehicleType;
            BasePremium = basePreminum;
        }
        public abstract double CalculatePremium();

        public void DisplayPremium()
        {
            Console.WriteLine($"{VehicleType} Insurance Premium: {CalculatePremium():C}");
        }
    }
}
