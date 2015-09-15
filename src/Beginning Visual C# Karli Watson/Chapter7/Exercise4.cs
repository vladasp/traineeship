using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    enum orientation : byte { north = 1, south = 2, east = 3, west = 4 }
    class Exercise4
    {
        byte myByte;
        orientation myDirection;
        public void Show()
        {
            Console.WriteLine(@"
С учетом приведенного ниже определения для типа перечисления orientation 
напишите приложение, использующее технологию структурной обработки 
исключений (SEH) для безопасного приведения переменной типа byte к orientation. 
(Примечание: принудительную генерацию исключений можно выполнить с помощью 
ключевого слова checked, как указано ниже в примере. Обязательно используйте
этот код в приложении.)
                            ");
            Console.WriteLine("Enter a value from 1 to 4 for programm wright work, and other value to get exeption");
            for (byte i = 0; i <= 6; i++)
            {
                myByte = i;
                try
                {
                   myDirection = checked((orientation)myByte);
                   if (myDirection > orientation.west || myDirection < orientation.north)
                    {
                        throw new InvalidCastException("Faild convertion!");
                    }
                    else
                    {
                        Console.WriteLine("No exeption of type conversion of byte \"{0}\" to orientation \"{1}\"\n", myByte, myDirection);
                    }
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine("Exeption: {0}\n", e.ToString());
                }
            }
        }
    }
}
