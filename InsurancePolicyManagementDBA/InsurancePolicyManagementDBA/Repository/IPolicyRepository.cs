using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{

    internal interface IPolicyRepository
    {
        public int AddNewPolicy(Policy policy);
        public int UpdatePolicy(int id);
        public int DeletePolicy(int id);
        public List<Policy> ViewAllPolicy();
        public Policy SearchPolicyById(int id);
        public List<Policy> ViewActivePolicies();



    }
}
