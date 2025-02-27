using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_question2.Model
{
    internal class User
    {
        public static int user = 0;
        public User()
        {
            user++;
        }
        public int CountDisplay()
        {
            //Console.WriteLine($"Total User Logged In: {user}");
            return user;
        }
    }
}
