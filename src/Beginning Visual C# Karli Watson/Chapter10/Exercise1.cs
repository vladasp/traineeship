using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите код, определяющий базовый класс MyClass с виртуальным методом 
GetString. Этот метод должен возвращать строку, хранящуюся в защищенном поле 
myString, которое доступно только через предназначенное для записи 
public-свойство ContainedString.
                            ");
            MyClass myClass = new MyClass();
            Console.WriteLine("Output field myString {0} from base class MyClass", myClass.GetString());
        }
    }
}
