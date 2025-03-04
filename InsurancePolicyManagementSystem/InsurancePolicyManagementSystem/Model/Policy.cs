using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicyManagementSystem.Constants;

namespace InsurancePolicyManagementSystem.Model
{
    internal class Policy
    {
        private static int idCounter = 1;
        public int PolicyID { get; }
        public string HolderName { get; set; }
        public  PolicyType Type{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy(string holderName, PolicyType type, DateTime startDate, DateTime endDate)
        {
            PolicyID = idCounter++;
            HolderName = holderName;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }
        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;

        }
        public override string ToString()
        {
            return  $"ID:{PolicyID},\tPolicy Holder Name:{HolderName}\tPolicy Type:{Type}\tStart Date:{StartDate}\tEnd Date:{EndDate} ";
        }
    }
}
