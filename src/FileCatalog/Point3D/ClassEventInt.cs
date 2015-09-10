using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class ClassEventInt
    {
        public int ChangedLine()
        {
            string parameterSet;
            int parameterGet = 0;
            int number;
            bool canPars = false;

            do
            {
                parameterSet = Console.ReadLine();
                if (int.TryParse(parameterSet, out number))
                {
                    parameterGet = Convert.ToInt32(parameterSet);
                    canPars = true;
                }
                else
                {
                    Console.WriteLine("Only numbers");
                    canPars = false;
                }
            }
            while (!canPars);
            return parameterGet;
        }
    }
}
