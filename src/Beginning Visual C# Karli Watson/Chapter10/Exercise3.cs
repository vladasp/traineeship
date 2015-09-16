using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    class Exercise3
    {
        public void Show()
        {
            Console.WriteLine(@"
Частичные методы должны обязательно использовать void 
в качестве возвращаемого типа. Объясните причину.

Its need beacorse partial methods dont returned method. 
A partial method has its signature defined in one part of a partial type,
and its implementation defined in another part of the type.
                            ");
        }
    }
}
