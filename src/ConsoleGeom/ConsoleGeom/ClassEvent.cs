using System;
using System.Collections.Generic;

namespace ConsoleGeom
{
    class ClassEvent
    {
        public double ChangedLine()
        {
            string parameterGet;
            double parameterSet = 0;
            bool checkParameter = false;
            List<char> myChar = new List<char>();
            do
            {
                myChar.Clear();
                parameterGet = Console.ReadLine();
                foreach (char c in parameterGet)
                {
                    myChar.Add(c);
                }

                #region Сheck the correctness of input
                for (int i = 0; i < myChar.Count; i++)
                {
                    for (int j = 0; j < myChar.Count; j++)
                    {
                        Console.WriteLine(myChar[i]);

                        if (myChar[0] != '-' && myChar[i] != '-' && i > 0 && myChar[i] != ',' || myChar[0] == '-' && myChar[i] != '-' && i > 0 && myChar[i] != ',')
                        {
                            checkParameter = true;
                        }
                        else if (myChar[0] == '-' && myChar[1] != ',' && myChar[i] == ',' && i > 1 && j > 1 && myChar[i] != myChar[j] && i!=j)
                        {
                            checkParameter = true;
                        }
                        else if (myChar[0] == '-' && myChar[1] != ',' && i > 0 && j > 0 && myChar[i] != myChar[j] && i != j)
                        {
                            checkParameter = true;
                        }
                        else if (myChar[0] != '-' &&  myChar[0] == ',' && myChar[i] != myChar[j] && i != j)
                        {
                            checkParameter = true;
                        }
                        else if (Char.IsNumber(myChar[i]))
                        {
                            checkParameter = true;
                        }
                        else
                        {
                            checkParameter = false;
                            break;
                        }

                    } if (!checkParameter) { break; }
                }
                #endregion

                if (checkParameter)
                    {
                        parameterSet = Convert.ToDouble(parameterGet);
                    }
                    else
                    {
                        Console.WriteLine("Only numbers");
                    }
            }
            while (!checkParameter);
            return parameterSet;
        }
    }
}
