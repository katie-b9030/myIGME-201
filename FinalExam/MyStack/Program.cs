using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: run methods of MyStack
     * Restrictions: None
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: Create MyStack
         *          Push to MyStack
         *          Pop from MyStack
         *          Peek at MyStack
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            MyStack myStack = new MyStack();

            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            Console.WriteLine(myStack.Pop());

            Console.WriteLine(myStack.Peek());
        }
    }

    /* Class: MyStack
     * Author: Katie Bogart
     * Purpose: use a list to simulate a Stack
     * Restrictions: None
     */
    public class MyStack
    {
        // list to simulate stack
        private List<int> nList = new List<int>();

        /* Method: Push
         * Purpose: add a value to the end of the list
         * Restrictions: None
         */
        public void Push(int n)
        {
            nList.Add(n);
        }

        /* Method: Pop
         * Purpose: remove a value from the end of the list
         * Restrictions: None
         */
        public int Pop()
        {
            int popped = nList[nList.Count - 1];
            nList.RemoveAt(nList.Count - 1);
            return popped;
        }

        /* Method: Peek
         * Purpose: see the value at the end of the list
         * Restrictions: None
         */
        public int Peek()
        {
            return nList[nList.Count - 1];
        }
    }
}
