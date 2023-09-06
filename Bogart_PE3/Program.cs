using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE3
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: calculation of a product using int inputs
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: set a total value to 1
         *          ask the user for ints 4 times
         *          calculate and print the product
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // set the total to 1 so that the product will appear
            int nTotal = 1;
            // cycle through the process of asking for an int 4 times and multiplies the product by it
            for (int i = 0; i<4; i++)
            {
                // promt the user for an integer
                Console.WriteLine("Please enter an integer: ");
                // increases the product by the current integer value
                nTotal = nTotal * Convert.ToInt32(Console.ReadLine());
            }
            // display the product
            Console.WriteLine("Your total product is " +  nTotal + "!");

        }
    }
}
