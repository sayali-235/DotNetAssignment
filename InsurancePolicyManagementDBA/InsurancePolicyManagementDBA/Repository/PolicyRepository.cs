using System;
 
using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Exception;
using InsurancePolicyManagementSystem.Model;
using System.Data.SqlClient;
using InsurancePolicyManagementDBA.Utility;

namespace InsurancePolicyManagementSystem.Repository
{
    internal class PolicyRepository :  IPolicyRepository
    {
        List<Policy> policies=new List<Policy>();
        SqlCommand cmd = null;
        string connstring;
        public PolicyRepository()
        {
            //policies = new List<Policy>();
            cmd = new SqlCommand();
            connstring = DbConnUtil.GetConnectionString();
        }

        public int AddNewPolicy(Policy policy)
        {
             using (SqlConnection sqlConnection = new SqlConnection(connstring))
            { 
            
                cmd.CommandText = "Insert into Policies(HolderName,PolicyType,StartDate,EndDate) values (@HolderName,@PolicyType,@StartDate,@EndDate)";
                cmd.Parameters.AddWithValue("@HolderName", policy.HolderName);
                cmd.Parameters.AddWithValue("@PolicyType", policy.Type);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();

            }

               // policies.Add(policy);
                //Console.WriteLine("Policy added successfully");
        }

        public int DeletePolicy(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {

                cmd.CommandText = "Delete from Policies where PolicyID=@PolicyID";
                cmd.Parameters.AddWithValue("@PolicyID", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();

            }

            //Policy policy =SearchPolicyById(id);
            // policies.Remove(policy);
            //Console.WriteLine("Policy deleted Successfully");
        }

        public Policy SearchPolicyById(int id)
        {
            Policy policy=policies.Find(p=>p.PolicyID == id);
            if (policy == null)
              throw new PolicyNotFoundException("Invalid Policy ID !!\nPolicy is Not Found");
             return policy;
            
        }

        public int UpdatePolicy(int id)
        {
            List<Policy>policyList=ViewAllPolicy();
            using(SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.Parameters.Clear();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                try
                {

                    Console.WriteLine("\nChoose field to update:");
                    Console.WriteLine("1. Policy Holder Name");
                    Console.WriteLine("2. Policy Type");
                    Console.WriteLine("3. End Date");
                    Console.WriteLine("4.Exit");
                    

                      if(!policyList.Any(p=> p.PolicyID==id))
                    {
                        throw new PolicyNotFoundException($" Policy ID {id} not found");
                    }
                    while (true)
                    {
                        Console.Write("Enter your choice: ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter new Policy Holder Name: ");
                                string HolderName = Console.ReadLine();
                                cmd.CommandText = "Update Policies set HolderName=@HolderName where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@HolderName" ,HolderName);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("Policy Holder Name updated successfully.");
                                break;

                            case 2:
                                Console.Write("Enter new Policy Type (Life, Health, Vehicle, Property): ");
                                PolicyType type=(PolicyType)Enum.Parse(typeof(PolicyType),Console.ReadLine(),true);
                                cmd.CommandText = "Update Policies set PolicyType=@PolicyType where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@PolicyType", type);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("Policy type updated successfully.");
                                break;

                            case 3:
                                Console.Write("Enter new End Date (yyyy-MM-dd): ");
                                 DateTime EndDate=DateTime.Parse(Console.ReadLine());
                                cmd.CommandText = "Update Policies set EndDate=@EndDate where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("Policy EndDate updated successfully.");

                                break;
                            case 4:
                                return cmd.ExecuteNonQuery();
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                       

                    }
                }
                catch(PolicyNotFoundException ex)
                {
                    Console.WriteLine("Invalid Policy ID");
                    return 0;
                }


            
            }

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

        public List<Policy> ViewAllPolicy()
        {
            List<Policy>policies=new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "select * from Policies";
                cmd.Connection=sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader= cmd.ExecuteReader();

                while(reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = (int)reader["PolicyID"];
                    policy.HolderName = (string)reader["HolderName"];
                    policy.Type = (PolicyType)reader["PolicyType"];
                    policy.StartDate=(DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policies.Add(policy);
                    

                }
            return policies;
            }
            
           //if(policies.Count ==0)
            //{
              //  Console.WriteLine("No Policies found");
                //return;
            //}
            //policies.ForEach(p => Console.WriteLine(p));
        }
    }
}
