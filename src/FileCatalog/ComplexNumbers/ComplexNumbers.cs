using System;

namespace ComplexNumbers
{
    class ComplexNumbers
    {
        double a;
        string bi;
        public ComplexNumbers() { }
        public ComplexNumbers(double value)
        {
            a = value;
        }
        public ComplexNumbers(string value)
        {
            bi = value;
        }
        public ComplexNumbers(double value1, string value2)
        {
            a = value1;
            bi = value2;
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
