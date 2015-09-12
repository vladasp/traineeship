using System;
using System.Collections.Generic;

namespace Chapter5
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exercise6, Exercise7, Exit }
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            int input;
            const int firstControl = (int)UserControl.Exercise1;
            const int secondControl = (int)UserControl.Exercise2;
            const int thirdControl = (int)UserControl.Exercise3;
            const int fourthControl = (int)UserControl.Exercise4;
            const int fifthControl = (int)UserControl.Exercise5;
            const int sixthControl = (int)UserControl.Exercise6;
            const int seventhControl = (int)UserControl.Exercise7;


            const int exitControl = (int)UserControl.Exit;
            while (!isExit)
            {
                Console.WriteLine("|||For show solve of exercise from 1 to 7 enter relevant number,\n|||to exit enter 8");
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
                            exercise2.Show();
                            break;
                        }
                    case thirdControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise3);
                            Exercise3 exercise3 = new Exercise3();
                            //exercise3.Show();
                            break;
                        }
                    case fourthControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise4);
                            Exercise4 exercise4 = new Exercise4();
                            exercise4.Show();
                            break;
                        }
                    case fifthControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise5);
                            Exercise5 exercise5 = new Exercise5();
                            exercise5.Show();
                            break;
                        }
                    case sixthControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise6);
                            Exercise6 exercise6 = new Exercise6();
                            exercise6.Show();
                            break;
                        }
                    case seventhControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise7);
                            Exercise7 exercise7 = new Exercise7();
                            exercise7.Show();
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
            Console.WriteLine("|||For show solve of exercise from 1 to 7 enter relevant number,\n|||to exit enter 8");
            return;
        }
    }
}
