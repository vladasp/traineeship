using System;
using System.Collections.Generic;

namespace Chapter6
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exit }
    class Program
    {
        static void Main(string[] args)
        {
            throw new Exception();
            bool isExit = false;
            int input;
            const int firstControl = (int)UserControl.Exercise1;
            const int secondControl = (int)UserControl.Exercise2;
            const int thirdControl = (int)UserControl.Exercise3;
            const int fourthControl = (int)UserControl.Exercise4;
            const int fifthControl = (int)UserControl.Exercise5;
            const int exitControl = (int)UserControl.Exit;
            while (!isExit)
            {
                Console.WriteLine("|||For show solve of exercise from 1 to 5 enter relevant number,\n|||to exit enter 6");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case firstControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise1);
                            Exercise1 exercise1 = new Exercise1();
                            exercise1.Show();
                            break;
                        }
                    case secondControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise2);
                            Exercise2 exercise2 = new Exercise2();
                            args[0] = "First argument";
                            args[1] = "2";
                            exercise2.Show(args[0], args[1]);
                            break;
                        }
                    case thirdControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise3);
                            Exercise3 exercise3 = new Exercise3();
                            SetChangeLine setChangeLine;
                            exercise3.Show();
                            setChangeLine = exercise3.SetConsoleReadLine;
                            Console.WriteLine("Enter your name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter your password");
                            string password = Console.ReadLine();
                            Console.WriteLine("Yours parameters to enter: {0}\n ", setChangeLine(name, password));
                            break;
                        }
                    case fourthControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise4);
                            Exercise4 exercise4 = new Exercise4();
                            exercise4.Show();
                            Order order1;
                            order1.itemName = "Notebook";
                            order1.unitCost = 500;
                            order1.unitCount = 3;
                            Console.WriteLine("Total sum {0} of units \"{1}\".\n ", order1.TotalSum(), order1.itemName);
                            break;
                        }
                    case fifthControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise5);
                            Exercise5 exercise5 = new Exercise5();
                            exercise5.Show();
                            Order order2;
                            order2.itemName = "Notebook";
                            order2.unitCost = 500;
                            order2.unitCount = 3;
                            order2.Information();
                            break;
                        }
                    case exitControl:
                        {
                            break;
                        }
                    default: Instruction(); break;
                }
            }
        }
        static void Instruction()
        {
            Console.WriteLine("|||For show solve of exercise from 1 to 5 enter relevant number,\n|||to exit enter 6");
            return;
        }
    }
}
