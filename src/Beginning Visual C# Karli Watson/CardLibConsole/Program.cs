using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardLibConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Отображение вводной информации.
            Console.WriteLine("KarliCards: a new and exciting card game.");
            // KarliCards: новая и увлекательная карточная игра
            Console.WriteLine("To win you must have 7 cards of the same suit in" +
                                  "your hand.");
            // Для выигрыша необходимо, чтобы на руках оказалось 7 карт одной масти
            Console.WriteLine();
            // Запрос количества игроков.
            bool inputOK = false;
            int choice = -1;
            do
            {
                Console.WriteLine("How many players (2-7)?"); // Ввод количества игроков (2-7)
                string input = Console.ReadLine();
                try
                {
                    // Попытка преобразовать введенные данные в допустимое число игроков.
                    choice = Convert.ToInt32(input);
                    if ((choice >= 2) && (choice <= 7))
                        inputOK = true;
                }
                catch
                {
                    // Игнорирование неудачных попыток преобразования 
                    // и продолжение запроса на ввод.
                }
            } while (inputOK == false);
            // Инициализация массива объектов Player.
            Player[] players = new Player[choice];
            // Получение имен игроков.
            for (int p = 0; p < players.Length; p++)
            {
                Console.WriteLine("Player {0}, enter your name:", p + 1);
                // Ввод имени игрока
                string playerName = Console.ReadLine();
                players[p] = new Player(playerName);
            }
            // Запуск игры.
            Game newGame = new Game();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();
            // Вывод сообщения о победившем игроке.
            Console.WriteLine("{0} has won the game!", players[whoWon].Name);
        }
    }
}
