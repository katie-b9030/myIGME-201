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

            (double, double, double) wxyVals;
            SortedList<(double, double, double), double> equationVals = new SortedList<(double, double, double), double>();
            double dW, dX, dY, dZ;
            for (dW = -2; dW <= 0; dW += 0.2)
            {
                dW = Math.Round(dW, 1);
                for (dX = -1; dX <= 1; dX += 0.1)
                {
                    dX = Math.Round(dX, 1);
                    for (dY = 0; dY <= 4; dY += 0.1)
                    {
                        dY = Math.Round(dY, 1);
                        wxyVals = (dW, dX, dY);

                        dZ = 4 * dY * dY * dY + 2 * dX * dX - 8 * dW + 7;
                        dZ = Math.Round(dZ, 3);
                        equationVals.Add(wxyVals, dZ);

                    }
                }
            }
        }
    }

}
