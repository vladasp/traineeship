using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Exercise5
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите консольное приложение, способное получать от пользователя строку 
и выводить ее с отображением символов в обратном порядке. 
                            ");
            Console.WriteLine("Enter any word");
            string rightWords = Console.ReadLine();
            char[] rightWordsArray = rightWords.ToArray();
            char[] converselyWordsArray = new char[rightWordsArray.Length];
            Console.WriteLine("Right worlds {0}", rightWords);
            for (int i = rightWordsArray.Length-1; i >= 0; i--)
            {
                for (int j = 0; j < converselyWordsArray.Length; j++)
                 {
                     converselyWordsArray[j] = rightWordsArray[i];
                     i--;
                 }
            }
                string converselyWords = new string (converselyWordsArray);

            Console.WriteLine("Right worlds {0}, convers worlds {1}", rightWords, converselyWords);
        }
    }
}
