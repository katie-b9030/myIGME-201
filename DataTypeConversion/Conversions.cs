using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversion
{
    static internal partial class Program
    {
        static int MyAdder (int a, int b)
        {
            return 1;
        }

        static double MyAdder (double a, double b)
        {
            return 1;
        }
        static void Main(string[] args)
        {
            double doubleNum = 9999.99;
            float floatNum = 999.9F;
            decimal decimalNum = 1234.5678M;
            long longInt = -12345678;   // Int64 (64-bit)
            ulong ulongInt = 12345678;  // UInt64
            int intNum = -786;          // Int32
            uint uintNum = 786;         // UInt32
            short shortInt = -789;      // Int16
            ushort ushortInt = 789;     // UInt16
            byte byteNum = 254;         // 8-bit unsigned
            sbyte sbyteNum = -123;      // 8-bit signed

            //implicit casting
            longInt = shortInt;
            uintNum = byteNum;

            //explicit casting
            byteNum = (byte)shortInt;

            try
            {
                byteNum = checked((byte)shortInt);
                byteNum = Convert.ToByte(shortInt);

                byteNum = byte.Parse(shortInt.ToString());
                bool bValid = byte.TryParse(shortInt.ToString(), out byteNum);
            }
            catch
            {
                // output message that data wll be lost
                Console.WriteLine("Data was lost!");
            }

            // int/int = int
            doubleNum = (double)longInt / shortInt; // answer will be int unless casted

            shortInt = (short)3.94; // short int
            MyAdder(shortInt, shortInt);
            MyAdder (doubleNum, shortInt);
            MyDivider(byteNum, byteNum);
        }
    }
}
