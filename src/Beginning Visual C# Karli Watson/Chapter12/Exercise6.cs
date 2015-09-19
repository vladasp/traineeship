using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Exercise6
    {
        public void Show()
        {
            Console.WriteLine(@"
Будет ли компилироваться следующий код? Если нет, то почему? 
public interface IMethaneProducer<out T>
{
   void BelchAt(T target);
}
                            ");
        }
    }
}
