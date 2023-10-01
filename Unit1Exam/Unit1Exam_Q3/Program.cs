using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Exam_Q3
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

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: delegate function that impersonates Math.Round(double, int)
     * Restrictions: None
     */
    internal class Program
    {
        // define delegate method with the same signature as Math.Round(double, int)
        delegate double Round(double dNum, int nPlaces);

        /* Method: Main
         * Purpose: take in a double from user
         *          take in an int from user
         *          use delegate to round double to int number of decimal places
         *          print the rounded value
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // create a rounding function
            Round round;
            // initialize variables
            string sRoundingNumber = "";
            double dRoundingNumber = 0;
            string sRoundingPlaces = "";
            int nRoundingPlaces = 0;
            bool bValid = false;
            double roundedValue;

            // set the delegate to impersonate Math.Round
            round = Math.Round;

            // prompt the user for the number to round until it's a valid
            while (!bValid)
            {
                Console.Write("Please enter a decimal number: ");
                sRoundingNumber = Console.ReadLine();
                try
                {
                    dRoundingNumber = double.Parse(sRoundingNumber);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            // reset bValid to false to run the next loop
            bValid = false;

            // prompt the user for the number of places to round to until it's a valid
            while (!bValid)
            {
                Console.Write("Please enter a number of places to round the decimal to: ");
                sRoundingPlaces = Console.ReadLine();
                try
                {
                    nRoundingPlaces = int.Parse(sRoundingPlaces);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            // set the delegate to be the rounded value
            roundedValue = round(dRoundingNumber, nRoundingPlaces);

            // print the rounded value
            Console.WriteLine($"Your number {sRoundingNumber} rounded to {sRoundingPlaces} place(s) is: {roundedValue}");


        }
    }
}
