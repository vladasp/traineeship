using System;

namespace Chapter_3
{
    class Exercise5
    {
        public void GetName()
        {
            string[] namesArray = new string[4] { "Name1", "Name2", "Name3", "Name4" };
            Console.WriteLine("Enter the number from 1 to 4");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your chois is {0}", namesArray[number-1]);
            return;
        }
    }
}
