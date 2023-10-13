using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE12
{

    /* Class: MyClass
     * Author: Katie Bogart
     * Purpose: returns a string
     * Restrictions: None
     */
    public class MyClass
    {
        private string myString;

        /* Method: MyString
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

        /* Method: GetString
         * Purpose: returns the private string in the class
         * Restrictions: None
         */
        public virtual string GetString()
        {
            return myString;
        }
    }

    /* Class: MyDerivedClass
     * Author: Katie Bogart
     * Purpose: returns the string from the base class
     * Restrictions: None
     */
    public class MyDerivedClass : MyClass
    {

        /* Method: GetString
         * Purpose: returns the string in the base class with appended text
         * Restrictions: None
         */
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }

        /* Method: Main
         * Purpose: returns the string in the base class with appended text
         * Restrictions: None
         */
        public static void Main(string[] args)
        {
            MyDerivedClass myDerivedClass = new MyDerivedClass();
            Console.WriteLine(myDerivedClass.GetString());
        }
    }
}
