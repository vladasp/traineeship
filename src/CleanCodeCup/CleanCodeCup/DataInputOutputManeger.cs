using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    class DataInputOutputManeger
    {
        public void OutputMasseger(string massege)
        {
            Console.WriteLine(massege);
        }
        public void OutputMasseger(string massege, object name)
        {
            Console.WriteLine(massege + name.ToString());
        }
    }
}


