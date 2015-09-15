using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter9
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
Что неверно в следующем коде? 
public sealed class MyClass
{
   // Члены класса.
}
public class myDerivedClass : MyClass
{
   // Члены класса.
}
Access identifier sealed does not provide inheritance
                            ");
        }
    }
}
