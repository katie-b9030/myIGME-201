using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE12
{

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: 
     * Restrictions: None
     */
    static internal class Program
    {

        /* Method: Main
         * Purpose: 
         * Restrictions: None
         */
        static void Main(string[] args)
        {

        }
    }

    /* Class: MyClass
     * Author: Katie Bogart
     * Purpose: returns a string
     * Restrictions: None
     */
    public class MyClass
    {
        private string myString;

        /* Method: Main
         * Purpose: write-only method
         *          sets the value of mystring to the user given value
         * Restrictions: None
         */
        public string MyString
        {
            set
            {
                myString = value;
            }
        }

        /* Method: Main
         * Purpose: returns the private string in the class
         * Restrictions: None
         */
        public virtual string GetString()
        {
            return myString;
        }
    }
}
