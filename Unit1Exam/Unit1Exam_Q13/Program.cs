using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Exam_Q13
{

    // employee struct that stores employee's name and salary
    struct Employee
    {
        public string sName;
        public double dSalary;

        // return employee's name
        public string SName
        {
            get 
            {
                return sName;
            }
        }

        // return or modify employee's salary
        public double DSalary
        {
            get 
            {
                return dSalary;
            }
            set 
            {
                dSalary += value;
            }
        }

        // create an employee with the given name
        public Employee(string name)
        {
            sName = name;
            dSalary = 30000;
        }
    }

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
            Employee emp;
            bool bRaise;

            // prompt for user's name
            Console.WriteLine("Please enter your first name: ");
            // store the user's name
            emp = new Employee(Console.ReadLine());

            // check if the user got a raise
            bRaise = GiveRaise(ref emp);

            // if they did, congratulate them
            if (bRaise)
            {
                Console.WriteLine("Congratulations, you got a raise! Your salary is now: " + emp.dSalary);
            }
        }

        /* Method: GiveRaise
         * Purpose: if user's name same as your name, give raise
         *          if user's name different than your name, don't give raise
         * Restrictions: None
         */
        static bool GiveRaise(ref Employee employee)
        {
            // check if user's name is your name
            if (employee.sName.ToLower() == "katie")
            {
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
