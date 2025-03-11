using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Exception;
using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{
    internal class PolicyRepository :  IPolicyRepository
    {
        List<Policy> policies=new List<Policy>();
        public PolicyRepository()
        {
            policies = new List<Policy>();
        }

        public void AddNewPolicy(Policy policy)
        {
                policies.Add(policy);
                Console.WriteLine("Policy added successfully");
        }

        public void DeletePolicy(int id)
        {
            Policy policy =SearchPolicyById(id);
            policies.Remove(policy);
            Console.WriteLine("Policy deleted Successfully");
        }

        public Policy SearchPolicyById(int id)
        { 
            Policy policy=policies.Find(p=>p.PolicyID == id);
            if (policy == null)
                throw new PolicyNotFoundException("Invalid Policy ID !!\nPolicy is Not Found");
            return policy;
        }

        public void UpdatePolicy(int id, string name, PolicyType type, DateTime startDate, DateTime endDate)
        {
            Policy policy = SearchPolicyById(id);
            policy.HolderName = name;
            policy.Type = type;
            policy.StartDate = startDate;
            policy.EndDate = endDate;
            Console.WriteLine("Policy Updated Successfully");
        }
        public void ViewActivePolicies()
        {
            List<Policy> activePolicies = policies.FindAll(p => p.IsActive());
            if(activePolicies.Count == 0)
            {
                Console.WriteLine("No active policies are found");
                return;
            }
            activePolicies.ForEach(p => Console.WriteLine(p));
        }

        public void ViewAllPolicy()
        {
           if(policies.Count ==0)
            {
                Console.WriteLine("No Policies found");
                return;
            }
            policies.ForEach(p => Console.WriteLine(p));
        }
    }
}
