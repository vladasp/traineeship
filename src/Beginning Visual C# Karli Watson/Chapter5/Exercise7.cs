using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Exercise7
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите  консольное  приложение,  которое  заключает  каждое  слово  
в  строке в двойные кавычки.                            
                            ");
            Console.WriteLine("Enter any phrase");
            string myString = Console.ReadLine();
            char[] separator = {' '};
            string[] myWords;
            myWords = myString.Split(separator);
            foreach (string word in myWords)
            {
                Console.WriteLine("\"{0}\"", word);
            }
            Console.ReadKey();
        }
    }
}
