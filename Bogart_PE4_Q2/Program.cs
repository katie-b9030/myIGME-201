using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE4_Q2
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: evaluates if only one of the two variables is greater than 10
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: ask the user for 2 ints
         *          displays them if one is greater than 10 and one is less than 10
         *          reject input if conditions are not satisfied and ask for two new numbers
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // initialize variables
            int? var1 = null;
            int? var2 = null;
            bool bOnlyOneGreater = false;
            //loop until input satisfies conditions
            while(!bOnlyOneGreater)
            {
                // continue until variable has a valid input
                while (var1 == null)
                {
                    // request an input from user
                    Console.WriteLine("Please enter an integer: ");
                    // assign that input to a variable
                    try
                    {
                        // assign user-entered value to variable
                        var1 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        // tell user that input is invalid
                        Console.WriteLine("Invalid Input!");
                    }
                }
                // repeat with second number
                // continue until variable has a valid input
                while (var2 == null)
                {
                    // request an input from user
                    Console.WriteLine("Please enter an integer: ");
                    // assign that input to a variable
                    try
                    {
                        // assign user-entered value to variable
                        var2 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        // tell user that input is invalid
                        Console.WriteLine("Invalid Input!");
                    }
                }
                // check if only one variable is greater than 10
                bOnlyOneGreater = ((var1 > 10) ^ (var2 > 10));
                // if not, reject the variables and ask for two new ones (restart loop)
                if (!bOnlyOneGreater)
                {
                    Console.WriteLine("Your entries did not satisfy the desired conditions!");
                    var1 = null;
                    var2 = null;
                }
                
            }
            // if yes, display the variables
            Console.WriteLine("Your variables were: " + var1 + ", " + var2 + ". Only one is greater than 10!");
        }
    }
}
