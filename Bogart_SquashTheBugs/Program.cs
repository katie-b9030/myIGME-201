using System;

namespace Bogart_SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0        Compile-time error: missing semicolon
            int i = 0;
            
            // declare string to hold all numbers
            string allNumbers = null;

            // loop through the numbers 1 through 10
            // for (i = 1; i < 10; ++i)     Compile-time error: loop does not include the number 10
            for (i = 1; i <= 10; ++i)
            {
                    // output explanation of calculation
                    // Console.Write(i + "/" + i - 1 + " = ");      Run-time error: i-1 needs to be in parentheses because otherwise the i becomes a string before the mathematical operation is attempted
                    Console.Write(i + "/" + (i - 1) + " = ");

                try
                {
                    // output the calculation based on the numbers
                    // Console.WriteLine(i / (i - 1));      Run-time error: does not handle attempting to divide by zero        Logical error: does not provide a decimal value for the answer
                    double d = i;
                    int test = (i / (i - 1));
                    Console.WriteLine((d / (d - 1)));
                }
                catch
                {
                    Console.WriteLine("Can't divide by that!");
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // i = i + 1;       Logical error: counter is already incremented in the for loop
            }

            // output all numbers which have been processed
            // Console.WriteLine("These numbers have been processed: " allNumbers);     Compile-time error: "+" sign is needed between the string and allNumbers        Run-time error: allNumbers was defined within the for loop and therefore is inaccessible
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}

