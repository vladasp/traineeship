using System;

namespace ComplexNumbers
{
    class ComplexNumbers
    {
        double a;
        string b;
        const string i = "i";
        public ComplexNumbers() { }
        public ComplexNumbers(double realPart, string imaginaryPart)
        {
            a = realPart;
            b = imaginaryPart;
        }
        public void NumToString()
        {
            string ai = Convert.ToString(a);
            Console.Write("Number to string ({0}, {1})", ai, bi);
            return;
        }
        public void GetMagnitude()
        {
            double b = Convert.ToDouble(bi.Remove(bi.Length - 1, 1));
            double result = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine("Magnitude of complex nuber: {0}", Math.Round(result, 2));
            return;
        }
        public void Add(double a2, string bi2)
        {
            a = a + a2;
            double b = Convert.ToDouble(bi.Remove(bi.Length - 1, 1)) + Convert.ToDouble(bi2.Remove(bi2.Length - 1, 1));
            bi = Convert.ToString(b) + "i";
            Console.WriteLine("New complex number {0}", Convert.ToString(a) + bi);
        }
    }
}
