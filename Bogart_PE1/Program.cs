using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // test to see if a variable declaration prints the same way as plain text did
            string hello = "Hello World!";
            // tests another string variable to make sure they work the same
            string myName = "Katie Bogart";
            // test to see if a non-string will print the same way it did in Java
            double number = 6.5;

            // all prints succeed, variables print the same way as Java
            Console.WriteLine(hello);
            Console.WriteLine(myName);
            Console.WriteLine(number);
            

            // both prints succeed, C# can print expressions just like Java
            // simple expression prints after the expression is completed
            Console.WriteLine(7 + 7);
            // more complicated math expression follows order of operations, prints when completed
            Console.WriteLine(6 * 7 + 15 / 2);


            // test if explicit casting works the same way as Java
            int num = (int)number;
            // test if implicit casting works the same way as Java
            double sameNum = num;

            // both prints succeed, casting is the same
            Console.WriteLine(num);
            Console.WriteLine(sameNum);


            // tests to see if an if/else statement works the same as in Java
            if (num == sameNum)
            {
                // if this prints, int and double can be considered equal in certain circumstances
                Console.WriteLine(num + " and " +  sameNum + " are the same!");
            }
            else
            {
                // if this prints, int and double are not equal in any circumstancec
                Console.WriteLine(num + " and " + sameNum + " are not the same.");
            }

            // this should print 0-5 in sequence
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(i);
            }

            double d = 0;

            while (d < number)
            {
                Console.WriteLine(d);
                d += 0.5;
            }
        }
    }
}
