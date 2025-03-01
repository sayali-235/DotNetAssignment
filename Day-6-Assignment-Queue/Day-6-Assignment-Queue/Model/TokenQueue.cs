using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6_Assignment_Queue.Model
{
    internal class TokenQueue
    {
        Queue<string>tokenQueue=new Queue<string>();
        public TokenQueue()
        {
            tokenQueue = new Queue<string>();
        }
        public void Enqueue(string customer)
        {
            tokenQueue.Enqueue(customer);
            Console.WriteLine($"{customer} has taken a  token.");
        }
        public string Dequeue()
        {
            if(!IsEmpty())
            {
                string servedCustomer = tokenQueue.Dequeue();
                Console.WriteLine($"{servedCustomer} is being served");
                return servedCustomer;
 
            }
            else
            {
                Console.WriteLine("NO Customer in the queue");
                return null;
            }
        }

        public string Peek()
        {
            if (!IsEmpty())
            {
                return tokenQueue.Peek();
            }
            else
            {
                Console.WriteLine("No Customer in the queue");
                return null;
            }
        }

        public bool IsEmpty()
        {
            return tokenQueue.Count == 0;
        }

        public void DisplayQueue()
        {
            if(!IsEmpty())
            {
                Console.WriteLine("Customer in queue"+ string.Join(",",tokenQueue));
            }
            else
            {
                Console.WriteLine("No customer in the queue");
            }
        }
    }
}
