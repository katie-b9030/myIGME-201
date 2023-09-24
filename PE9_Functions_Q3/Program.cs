using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9_Functions_Q3
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2); <summary>
    /// delegate steps
    /// 

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: delegate function that impersonates Console.ReadLine()
     * Restrictions: None
     */
    internal class Program
    {
        // define delegate method with the same signature as Console.ReadLine()
        delegate string LineRead();

        /* Method: Main
         * Purpose: take in a line from a user
         *          process that line in a delegate function
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // create the line that will be read
            LineRead readLine;
            string userInput;

            // set the line read to be the line the user entered
            readLine = Console.ReadLine;

            // prompt the user for input
            Console.Write("Please enter something: ");

            // set the string to print using the delegate
            userInput = readLine();

            // print the line read
            Console.WriteLine("You entered: " + userInput);


        }
    }
}
