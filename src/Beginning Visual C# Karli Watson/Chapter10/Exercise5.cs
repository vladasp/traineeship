using System;
using CardLibrary;

namespace Chapter10
{
    class Exercise5
    {
        public void Show()
        {
            Console.WriteLine(@"
Напишите клиентское консольное приложение для библиотеки  Ch10CardLib, 
позволяющее вытягивать сразу пять карт из перетасованной колоды (объекта Deck). 
Если все пять карт оказываются одной масти, их названия должны быть выведены 
на консоль вместе с текстом Flush!; в противном случае приложение должно
завершит работу после просмотра 50 карт, с выводом текста No flush. 
                            ");
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            Random genrateNumber = new Random();
            int cardNumber = genrateNumber.Next(52);
            for (int i = 1; i <= 5; i++)
            {
                Card tempCard = myDeck.GetCard(i);
                if (i != 5)
                    Console.WriteLine("{0},", tempCard.ToString());
                else
                    Console.WriteLine("{0}\n", tempCard.ToString());
            }
            Console.ReadKey();
        }
    }
}
