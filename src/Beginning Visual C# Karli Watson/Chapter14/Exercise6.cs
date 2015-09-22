using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    class Exercise6
    {
        public void Show()
        {
            Console.WriteLine(@"
Перепишите показанный выше метод ToAcronym() так, чтобы его код занимал одну 
строку, и позаботьтесь о том, чтобы строки с множеством пробелов между
словами в нем не приводили к появлению ошибок. Подсказка: для этого потребуется
использовать тернарную операцию ?:, функцию расширения string.Aggregate<string, 
string>() и лямбда-выражение.
                            ");
        }
    }
}
