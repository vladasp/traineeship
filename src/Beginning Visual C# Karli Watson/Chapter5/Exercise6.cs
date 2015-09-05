using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    class Exercise6
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите консольное приложение, которое запрашивает строку и заменять в ней 
все вхождения слова no словом yes.                            
                            ");
            const string yesConstant = "yes";
            const string noConstant = "no";
            string userWord;
            string computerWord;
            do
            {
                Console.WriteLine("Hi there. Please enter the word 'no'?");
                userWord = Console.ReadLine();
                userWord = userWord.Trim();
                if (userWord.ToLower() == noConstant)
                {
                    computerWord = yesConstant;
                }
                else
                {
                    computerWord = "Are you kidding? Enter the write word! Lets start again.";
                }
                Console.WriteLine(computerWord);
                Console.WriteLine("");
            } while (computerWord != yesConstant);
        }
    }
}
