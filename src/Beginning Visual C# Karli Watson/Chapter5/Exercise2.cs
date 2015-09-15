using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{            enum ColorsShort : short {white = 0, red, orange, yellow, green, blue, purple, black };
             enum ColorsByte : byte { white = 0, red, orange, yellow, green, blue, purple, black };

    class Exercise2
    {
        public void Show()
        {
            Console.WriteLine(@"
Создайте на базе типа short код для перечисления color, содержащего все цвета радуги,
а также черный и белый цвет.Может ли такое перечисление основываться на типе byte?
                            ");
            Console.WriteLine("Colors with short type");
            foreach (ColorsShort color in Enum.GetValues(typeof(ColorsShort)))
            {
                Console.WriteLine("Color name {0} and short type value {1}\n", color, (short)color);
            }
            Console.WriteLine("Colors with byte type");
            foreach (ColorsByte color in Enum.GetValues(typeof(ColorsByte)))
            {
                Console.WriteLine("Color name {0} and byte type value {1}\n", color, (byte)color);
            }
        }
    }
}
