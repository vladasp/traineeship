using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Exercise1
    {
          public void IsMore()
            {
            Console.WriteLine(@"
При наличии двух целых чисел, хранящихся в переменных varl и var2, какую
булевскую проверку можно выполнить для выяснения того, является ли то или
другое(но не оба вместе) больше 10? 
                            ");

                int var1, var2;
                bool isMore;
                Console.WriteLine("Enter first number");
                var1 =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number");
                var2 = Convert.ToInt32(Console.ReadLine());
                isMore = ((var1 > 10) ^ (var2 > 10)) ? true : false;
                Console.WriteLine("Is number {0} or number {1} and is no both more then 10? Ansver: {2}", var1, var2, isMore);
                Console.WriteLine("");
            return;
            }
    }
}
