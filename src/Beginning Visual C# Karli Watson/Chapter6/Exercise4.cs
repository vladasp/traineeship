using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Измените следующую структуру, чтобы она включала функцию, 
возвращающую общую цену заказа:
struct order
{
   public string itemName;    // Название товара
   public int    unitCount;   // Количество единиц
   public double unitCost;    // Цена за единицу
}
                                ");
        }
    }
        struct Order
        {
            public string itemName;    // Название товара
            public int unitCount;      // Количество единиц
            public double unitCost;    // Цена за единицу
            public double TotalSum()
            {
            double totalSum = unitCount * unitCost;
                return totalSum;
            }
            public void Information()
            {
            Console.WriteLine(@"
Order Information: {0} {1} items
   at $ {2} each,
   total cost $ {3}
Информация о заказе: {0} штук {1} 
   по цене {2} каждый,
   общей стоимостью {3}
", unitCount, itemName, unitCost, TotalSum());
            }
        }
    }
