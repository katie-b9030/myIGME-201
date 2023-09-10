using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            {
                int[] myIntArray = { 5, 6, 7, 8, 9, 23, 123, -90 };
                myIntArray[0];
            }

            {
                int[] myIntArray = new int[8] { 5, 6, 7, 8, 9, 23, 123, -90 };
            }

            {
                int[] myIntArray = new int[8];
                myIntArray[0] = 5;
                myIntArray[1] = 6;
                myIntArray[2] = 7;
                myIntArray[3] = 8;
                myIntArray[4] = 9;
                myIntArray[5] = 23;
                myIntArray[6] = 123;
                myIntArray[7] = -90;

                int[] myIntArray2;
                myIntArray2 = myIntArray;

                myIntArray2[0] = 55;

                myIntArray = null;
                myIntArray2 = null;
            }

            {
                int arraySize = 5;
                int[] myIntArray = new int[arraySize];
            }

            {
                int[] funcVal = new int[21];
                int x = 0;
                int xCntr = 0;
                int y = 0;
                // look at class code for remaining parts of this section
                funcVal[x] = y;
                int[] xArray = new int[21];

                for (x = -10; x <=10; ++x, ++xCntr)
                {
                    y = 2 * (int)Math.Pow(x, 2) + 3;

                    funcVal[xCntr] = y;
                    funcVal[y] = x;
                }
            }

            {
                // LOOK AT CLASS CODE
            }

            {
                // LOOK AT CLASS CODE
            }
        }
    }
}
