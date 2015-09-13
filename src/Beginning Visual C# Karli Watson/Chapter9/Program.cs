using System;

namespace Chapter9
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exit }
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
                            exercise2.Show();
                            break;
                        }
                    case thirdControl:
                        {
                            Console.WriteLine("Solve of {0}", UserControl.Exercise3);
                            Exercise3 exercise3 = new Exercise3();
                            exercise3.Show();
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
