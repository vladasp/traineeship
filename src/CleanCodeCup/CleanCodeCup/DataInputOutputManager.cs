using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    public static class DataInputOutputManager
    {
        public static void OutputMessager(string message)
        {
            Console.WriteLine(message);
        }
        public static void OutputMessager(string message, object name)
        {
            Console.WriteLine(message + name.ToString());
        }
        public static string InputMessanger()
        {
            string message = Console.ReadLine();
            return message;
        }
    }
}


