using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamQ3
{
    enum EVertices
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet,
        grey
    }

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    internal class Program
    {
        static int[,] digraphWeights = new int[,]
        {        /*  red  orange  yellow   green   blue   indigo  violet  grey */
            /*red*/{ -1,    -1,     -1,     -1,     -1,      1,     -1,      5 },
         /*orange*/{ -1,    -1,     -1,     -1,     -1,     -1,      1,     -1 },
         /*yellow*/{ -1,    -1,     -1,      6,     -1,     -1,     -1,     -1 },
          /*green*/{ -1,    -1,     -1,     -1,     -1,     -1,     -1,     -1 },
           /*blue*/{ -1,    -1,     -1,     -1,     -1,      1,     -1,      0 },
         /*indigo*/{ -1,    -1,      8,     -1,      1,     -1,     -1,     -1 },
         /*violet*/{ -1,    -1,      1,     -1,     -1,     -1,     -1,     -1 },
           /*grey*/{ -1,     1,     -1,     -1,      0,     -1,     -1,     -1 },
        };

        /* Method: Main
         * Purpose: 
         * Restrictions: None
         */
        static void Main(string[] args)
        {

        }
    }
}
