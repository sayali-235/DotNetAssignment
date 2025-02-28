using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Assignment_Exception.Exception
{
    internal class AccountNotFoundException:ApplicationException
    {
        public AccountNotFoundException(string message):base(message)
        {

        }
    }
}
