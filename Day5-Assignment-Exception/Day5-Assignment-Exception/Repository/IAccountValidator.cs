using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Assignment_Exception.Repository
{
    internal interface IAccountValidator
    {
        void ValidateAccount(string accountNo);
    }
}
