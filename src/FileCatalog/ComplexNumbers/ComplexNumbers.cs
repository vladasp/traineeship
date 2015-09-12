using System;

namespace ComplexNumbers
{
    class ComplexNumbers
    {
        double a;
        double b;
        const string i = "i";
        public ComplexNumbers() { }
        public ComplexNumbers(double value1, double value2)
        {
            a = value1;
            b = value2;
        }
        public void NumToString(double a, double b)
        {
            string stringA = Convert.ToString(a);
            string stringB = Convert.ToString(b);
            Console.Write("Number to string ({0}, {1})", stringA, stringB);
        }
        public void GetMagnitude()
        {
            double result = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine("Magnitude of complex nuber: {0}", Math.Round(result, 2));
        }
        public void Add(double newA, double newB)
        {
            a += newA;
            b += newB;
            if (b > 0)
            {
                Console.WriteLine("New complex number {0}+{1}{2} ", Convert.ToString(a), Convert.ToString(b), i);
            }
            else
            {
                Console.WriteLine("New complex number {0}{1}{2}", Convert.ToString(a) + Convert.ToString(b) + i);
            }
        }
    }
}
