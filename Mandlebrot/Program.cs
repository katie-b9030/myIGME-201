using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            // initialize values for the start and end imag coordinates
            double? startCoordImag = null;
            double? endCoordImag = null;
            // initialize values for the start and end real coordinates
            double? startCoordReal = null;
            double? endCoordReal = null;
            // initialize values for the imag and real increaments
            double imagIncrement, realIncrement;
            // prompt the user for start and end imag coordinates
            while (startCoordImag == null)
            {
                Console.WriteLine("Please enter a double for the starting coordinate (suggested default value: 1.2): ");
                try
                {
                    startCoordImag = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Coordinate was invalid!");
                }
            }
            while (endCoordImag == null)
            {
                Console.WriteLine("Please enter a double for the ending coordinate that is less than your starting coordinate (suggested default value: -1.2): ");
                try
                {
                    endCoordImag = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Coordinate was invalid!");
                }
                if (endCoordImag >= startCoordImag)
                {
                    Console.WriteLine("Your ending coordinate was not less than your starting coordinate!");
                    endCoordImag = null;
                }
            }
            // calculate imag increment
            imagIncrement = Math.Abs(((double)startCoordImag - (double)endCoordImag) / 48);
            // prompt the user for start and end real coordinates
            while (startCoordReal == null)
            {
                Console.WriteLine("Please enter a double for the starting coordinate (suggested default value: -0.6): ");
                try
                {
                    startCoordReal = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Coordinate was invalid!");
                }
            }
            while (endCoordReal == null)
            {
                Console.WriteLine("Please enter a double for the ending coordinate that is more than your starting coordinate (suggested default value: 1.77): ");
                try
                {
                    endCoordReal = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Coordinate was invalid!");
                }
                if (endCoordReal <= startCoordReal)
                {
                    Console.WriteLine("Your ending coordinate was not less than your starting coordinate!");
                    endCoordReal = null;
                }
            }
            // calculate real increment
            realIncrement = Math.Abs(((double)startCoordReal - (double)endCoordReal) / 80);

            for (imagCoord = (double)startCoordImag; imagCoord >= (double)endCoordImag; imagCoord -= imagIncrement)
            {
                for (realCoord = (double)startCoordReal; realCoord <= (double)endCoordReal; realCoord += realIncrement)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}

