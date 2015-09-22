using System;
using System.Text;
using System.Linq;

namespace Chapter14
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exercise6, Exit }
    class Program
    {
        static void Main(string[] args)
        {
            UserControl usercontrol = new UserControl();
            bool isExit = false;
            string input;
            Instruction();
            while (!isExit)
            {
                input = Console.ReadLine();
                Enum.TryParse(input, true, out usercontrol);
                switch (usercontrol)
                {
                    case UserControl.Exercise1:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise1);
                        Exercise1 exercise1 = new Exercise1();
                        exercise1.Show();
                        break;
                    case UserControl.Exercise2:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise2);
                        Exercise2 exercise2 = new Exercise2();
                        exercise2.Show();
                        break;
                    case UserControl.Exercise3:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise3);
                        Exercise3 exercise3 = new Exercise3();
                        exercise3.Show();
                        break;
                    case UserControl.Exercise4:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise4);
                        Exercise4 exercise4 = new Exercise4();
                        exercise4.Show();
                        break;
                    case UserControl.Exercise5:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise5);
                        Exercise5 exercise5 = new Exercise5();
                        exercise5.Show();
                        break;
                    case UserControl.Exercise6:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise6);
                        Exercise6 exercise6 = new Exercise6();
                        exercise6.Show();
                        Console.WriteLine("Enter any sentence (with multiple spaces)");
                        string inputString = Console.ReadLine();
                        Console.WriteLine(ToAcronym(inputString));
                        break;
                    case UserControl.Exit: isExit = true; break;
                    default: Instruction(); break;
                }
            }
        }
        static void Instruction()
        {
            Console.WriteLine("|||For show solve of exercise from 1 to {0} enter relevant number,\n|||to exit enter {1}",
                Enum.GetNames(typeof(UserControl)).Length - 1, Enum.GetNames(typeof(UserControl)).Length);
            return;
        }
        public static string ToAcronym(string inputString)
        {
            return inputString.Trim().Split(' ')
                .Aggregate<string, string>("", (a, b) => a + (b.Length > 0 ? b.ToUpper()[0].ToString() : ""));
        }
    }
}
