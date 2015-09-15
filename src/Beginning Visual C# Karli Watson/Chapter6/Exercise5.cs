using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Exercise5
    {
        public void Show()
        {
            Console.WriteLine(@"
Добавьте в структуру order еще один член — функцию, возвращающую 
форматированную строку (с заменой всех курсивных элементов в угловых
скобках соответствующими значениями):
Order Information: <количество единиц> <название товара> items
   at $ <цена за единицу> each,
   total cost $ <общая стоимость>
Информация о заказе: <количество единиц> штук <название товара> 
   по цене <цена за единицу> каждый,
   общей стоимостью <общая стоимость>
                                ");
            Exercise4 ex4 = new Exercise4();
            ex4.Show();
        }
    }
}
