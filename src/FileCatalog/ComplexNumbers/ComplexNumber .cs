using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    public class ComplexNumber
    {
        static double a;
        static string b;
        static string complexNumber;

        public ComplexNumber(double valueReal)
        {
            a = valueReal;
        }
        public ComplexNumber(string valueImaginary)
        {
            b = valueImaginary;
        }

        public static void NumberToString()
        {
            complexNumber = Convert.ToString(a) + b;
            return;
        }

        public static void GetMagnitude()
        {
            double doubleB = Convert.ToDouble(b.Remove(0, 1));
            double numberMagnitude = Math.Sqrt(Math.Pow(a, 2)+ Math.Pow(doubleB, 2));
            return;
        }
        public static void Add(double addA, string addB)
        {
            a = a + addA;
            double doubleB = Convert.ToDouble(b.Remove(0, 1)); ;
            double doubleAddB = Convert.ToDouble(addB.Remove(0, 1)); ;
            doubleB = doubleB + doubleAddB;
            b = Convert.ToString(doubleB).Insert(0, "i");
            return;
        }
    }
}
