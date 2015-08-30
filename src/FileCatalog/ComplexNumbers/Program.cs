using System;

namespace ComplexNumbers
{
    class Program
    {
        enum Command { M = 1, S = 2, A = 3, E = 4 }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Enter a");
            double a = program.ChangedLine();
            Console.WriteLine("Enter b");
            string b = Convert.ToString(program.ChangedLine()) + "i";
            ComplexNumbers complexNumber = new ComplexNumbers(a, b);
            complexNumber.NumToString();

            bool isExit = false;
            string input;

            while (!isExit)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "M":
                        {
                            complexNumber.GetMagnitude();
                            break;
                        }
                    case "S":
                        {
                            complexNumber.NumToString();
                            break;
                        }
                    case "A":
                        {
                            Console.WriteLine("Enter real part of complex number");
                            double a1 = program.ChangedLine();
                            Console.WriteLine("Enter imaginary part of complex number");
                            double b1 = program.ChangedLine();
                            string bi1 = Convert.ToString(b1) + "i";
                            complexNumber.Add(a1, bi1);
                            break;
                        }
                    case "E":
                        {
                            isExit = true; break;
                        }
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
