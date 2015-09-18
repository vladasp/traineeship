using System;
using System.Collections;

namespace Chapter11
{
    enum UserControl { Exercise1 = 1, Exercise2, Exercise3, Exercise4, Exercise5, Exit }
    class Program
    {
        static void Main(string[] args)
        {
            UserControl usercontrol = new UserControl();
            Person namesList = new Person();
            namesList.Add("Vlad", new Person("Vlad", 28));
            namesList.Add("Alina", new Person("Alina", 24));
            namesList.Add("Ivan", new Person("Ivan", 31));
            namesList.Add("Luda", new Person("Ludmila", 21));

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
                        Console.WriteLine(namesList["Vlad"].Name);
                        foreach (DictionaryEntry personEntry in namesList)
                        {
                           Console.WriteLine("Person {0} ({1} years old)", ((Person)personEntry.Value).Name, ((Person)personEntry.Value).Age);
                        }
                        break;
                    case UserControl.Exercise2:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise2);
                        Exercise2 exercise2 = new Exercise2();
                        exercise2.Show();
                        Console.WriteLine("{0} older then {1}: {2}", 
                            namesList["Vlad"].Name, namesList["Alina"].Name, namesList["Vlad"] > namesList["Alina"]);
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
    }
}
