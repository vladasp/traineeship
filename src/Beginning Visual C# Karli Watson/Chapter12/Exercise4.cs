using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Что неверно в следующем коде? Устраните ошибку.
public class StringGetter<T1>
{
  public string GetString<T2>(T2 item)
  {
    return item.ToString();
  }
}
We can't use one of genetic class and method names.
                            ");
        }
    }
}
