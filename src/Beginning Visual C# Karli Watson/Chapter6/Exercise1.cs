using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
Две приведенных ниже функции содержат ошибки. Назовите их.                           
        }
        static string Write()                               - it must have return bool variable
        {
            Console.WriteLine('Text output from function.');
        }
        static void myFunction(string label, params int[] args, bool showLabel) - variable args must be 'int[] args'
        {
            if (showLabel)
                Console.WriteLine(label);
            foreach (int i in args)
                Console.WriteLine('{0}', i);

                                ");
        }
    }
}
