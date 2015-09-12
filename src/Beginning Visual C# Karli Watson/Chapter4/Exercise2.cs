using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Exercise2
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите приложение, включающее логику из первого упражнения, которое 
получает два числа от пользователя и отображает их на экране, но отклоняет 
варианты, когда оба числа больше 10, и предлагает в таком случае ввести два 
других числа.
                            ");

            int var1, var2;
            bool isMore;
            bool moreBothNum = false;
            do
            {
                Console.WriteLine("Enter first number");
                var1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second number");
                var2 = Convert.ToInt32(Console.ReadLine());
                isMore = ((var1 > 10) ^ (var2 > 10)) ? true : false;
                if (isMore || !isMore && var1 < 10 && var2 < 10)
                {
                    Console.WriteLine("Both numbers ({0} and {1}) NO more than 10", var1, var2);
                    Console.WriteLine("You need change values");
                    moreBothNum = false;
                }
                else if (!isMore && var1 > 10 && var2 > 10)
                {
                    Console.WriteLine("Both numbers ({0} and {1}) more than 10", var1, var2);
                    moreBothNum = true;
                }
                Console.WriteLine("");

            } while (!moreBothNum);
            return;
        }

    }
}
