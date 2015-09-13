using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Exercise2
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите код для простого приложения с циклом, которое генерирует ошибку после 
выполнения 5000 итераций. Используйте точку останова для перехода в режим
останова непосредственно перед возникновением ошибки на 5000-й итерации. 
(Примечание: проще всего сгенерировать ошибку с помощью доступа 
к несуществующему элементу массива — например, к myArray[1000] 
в массиве из сотни элементов).
                            ");
            int[] myArray = new int[4999];
            for (int i = 0; i <= myArray.Length+1; i++)
            {
                if (i%1000 == 0)
                {
                    Console.WriteLine("Mark {0}", myArray[i]);
                }
                else { };
            }
        }
    }
}
