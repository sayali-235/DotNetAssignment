using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Model;
using InsurancePolicyManagementSystem.Repository;

namespace InsurancePolicyManagementDBA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicyRepository repository = new PolicyRepository();
            while (true)
            {
                Console.WriteLine("************************************************************");
                Console.WriteLine("\nInsurance Policy Management System");
                Console.WriteLine("************************************************************");
                Console.WriteLine("1.Add Policy");
                Console.WriteLine("2.View All Policies");
                Console.WriteLine("3.Search Policy by ID: ");
                Console.WriteLine("4.Update Policy");
                Console.WriteLine("5.Delete Policy");
                Console.WriteLine("6.View Active Policies");
                Console.WriteLine("7.Exit");
                Console.WriteLine("Enter Choice:");

                int choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Policy Holder Name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Policy Type(Life,Health, Vehicle, Property : )");
                            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine());
                            Console.WriteLine("Enter the Start Date (yyyy-mm-dd): ");
                            DateTime start = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the End Date (yyyy-mm-dd): ");
                            DateTime end = DateTime.Parse(Console.ReadLine());
                            repository.AddNewPolicy(new Policy()
                            {
                                HolderName=name,
                                Type=type,
                                StartDate=start,
                                EndDate=end
                            });
                            break;
                        case 2:
                            
                            List<Policy>Policies=repository.ViewAllPolicy();
                            foreach (var item in Policies)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Policy ID: ");
                            int searchId = int.Parse(Console.ReadLine());
                            Console.WriteLine(repository.SearchPolicyById(searchId));
                            break;
                        case 4:
                            Console.Write("Enter Policy ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int updateId))
                            {
                                Console.WriteLine("Invalid Policy ID! Try again.");
                                break;
                            }
                            repository.UpdatePolicy(updateId);
                            break;
                        case 5:
                            Console.Write("Enter Policy ID to Delete: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            repository.DeletePolicy(deleteId);
                            break;
                        case 6:
                            List<Policy> Policiess = repository.ViewActivePolicies();
                            foreach (var item in Policiess)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Invalid Choice! Try again");
                            break;
                    }
                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
