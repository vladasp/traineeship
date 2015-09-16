using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class Exercise2
    {
        public void Show()
        {
            Console.WriteLine(@"
Создайте класс MyDerivedClass, унаследованный от класса MyClass. Переопределите 
в нем метод GetString, который возвращает строку с использованием базовой реали-
зации данного метода, добавляя к ней еще текст ( from derived class).
                            ");
            MyDerivedClass myDerivedClass = new MyDerivedClass();
            Console.WriteLine("Output field myString {0} from derived class myDerivedClass", myDerivedClass.GetString());
        }
    }
}
