using System;

namespace ComplexNumbers
{
    enum Control { A = 1, M, S, E }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Control control = new Control();
            Console.WriteLine("Enter real part of complex number");
            double a = program.ChangConsoleLine();
            Console.WriteLine("Enter imaginary part of complex number");
            double b = program.ChangConsoleLine();
            ComplexNumbers complexNumber = new ComplexNumbers(a, b);

            bool isExit = false;
            while (!isExit)
            {
                string input = Console.ReadLine();
                Enum.TryParse(input, true, out control);
                switch (control)
                {
                    case Control.M:
                        complexNumber.GetMagnitude();
                        break;
                    case Control.S:
                        Console.WriteLine("Complex number to string {0}", complexNumber.ToString());
                        break;
                    case Control.A:
                        Console.WriteLine("Enter added real part of complex number");
                        double addedA = program.ChangConsoleLine();
                        Console.WriteLine("Enter added imaginary part of complex number");
                        double addedB = program.ChangConsoleLine();
                        complexNumber.Add(addedA, addedB);
                        break;
                    case Control.E:
                        isExit = true; break;
                    default: Instuctions(); break;
                }
            }
        }
        public double ChangConsoleLine()
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
            Console.WriteLine("||To magnitude number enter {0},\n||to show number to string enter {1},\n||to add complex number enter {2},\n||to exit enter {3}",
                Control.M.ToString(), Control.S.ToString(), Control.A.ToString(), Control.E.ToString());
        }

    }
}