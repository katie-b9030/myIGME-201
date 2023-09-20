using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_MoreAboutVariables_Q5
{
    /* Class: Program
     * Author: Katie Bogart
     * Purpose: store x, y, and z values in a 3d array for the formula z = 3y^2 + 2x -1 for the given intervals
     * Restrictions: None
     */
    static internal class Program
    {
        /* Method: Main
         * Purpose: create a 2D array to hold x, y, and z
         *          calculate and store the values of z
         *          print the values of z
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // create an array to store the values
            double[,] xyzVals = new double[3, 21*31];
            int xCols = 0;
            int yCols = 0;
            int zCols = 0;

            // input the values of x
            for (double x = -1; x <= 1; x += 0.1)
            {
                xyzVals[0, xCols] = x;
                xCols++;
            }

            // input the values of y
            for (double y = 1; y <= 4; y += 0.1)
            {
                xyzVals[1, yCols] = y;
                yCols++;
            }

            // calculate and store the values of z
            for (int x = 0; x < xCols; x++)
            {
                for (int y = 0; y < yCols; y++)
                {
                    xyzVals[2, zCols] = (3*Math.Pow(xyzVals[1,y], 2) + 2*(xyzVals[0, x]) - 1);
                }
            }

            // print the array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < zCols; j++)
                {
                    Console.WriteLine("Here is your array: ");
                    Console.WriteLine(xyzVals[i, j]);
                }
            }
        }
    }
}
