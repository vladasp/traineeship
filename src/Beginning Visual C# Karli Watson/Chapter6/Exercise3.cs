using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    delegate string SetChangeLine(string parameter1, string parameter2); 
    class Exercise3
    {
        public void Show()
        {
            Console.WriteLine(@"
Создайте делегат и используйте его для выполнения функции Console.ReadLine() 
при запросе у пользователя входных данных.
                                ");
        }
        public string SetConsoleReadLine(string setNick, string setPassword)
        {
            return  setNick + " " + setPassword;
        }
    }
}
