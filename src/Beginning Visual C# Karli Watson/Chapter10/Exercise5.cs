using System;
using CardLibrary;
using System.Collections.Generic;

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
            List<Card> tempCard = new List<Card>();
            Random genrateNumber = new Random();
            int cardNumber = genrateNumber.Next(52);
            int countFlash = 0;
            for (int i = 5; i <= 50; i += 5)
            {
                tempCard.Clear();
                countFlash = 0;
                for (int j = 0; j < 5; j++)
                {
                    tempCard.Add(myDeck.GetCard(j));
                    if (tempCard[0].rank == tempCard[j].rank)
                    {
                        countFlash += 1;
                    }
                }
                if (countFlash == 5)
                {
                    Console.WriteLine("Flash! :-)");
                    for (int c = 0; c < tempCard.Count; c++)
                    {
                        if (i != 5)
                            Console.WriteLine("{0},", tempCard[c].ToString());
                        else
                            Console.WriteLine("{0}\n", tempCard[c].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No flash :-(\nYou played {0} times\n", i/5);
                }
            }
            Console.ReadKey();
        }
    }
}
