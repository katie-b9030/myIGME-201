using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueue
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: run methods of MyQueue
     * Restrictions: None
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: Create MyQueue
         *          Enqueue to MyQueue
         *          Dequeue from MyQueue
         *          Peek at MyQueue
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            MyQueue myQueue = new MyQueue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            Console.WriteLine(myQueue.Dequeue());

            Console.WriteLine(myQueue.Peek());
        }
    }

    /* Class: MyQueue
     * Author: Katie Bogart
     * Purpose: use a list to simulate a Stack
     * Restrictions: None
     */
    public class MyQueue
    {
        // list to simulate stack
        private List<int> nList = new List<int>();

        /* Method: Enqueue
         * Purpose: add a value to the end of the list
         * Restrictions: None
         */
        public void Enqueue(int n)
        {
            nList.Add(n);
        }

        /* Method: Dequeue
         * Purpose: remove a value from the beginning of the list
         * Restrictions: None
         */
        public int Dequeue()
        {
            int popped = nList[0];
            nList.RemoveAt(0);
            return popped;
        }

        /* Method: Peek
         * Purpose: see the value at the beginning of the list
         * Restrictions: None
         */
        public int Peek()
        {
            return nList[0];
        }
    }
}
