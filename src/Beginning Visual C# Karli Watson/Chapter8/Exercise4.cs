using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Нарисуйте UML-диаграмму, подобную приведенным в главе, для перечисленных ниже 
классов и интерфейса.
    - Абстрактный класс с именем HotDrink (Горячий напиток), методами Drink (Пить), 
    AddMilk  (Добавить молока) и AddSugar  (Добавить  сахара)  и  свойствами  Milk 
    (Молоко) и Sugar (Сахар).
    - Интерфейс ICup (Чашка), содержащий методы Refill (Наполнить снова) и Wash 
    (Помыть), а также свойства Color (Цвет) и Volume (Объем).
    - Класс с именем CupOfCoffee (Чашка кофе), порожденный от класса HotDrink 
    (Горячий напиток), поддерживающий интерфейс ICup и обладающий дополнитель-
    ным свойством BeanType (Сорт кофе).
    - Класс с именем CupOfTea (Чашка чая), порожденный от класса HotDrink, поддер-
    живающий интерфейс ICup и обладающий дополнительным свойством LeafType 
    (Сорт чая).                            
                            ");
        }
    }
}
