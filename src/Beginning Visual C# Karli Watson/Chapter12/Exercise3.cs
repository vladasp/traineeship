using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter12
{
    class Exercise3
    {
        public void Show()
        {
            Console.WriteLine(@"
Что неверно в следующем коде? Устраните ошибку.
public class Instantiator<T>
{
  public T instance;
 
   public Instantiator()
  {
    instance = new T();
  }
}
                            ");
        }
    }
}
