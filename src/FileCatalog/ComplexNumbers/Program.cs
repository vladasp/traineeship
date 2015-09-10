using System;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Enter a");
            double a = program.ChangedLine();
            Console.WriteLine("Enter b");
            double b = program.ChangedLine();
            ComplexNumbers complexNumber = new ComplexNumbers(a, b);
            complexNumber.NumToString(a, b);
            const string addControl = "A";
            const string magnitudeControl = "M";
            const string stringControl = "S";
            const string exitControl = "E";

            bool isExit = false;
            string input;

            while (!isExit)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case magnitudeControl:
                        complexNumber.GetMagnitude();
                        break;
                    case stringControl:
                        complexNumber.NumToString(a, b);
                        break;
                    case addControl:
                        Console.WriteLine("Enter real part of complex number");
                        double a1 = program.ChangedLine();
                        Console.WriteLine("Enter imaginary part of complex number");
                        double b1 = program.ChangedLine();
                        complexNumber.Add(a1, b1);
                        break;
                    case exitControl:
                        isExit = true; break;
                    default: Instuctions(); break;
                }
            }
        }
        public double ChangedLine()
        {
            string parameterSet;
            double parameterGet = 0;
            double number;
            bool canPars = false;

            do
            {
                parameterSet = Console.ReadLine();
                if (double.TryParse(parameterSet, out number))
                {
                    parameterGet = Convert.ToDouble(parameterSet);
                    canPars = true;
                }
                else
                {
                    Console.WriteLine("Only numbers");
                    canPars = false;
                }
            }
            while (!canPars);
            return parameterGet;
        }
        static void Instuctions()
        {
            Console.WriteLine("||To magnitude number enter 'M',\n||to show number to string enter 'S',\n||to add complex number enter 'A',\n||to exit enter 'E'");
        }

    }
}
