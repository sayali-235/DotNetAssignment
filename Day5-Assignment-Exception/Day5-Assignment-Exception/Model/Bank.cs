using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day5_Assignment_Exception.Exception;
using Day5_Assignment_Exception.Repository;

namespace Day5_Assignment_Exception.Model
{
    internal class Bank : IAccountValidator
    {
        List<(string AccountNo,string AccountHolder)>accounts=new List<(string,string)>
        {
            ("12345","Sayali"),
            ("67890","Neha"),
            ("23456","pratik"),
            ("34567","yash")
        };
        public void ValidateAccount(string accountNo)
        {
            try
            {
                var account=accounts.Find(acc=>acc.AccountNo == accountNo); 
                if(account.AccountNo==null)
                {
                    throw new AccountNotFoundException("Error: Account Number does not exist");
                }
                Console.WriteLine($"Account Found:{account.AccountHolder}");
            }   
            catch(AccountNotFoundException aex)

            {
                Console.WriteLine(aex.Message);
            }
        }
    }
}
