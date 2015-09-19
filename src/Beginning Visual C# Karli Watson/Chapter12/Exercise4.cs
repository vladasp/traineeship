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
public class StringGetter<T>
{
  public string GetString<T>(T item)
  {
    return item.ToString();
  }
}
                            ");
        }
    }
}
