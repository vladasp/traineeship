using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card= new Card
            {
                Balance = 1000,
                BlockCard = false,
                IDUser = "Rich",
            };
            ManagerATM managerATM = new ManagerATM(card);
            MainMenu mainMenu = managerATM.StartMainMenu(card);
            while (!card.BlockCard && !mainMenu.BlockMenu)
            {
                mainMenu.Operations(card, managerATM);
            }
            DataInputOutputManager.InputMessanger();
        }
    }
}
