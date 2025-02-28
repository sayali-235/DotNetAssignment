using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Assignment_Abstract.Model
{
    internal class CommercialInsurance:VehicleInsurance
    {
        public CommercialInsurance(double basePremium):base(vehicleType:"Commercial",basePremium)
        {
        }

        public override double CalculatePremium()
        {
            return BasePremium * 1.20;
        }
    }
}
