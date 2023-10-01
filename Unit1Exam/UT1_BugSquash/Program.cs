using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            // int nY         COMPILE-TIME ERROR: no semicolon
            int nY;
            int nAnswer;

            // Console.WriteLine(This program calculates x ^ y.);          COMPILE-TIME ERROR: no double quotes
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                // Console.ReadLine();         RUN-TIME ERROR: sNumber is not initialized (error indicator was on line 24)
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));           

            do
            {
                // Console.Write("Enter a positive whole number for y: ");             LOGICAL ERROR: 0 is not positive but is a valid value
                Console.Write("Enter a non-negative whole number for y: ");
                sNumber = Console.ReadLine();
                // } while (int.TryParse(sNumber, out nX));          LOGICAL ERROR: variable should be out nY, not out nX
                //                                                                  loop should be !int.TryParse(sNumber, out nY)
                //                                                                  loop needs to make sure nY is not negative
            } while (!int.TryParse(sNumber, out nY) || nY < 0);

            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            // Console.WriteLine("{nX}^{nY} = {nAnswer}");          LOGICAL ERROR: to print the values of the variables and not what is explicity writted, $ is needed before double quotes
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }


        // int Power(int nBase, int nExponent)          RUN-TIME ERROR: class was not declared as static (error indicator was on line 35)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                // returnVal = 0;           LOGICAL ERROR: base case value should be 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                // nextVal = Power(nBase, nExponent + 1);           LOGICAL ERROR: exponent incremented instead of decremented so base case was never reached
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            // returnVal;           RUN-TIME ERROR: value was not returned (error indicator was on line 42)
            return returnVal;
        }
    }
}

