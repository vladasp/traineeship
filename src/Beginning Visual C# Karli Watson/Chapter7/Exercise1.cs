using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
“Лучше использовать функцию Trace.WriteLine(), а не Debug.WriteLine(),
т.к. версия Debug работает только в отладочных сборках”. 
Согласны ли вы с этим и почему?

Depending on the debugging use the appropriate methods
For example, in IDE VS can be used both methods, and the VCE only debug ()
                                ");
        }
    }
}
