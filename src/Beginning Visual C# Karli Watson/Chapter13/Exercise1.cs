using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите обработчик событий, который использует универсальный
синтаксис (object sender, EventArgs e) и принимает либо событие
Timer.Elapsed, либо событие  Connection.MessageArrived  из  кода,
приведенного ранее в главе. Этот обработчик должен выводить строку,
указывающую тип полученного события, а также значение свойства
Message параметра MessageArrivedEventArgs или свойства SignalTime
параметра ElapsedEventArgs в зависимости от произошедшего события.
                            ");
        }
    }
}
