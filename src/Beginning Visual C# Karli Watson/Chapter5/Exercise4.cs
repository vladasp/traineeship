using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Будет ли компилироваться приведенный ниже код? Обоснуйте ответ. 
string[] blab = new string[5] 
string[5] = 5th string          - wrong designation of this array
blab[5] = '5th string';         - right designation of this array
                            ");
        }
    }
}
