using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: use Vehicle library to define a function that uses IPassengerCarrier objects
     * Restrictions: None
     */
    internal class Program
    {

        /* Method: Main
         * Purpose: create two vehicle objects
         *          call add passenger on each object
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // define vehicles, one that inherits IPassengerCarrier, one that doesn't
            PassengerTrain passengerTrain = new PassengerTrain();
            FreightTrain freightTrain = new FreightTrain();

            // pass object that inherited IPassengerCarrier interface
            AddPassenger(passengerTrain);

            // pass object that didn't inherit IPassengerCarrier interface
            AddPassenger(freightTrain);
        }


        /* Method: AddPassenger
         * Purpose: call vehicle's inherited load passenger method
         *          print the object using .ToString()
         * Restrictions: None
         */
        public static void AddPassenger(IPassengerCarrier carrier)
        {
            // call the inherited load passenger method
            carrier.LoadPassenger();
            // print the object as a string
            Console.WriteLine(carrier.ToString());
        }
    }
}
