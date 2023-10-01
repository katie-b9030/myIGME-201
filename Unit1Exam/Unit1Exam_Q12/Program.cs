using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Exam_Q12
{

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: gives a salary raise if the user's name is the same as your name
     * Restrictions: None
     */
    internal class Program
    {

        /* Method: Main
         * Purpose: prompt for user's name
         *          check if user gets a raise
         *          display salary if the user got a raise
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // variable declarations outlined in assignment
            string sName;
            double dSalary = 30000;
            bool bRaise;

            // prompt for user's name
            Console.WriteLine("Please enter your first name: ");
            // store the user's name
            sName = Console.ReadLine();

            // check if the user got a raise
            bRaise = GiveRaise(sName, ref dSalary);

            // if they did, congratulate them
            if (bRaise)
            {
                Console.WriteLine("Congratulations, you got a raise! Your salary is now: " + dSalary);
            }
        }

        /* Method: Main
         * Purpose: if user's name same as your name, give raise
         *          if user's name different than your name, don't give raise
         * Restrictions: None
         */
        static bool GiveRaise(string name, ref double salary)
        {
            if (name.ToLower() == "katie")
            {
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
