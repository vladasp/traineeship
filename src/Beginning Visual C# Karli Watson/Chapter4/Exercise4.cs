using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Exercise4
    {
        public void Show()
        {
            double realCoord, imagCoord;
            double realMax = 1.77;
            Console.WriteLine("Max value of realCoord is {0}, if change enter new value,\nfor do next press Enter", realMax);
            if (Console.ReadLine() != String.Empty)
            {
                realMax = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("New max value of realCoord is {0}\n", realMax);
            }
            else
            {
                Console.WriteLine("Max value of realCoord stay {0}\n", realMax);
            }
            double realMin = -0.6;
            Console.WriteLine("Min value of realCoord is {0}, if change enter new value,\nfor do next press Enter", realMin);
            if (Console.ReadLine() != String.Empty)
            {
                realMin = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("New min value of realCoord is {0}\n", realMin);
            }
            else
            {
                Console.WriteLine("Min value of realCoord stay {0}\n", realMin);
            }
            double imagMax = -1.2;
            Console.WriteLine("Max value of imagCoord is {0}, if change enter new value,\nfor do next press Enter", imagMax);
            if (Console.ReadLine() != String.Empty)
            {
                imagMax = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("New max value of imagCoord is {0}\n", imagMax);
            }
            else
            {
                Console.WriteLine("Max value of imagCoord stay {0}\n", imagMax);
            }
            double imagMin = 1.2;
            Console.WriteLine("Min value of imagCoord is {0}, if change enter new value,\nfor do next press Enter", imagMin);
            if (Console.ReadLine() != String.Empty)
            {
                imagMin = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("New min value of imagCoord is {0}\n", imagMin);
            }
            else
            {
                Console.WriteLine("Min value of imagCoord stay {0}\n", imagMin);
            }
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            double realStep = (realMax - realMin) / 48;
            double imagStep = (imagMax - imagMin) / 79;
            for (imagCoord = imagMin; imagCoord >= imagMax; imagCoord += imagStep)
            {
                for (realCoord = realMin; realCoord <= realMax; realCoord += realStep)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp) - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    } 
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
