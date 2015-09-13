using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Exercise2
    {
        public void Show(string stringArg1, string stringArg2)
        {
            Console.WriteLine(@"
Напишите приложение, которое использует два аргумента командной строки для занесения значений, 
соответственно, в строку и в целочисленную переменную, а затем выводит эти значения.
                                ");
            string getStringArg = stringArg1;
            int getIntArg = Convert.ToInt32(stringArg2);
            Console.WriteLine("String argument - {0}\nInt argument - {1}\n ", getStringArg, getIntArg);
        }
    }
}
