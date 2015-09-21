using System;

namespace Chapter13
{
    enum UserControl { Exercise1 = 1, Exercise2, Exit }
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
                        Connection myConnection = new Connection();
                        Display myDisplay = new Display();
                        myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
                        myConnection.Connect();
                        Console.ReadKey();
                        break;
                    case UserControl.Exercise2:
                        Console.WriteLine("Solve of {0}", UserControl.Exercise2);
                        Exercise2 exercise2 = new Exercise2();
                        exercise2.Show();
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
