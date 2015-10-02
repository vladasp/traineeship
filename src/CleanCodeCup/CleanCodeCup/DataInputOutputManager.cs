using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    class DataInputOutputManager
    {
        public void OutputMessager(string message)
        {
            Console.WriteLine(message);
        }
        public void OutputMessager(string message, object name)
        {
            Console.WriteLine(message + name.ToString());
        }
        public string InputMessanger()
        {
            string message = Console.ReadLine();
            return message;
        }
    }
}


