using ColorsAndNumbers.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsAndNumbers
{
    namespace Colors
    {
        // a custom list of colors can now be access
        enum EColors
        {
            red,
            orange,
            yellow,
            green,
            blue,
            indigo,
            violet
        }
    }

    namespace Numbers
    {
        enum ENumbers
        {
            one,
            two,
            three,
            four,
            five,
            six,
            seven
        }
    }
}

namespace FavoriteColorAndNumber
{
    // perfectly fine as a using statement
    using ColorsAndNumbers.Colors;
    // makes the namespace more explicit and easier to track in the code
    using ColorsAlias = ColorsAndNumbers.Colors;

    // for now, every class should have a static keyword
    /* Class: Program
     * Author: Katie Bogart
     */
    static internal class Program
    {
        // methods consist of the static keyword a return type, a method name, and a list of paramaters
        static void WriteMyVar(ref int nParameter)
        {
            Console.WriteLine(nParameter);
            
            // without "ref," it's a copy of the original data, not pointing to it (looking through a mirror)
            nParameter = 42;

        }

        static void Main(string[] args)
        {

            // doesn't need a namespace prefix because using statement is in this namespace
            ColorsAlias.EColors eColors;

            // uses the system namespace
            Console.WriteLine("");

            int myInt = 0;
            int anotherInt = 2;
            string sFavColor = "";
            string sFavNumber = "";
            bool bValid = false;
            int? nFavNumber = null;

            anotherInt = myInt;

            // ref keyword makes the method point to the original data (looking directly at it)
            WriteMyVar(ref myInt);



            // APPLICATION

            // prompt the user for their favorite color
            Console.Write("Hello! please enter your favorite color: ");

            // read the favorite color provided and store it in a variable
            sFavColor = Console.ReadLine();

            // prompt the user for their favorite number
            Console.Write("Now please enter your favorite number: ");

            // read the favorite number provided and store it in a variable
            sFavNumber = Console.ReadLine();
            while(bValid == false)
            {
                try
                {
                    nFavNumber = Convert.ToInt32(sFavNumber);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                }

            do
            {
                sFavNumber = Console.ReadLine();
                try
                {
                    nFavNumber = Convert.ToInt32(sFavNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer: ");
                }
            } while (nFavNumber == null);

            do
            {
                sFavNumber = Console.ReadLine();
                try
                {
                    nFavNumber = int.Parse(sFavNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer: ");
                }
            } while (nFavNumber == null);

            int nFavNumberInt = 0;
            do
            {
                sFavNumber = Console.ReadLine();
                bValid = int.TryParse(sFavNumber, out nFavNumberInt);

                if (!bValid)
                {
                    Console.WriteLine("Please enter an integer: ");
                }
                
            } while (nFavNumber == null);

            nFavNumber = nFavNumberInt;

            // set favorite color to lower case
            // this won't change the string contents
            sFavColor.ToLower();

            // change the console output color to match their favorite color
            switch (sFavColor.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
             }

            int y = 0;
            int x = 5;

            y = ++x;    // y = 6;  x = 6;
            y = x++;    // y = 5;  x = 6;

            // a loop that outputs their favorite color their favorite number of times
            for (int i = 0; i < nFavNumber; i++)
            {
                Console.WriteLine("Your favorite color is " + sFavColor + "!");
                Console.WriteLine($"Your favorite color is {sFavColor} !");
                Console.WriteLine("Your {0} favorite color is {0}{1}", "most", sFavColor, "!");

                // Console.WriteLine("5 + 5 = " + (x + x));
            }
        }
    }
}
