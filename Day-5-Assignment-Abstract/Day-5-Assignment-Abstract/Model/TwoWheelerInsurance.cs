using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Assignment_Abstract.Model
{
    internal class TwoWheelerInsurance : VehicleInsurance
    {
        public TwoWheelerInsurance(double basePremium) : base(vehicleType: "Two-Wheeler", basePremium)
        {
            
        }
        public override double CalculatePremium()
        {
            return BasePremium * 1.05;
        }
    }
}
