using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
Модифицируйте следующий класс так, чтобы стало возможным использование
инициализатора объектов, и приведите пример кода для создания и 
инициализации экземпляра этого класса за один шаг.
public class Giraffe
{
  public Giraffe(double neckLength, string name)
  {
    NeckLength = neckLength;
    Name = name;
  }
  public double NeckLength {get; set;}
  public string Name {get; set;}
}

Ansver:
public class Giraffe
{  public Giraffe(double neckLength, string name)
  {
    NeckLength = neckLength;
    Name = name;
  }
  public double NeckLength {get; set;}
  public string Name {get; set;}
  public Giraffe() { };
}
Giraffe myGiraffe = new Giraffe {NeckLength = 15, Name ='SomeString'};
                            ");
        }
    }
}
