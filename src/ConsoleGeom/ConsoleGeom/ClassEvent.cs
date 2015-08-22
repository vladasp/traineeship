using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGeom
{
    class ClassEvent
    {
        public int ChangedLine()
        {
            string a;
            int b = 0; bool TRUE = false;
            do
            {
                a = Console.ReadLine();
                foreach (char c in a)
                {
                    if (Char.IsNumber(c) == true || c == '-')
                    {
                        b = int.Parse(a);
                        TRUE = true;
                    }
                    else
                    {
                        Console.WriteLine("Only numbers");
                        a = a.Remove(a.Length - 1);
                    }
                }
            }
            while (TRUE == false);
            return b;
            }
        }
    }
