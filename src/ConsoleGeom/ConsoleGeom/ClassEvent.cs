using System;

namespace ConsoleGeom
{
    class ClassEvent
    {
        public double ChangedLine()
        {
            string parameterGet;
            double parameterSet = 0;
            bool checkParameter = false;
            do
            {
                parameterGet = Console.ReadLine();
                try
                {
                    parameterSet = Convert.ToDouble(parameterGet);
                    checkParameter = true;
                }
                catch
                {
                    Console.WriteLine("Only numbers");
                }
            }
            while (!checkParameter);
            return parameterSet;
        }
    }
}
