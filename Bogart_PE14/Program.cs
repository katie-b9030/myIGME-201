using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogart_PE14
{

    /* Interface: MyInterface
     * Author: Katie Bogart
     * Purpose: define MyMethod
     * Restrictions: None
     */
    public interface MyInterface
    {
        void InterfaceMethod();
    }

    /* Class: MyClass
     * Author: Katie Bogart
     * Purpose: inherit MyInterface
     * Restrictions: None
     */
    public class MyClass : MyInterface
    {
        /* Method: InterfaceMethod
         * Purpose: print "this is my first method"
         * Restrictions: None
         */
        public void InterfaceMethod()
        {
            Console.WriteLine("This is my first method");
        }
    }

    /* Class: MyOtherClass
     * Author: Katie Bogart
     * Purpose: inherit MyInterface
     * Restrictions: None
     */
    public class MyOtherClass : MyInterface
    {
        /* Method: InterfaceMethod
         * Purpose: print "this is my second method"
         * Restrictions: None
         */
        public void InterfaceMethod()
        {
            Console.WriteLine("This is my second method");
        }
    }

    /* Class: Program
     * Author: Katie Bogart
     * Purpose: Define MyMethod
     * Restrictions: None
     */
    public class Program
    {
        /* Method: MyMethod
         * Purpose: check if it is of type MyClass or MyOtherClass
         *          cast to type
         *          call InterfaceMethod
         * Restrictions: None
         */
        public static void MyMethod(object myObject)
        {
            if (myObject.GetType() == typeof(MyClass))
            {
                MyClass myClass = (MyClass)myObject;
                myClass.InterfaceMethod();
            }
            else if (myObject.GetType() == typeof(MyOtherClass))
            {
                MyOtherClass otherClass = (MyOtherClass)myObject;
                otherClass.InterfaceMethod();
            }
        }

        /* Method: Main
         * Purpose: create objects of MyClass and MyOtherClass
         *          call MyMethod with each object
         * Restrictions: None
         */
        public static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyOtherClass myOtherClass = new MyOtherClass();

            MyMethod(myClass);
            MyMethod(myOtherClass);
        }
    }

}