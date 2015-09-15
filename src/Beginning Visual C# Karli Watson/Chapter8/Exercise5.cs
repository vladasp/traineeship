using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    class Exercise5
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите код для функции, которая в качестве параметра принимает один из двух 
возможных в предыдущем примере объектов типа Cup... (CupOfCoffee или CupOfTea). 
Эта функция должна вызывать методы AddMilk, Drink и Wash для любого
передаваемого ей объекта Cup.

        public void CupOfHotDrink()
        {
            CupOfCoffe coffe = new CupOfCoffe();
            CupOfTea tea = new CupOfTea();
            coffe.AddMilk();
            coffe.Drink();
            tea.AddMilk();
            tea.Drink();
            ICup cupcofee = (ICup)coffe;
            ICup cuptea = (ICup)tea;
            cupcofee.Wash();
            cuptea.Wash();
        }
                            ");
        }
        public void CupOfHotDrink()
        {
            CupOfCoffe coffe = new CupOfCoffe();
            CupOfTea tea = new CupOfTea();
            coffe.AddMilk();
            coffe.Drink();
            tea.AddMilk();
            tea.Drink();
            ICup cupcofee = coffe;
            ICup cuptea = tea;
            cupcofee.Wash();
            cuptea.Wash();
        }
    }
}
