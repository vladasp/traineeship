using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите код класса по имени MyCopyableClass, который может возвращать копию 
самого себя с применением метода GetCopy. В этом методе должен использоваться
метод MemberwiseClone, унаследованный от System.Object. Добавьте в класс простое 
свойство и напишите клиентский код для тестирования работоспособности.
                            ");
            MyCopyableClass copyOfClass1 = new MyCopyableClass();
            MyCopyableClass copyOfClass2 = copyOfClass1.CloneClass();
            copyOfClass2.myPropertyField = "Copy field";
            MyCopyableClass copyOfClass3 = copyOfClass2.CloneClass();
            copyOfClass3.myPropertyField += " again";
            Console.WriteLine("First instance of MyCopyableClass with field \"{0}\",\nsecond instance of MyCopyableClass with field \"{1}\",\nthird instance of MyCopyableClass with field \"{2}\"",
               copyOfClass1.myPropertyField, copyOfClass2.myPropertyField, copyOfClass3.myPropertyField);
            
        }
    }
}
