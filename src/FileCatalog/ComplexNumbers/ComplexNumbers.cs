using System;

namespace ComplexNumbers
{
    class ComplexNumbers
    {
        double a;
        double b;
        const string i = "i";
        public ComplexNumbers() { }
        public ComplexNumbers(double realPart, double imaginaryPart)
        {
            a = realPart;
            b = imaginaryPart;
        }
        public override string ToString()
        {
            return "(" + a.ToString() + "; " + b.ToString() + ")";
        }
        public void GetMagnitude()
        {
            double result = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine("Magnitude of complex nuber: {0}", Math.Round(result, 2));
        }
        public void Add(double addedA, double addedB)
        {
            a += addedA;
            b += addedB;
            if (b > 0)
            {
                Console.WriteLine("New complex number {0}+{1}{2}", a.ToString(), b.ToString(), i);
            }
            else
            {
                Console.WriteLine("New complex number {0}{1}{2}", a.ToString(), b.ToString(), i);
            }
        }
    }
}