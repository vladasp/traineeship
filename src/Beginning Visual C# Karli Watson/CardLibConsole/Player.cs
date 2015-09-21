using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardLibConsole
{
    class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }

        private Player()
        {
        }
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        public bool HasWon()
        {
            // Создать временную копию раскладки на руках, которая может изменяться.
            Cards tempHand = (Cards)PlayHand.Clone();
            // Найти наборы по три и четыре карты
            bool fourOfAKind = false;
            bool threeOfAKind = false;
            int fourRank = -1;
            int threeRank = -1;
            int cardsOfRank;
            for (int matchRank = 0; matchRank < 13; matchRank++)
            {
                cardsOfRank = 0;
                foreach (Card c in tempHand)
                {
                    if (c.rank == (Rank)matchRank)
                    {
                        cardsOfRank++;
                    }
                }
                if (cardsOfRank == 4)
                {
                    // Пометить набор из четырех карт
                    fourRank = matchRank;
                    fourOfAKind = true;
                }
                if (cardsOfRank == 3)
                {
                    // Два набора по три карты означают невозможность выигрыша
                    // (threeOfAKind будет true, только если этот код уже выполнялся)
                    if (threeOfAKind == true)
                    {
                        return false;
                    }
                    // Пометить набор из трех карт
                    threeRank = matchRank;
                    threeOfAKind = true;
                }
            }
            // Проверить простое условие выигрыша
            if (threeOfAKind && fourOfAKind)
            {
                return true;
            }
            // Упростить раскладку на руках, если найдет набор из трех или четырех карт, 
            // удалив использованные карты
            if (fourOfAKind || threeOfAKind)
            {
                for (int cardIndex = tempHand.Count - 1; cardIndex >= 0; cardIndex--)
                {
                    if ((tempHand[cardIndex].rank == (Rank)fourRank)
                       || (tempHand[cardIndex].rank == (Rank)threeRank))
                    {
                        tempHand.RemoveAt(cardIndex);
                    }
                }
            }
            // В этой точке из метода может быть возврат, поскольку:
            // - найден набор из четырех и набор из трех карт, выигрыш
            // - найдено два набора из трех карт, проигрыш
            // Если возврат из метода не произошел, это означает одну из следующих ситуаций:
            // - ни одного набора не найдено, и tempHand содержит 7 карт
            // - найден набор из трех карт, и tempHand содержит 4 карты
            // - найден набор из четырех карт, и tempHand содержит 3 карты
            // Найти исход из четырех наборов, начиная с поиска карт той же самой масти
            // показанным ранее способом 
            bool fourOfASuit = false;
            bool threeOfASuit = false;
            int fourSuit = -1;
            int threeSuit = -1;
            int cardsOfSuit;
            for (int matchSuit = 0; matchSuit < 4; matchSuit++)
            {
                cardsOfSuit = 0;
                foreach (Card c in tempHand)
                {
                    if (c.suit == (Suit)matchSuit)
                    {
                        cardsOfSuit++;
                    }
                }
                if (cardsOfSuit == 7)
                {
                    // Если все карты имеют ту же самую масть, возможны, но не очевидны два исхода
                    threeOfASuit = true;
                    threeSuit = matchSuit;
                    fourOfASuit = true;
                    fourSuit = matchSuit;
                }
                if (cardsOfSuit == 4)
                {
                    // Пометить набор из четырех карт одной масти
                    fourOfASuit = true;
                    fourSuit = matchSuit;
                }
                if (cardsOfSuit == 3)
                {
                    // Пометить набор из трех карт одной масти
                    threeOfASuit = true;
                }
                threeSuit = matchSuit;
               }
               if (!(threeOfASuit || fourOfASuit))
               {
                  // Чтобы можно было продолжить, нужен, по меньшей мере, один исход
                  return false;
               }
               if (tempHand.Count == 7)
               {
                  if (!(threeOfASuit && fourOfASuit))
                  {
                     // Нужны наборы из трех и четырех карт одной масти
                     return false;
                  }
                  // Создать два временных набора для проверки
                  Cards set1 = new Cards();
                    Cards set2 = new Cards();
                  // Если все 7 карт имеют ту же самую масть...
                  if (threeSuit == fourSuit)
                  {
                     // Получить минимальное и максимальное достоинства карт
                     int maxVal, minVal;
                     GetLimits(tempHand, out maxVal, out minVal);
                     for (int cardIndex = tempHand.Count - 1; cardIndex >= 0; cardIndex--)
                     {
                        if (((int)tempHand[cardIndex].rank< (minVal + 3))
                        || ((int)tempHand[cardIndex].rank > (maxVal - 3)))
                        {
                           // Удалить все карты из набора из трех карт, которые
                           // начинаются с minVal или заканчиваются на maxVal
                           tempHand.RemoveAt(cardIndex);
                        }
                    }
                     if (tempHand.Count != 1)
                     {
                        // Если осталось более одной карты, двух исходов не будет
                        return false;
                     }
                     if ((tempHand[0].rank == (Rank)(minVal + 3))
                        || (tempHand[0].rank == (Rank)(maxVal - 3)))
                     {
                        // Если запасная карта может превратить один из наборов из трех карт
                        // в набор из четырех карт, значит, есть два набора
                        return true;
                     }
                     else
                     {
                        // Если запасная карта не подходит, значит, есть два набора из трех
                        // карт, но ни одного набора из четырех карт
                        return false;
                     }
                  }
                  // Если наборы из трех и четырех карт отличаются...
                  foreach (Card card in tempHand)
                  {
                     // Разделить карты в наборы
                     if (card.suit == (Suit)threeSuit)
                     {
                        set1.Add(card);
                     }
                else
                     {
                        set2.Add(card);
                     }
                  }
                  // Проверить, последовательны ли наборы
                  if (isSequential(set1) && isSequential(set2)) {
                     return true;
                  }
                  else
                  {
                     return false;
                  }
               }
               // Если остается четыре карты (найдено три карты одного достоинства)
               if (tempHand.Count == 4)
               {
                  // Если осталось четыре карты, они должны быть той же самой масти
                  if (!fourOfASuit)
                  {
                     return false;
                  }
                  // Выигрыш, если карты последовательны
                  if (isSequential(tempHand))
                  {
                     return true;
                  }
               }
               // Если остается три карты (найдено четыре карты одного достоинства)
               if (tempHand.Count == 3)
               {
                  // Если осталось три карты, они должны быть той же самой масти
                  if (!threeOfASuit)
                  {
                     return false;
                  }
                  // Выигрыш, если карты последовательны
                  if (isSequential(tempHand))
                  {
                     return true;
                  }
               }
               // Вернуть false, если не существует двух допустимых наборов
               return false;
            }
        // Служебный метод для получения минимального и максимального достоинств карт
        // (предполагается, что они тоже же самой масти)
        private void GetLimits(Cards cards, out int maxVal, out int minVal)
        {
            maxVal = 0;
            minVal = 14;
            foreach (Card card in cards)
            {
                if ((int)card.rank > maxVal)
                {
                    maxVal = (int)card.rank;
                }
                if ((int)card.rank < minVal)
                {
                    minVal = (int)card.rank;
                }
            }
        }
        // Служебный метод для просмотра, находятся ли карты в исходе
        // (предполагается, что они тоже же самой масти)
        private bool isSequential(Cards cards)
        {
            int maxVal, minVal;
            GetLimits(cards, out maxVal, out minVal);
            if ((maxVal - minVal) == (cards.Count - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
