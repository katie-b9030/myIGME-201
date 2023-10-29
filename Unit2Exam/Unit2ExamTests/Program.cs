using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2ExamTests
{
    public sealed class Circus
    {
        public string name;
    }

    public class MyClass
    {
        public int myInt;

        public MyClass(int nVal)
        {
            this.myInt += nVal;
        }
    }

    public class MyDerivedClass : MyClass
    {
        public MyDerivedClass(int nVal) : base(nVal)
        {
            this.myInt = (this.myInt + 2) * 4;
        }
    }


    static class Program
    {
        static void Main(string[] args)
        {

            SortedList<string, DateTime> friendBirthdays = new SortedList<string, DateTime>();
            foreach (string friend in friendBirthdays.Keys)
            {
                DateTime birthdate = friendBirthdays[friend];

                Console.WriteLine(friend + "’s birthday is on " + birthdate.ToString("MM/dd/yyyy"));
            }

        }
    }

}
