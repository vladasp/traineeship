using System;
using System.Collections.Generic;

namespace Chapter6
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exit }
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
                        args[0] = "First argument";
                        args[1] = "2";
                        exercise2.Show(args[0], args[1]);
                        break;
                    case UserControl.Exercise3:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise3);
                        Exercise3 exercise3 = new Exercise3();
                        SetChangeLine setChangeLine;
                        exercise3.Show();
                        setChangeLine = new SetChangeLine(exercise3.SetConsoleReadLine);
                        Console.WriteLine("Enter your name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        string password = Console.ReadLine();
                        Console.WriteLine("Yours parameters to enter: {0}\n", setChangeLine(name, password));
                        break;
                    case UserControl.Exercise4:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise4);
                        Exercise4 exercise4 = new Exercise4();
                        exercise4.Show();
                        Order order1;
                        order1.itemName = "Notebook";
                        order1.unitCost = 500;
                        order1.unitCount = 3;
                        Console.WriteLine("Total sum {0} of units \"{1}\".\n ", order1.TotalSum(), order1.itemName);
                        break;
                    case UserControl.Exercise5:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise5);
                        Exercise5 exercise5 = new Exercise5();
                        exercise5.Show();
                        Order order2;
                        order2.itemName = "Notebook";
                        order2.unitCost = 500;
                        order2.unitCount = 3;
                        order2.Information();
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
        }
    }
}
