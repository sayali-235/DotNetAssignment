using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Assignment_Abstract.Model
{
    internal class FourWheelerInsurance : VehicleInsurance
    {
        public FourWheelerInsurance(double basePremium) : base(vehicleType: "Four-Wheeler", basePremium)
        {
            
        }
        public override double CalculatePremium()
        {
            return BasePremium * 1.10;
        }
    }
}
