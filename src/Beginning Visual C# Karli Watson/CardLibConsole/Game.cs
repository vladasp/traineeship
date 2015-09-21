using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardLibConsole
{
    class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;
        public Game()
        {
            currentCard = 0;
            playDeck = new Deck(true);
            playDeck.LastCardDrawn += new LastCardDrawnHandler(Reshuffle);
            playDeck.Shuffle();
            discardedCards = new Cards();
        }
        private void Reshuffle(Deck currentDeck)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            // Отброшенные карты перетасованы и помещены в колоду
            currentDeck.Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException("A maximum of 7 players may play this" +
                                                  " game.");
            // В эту игру может играть не более 7 игроков
            if (newPlayers.Length < 2)
                throw new ArgumentException("A minimum of 2 players may play this" +
                                                 " game.");
            // В эту игру может играть не менее 2 игроков
            players = newPlayers;
        }
        private void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }
        public int PlayGame()
        {
            // Проводить игру, только если существуют игроки.
            if (players == null)
                return -1;
            // Первая раздача карт на руки игрокам.
            DealHands();
            // Инициализация имеющих отношение к игре переменных, включая
            // переменную, которая представляет первую карту на столе: playCard.
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);
            // Главный цикл игры, который выполняется, пока GameWon == false.
            do
            {
                // Проход по игрокам в каждом раунде игры.
                for (currentPlayer = 0; currentPlayer < players.Length;
                     currentPlayer++)
                {
                    // Вывод текущего игрока, его карт и карты на столе.
                    Console.WriteLine("{0}'s turn.", players[currentPlayer].Name);
                    Console.WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine("Card in play: {0}", playCard);
                    // Приглашение игроку взять карту со стола или вытащить новую.
                    bool inputOK = false;
                    do
                    {
                        Console.WriteLine("Press T to take card in play or D to " +
                                              "draw:");
                        // Нажмите T, чтобы взять разыгранную карту,
                        // или D, чтобы вытащить новую
                        string input = Console.ReadLine();
                        if (input.ToLower() == "t")
                        {
                            // Добавление карты со стола на руки игроку.
                            Console.WriteLine("Drawn: {0}", playCard);
                            // Удаление отброшенных карт, если возможно (если 
                            // колода перемешана, их там больше быть не должно).
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }
                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            // Добавление на руки игроку новой карты из колоды.
                            Card newCard;
                            // Добавление карты только в том случае, если ее нет 
                            // на руках у игроков и в отброшенных картах.
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                // Проверка, не находится ли карта в отброшенных картах.
                                cardIsAvailable = !discardedCards.Contains(newCard);
                                if (cardIsAvailable)
                                {
                                    // Просмотр карт на руках у всех игроков для выяснения, 
                                    // не находится ли карта newCard у кого-нибудь из них.
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvailable);
                            // Добавление найденной карты на руки игроку.
                            Console.WriteLine("Drawn: {0}", newCard);
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }
                    } while (inputOK == false);
                    // Отображение новой раскладки на руках у игрока с нумерацией карт.
                    Console.WriteLine("New hand:");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1,
                                           players[currentPlayer].PlayHand[i]);
                    }
                    // Приглашение игроку отбросить какую-нибудь карту.
                    inputOK = false;
                    int choice = -1;
                    do
                    {
                        Console.WriteLine("Choose card to discard:");
                        // Выберите карту для отбрасывания
                        string input = Console.ReadLine();
                        try
                        {
                            // Попытка преобразовать введенные 
                            // данные в допустимый номер карты.
                            choice = Convert.ToInt32(input);
                            if ((choice > 0) && (choice <= 8))
                                inputOK = true;
                        }
                        catch
                        {
                            // Игнорирование неудачных попыток преобразования 
                            // и продолжение вывода приглашения.
                        }
                    } while (inputOK == false);
                    // Помещение ссылки на удаляемую карту в playCard (выкладывание карты на стол),
                    // затем изъятие карты из рук игрока и добавление ее в стопку отброшенных карт.
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                    discardedCards.Add(playCard);
                    Console.WriteLine("Discarding: {0}", playCard);   // Отбрасывание карты
                                                                      // Вывод пустой строки для удобства.
                    Console.WriteLine();
                    // Проверка, выиграл ли игрок в этой игре, и если да, то выход из цикла.
                    GameWon = players[currentPlayer].HasWon();
                    if (GameWon == true)
                        break;
                }
            } while (GameWon == false);
            // Завершение игры с указанием выигравшего игрока. 
            return currentPlayer;
        }
    }
}
