using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    public class MainMenu
    {
        UserCommand userCommand = new UserCommand();
        Blocker blocker = new Blocker();
        DataInputOutputManeger inOutManeger = new DataInputOutputManeger();
        string enterUserData;
        int userPinCode;
        int countBadCommands;
        int countBadSum = 0;
        int countBadPinCode = 0;
        int countCommands = 0;
        private bool blockMenu;
        public bool BlockMenu
        {
            get { return blockMenu; }
            set { blockMenu = value; }
        }
        string cash;
        
        public Card ChangeCard(List<Card> cards)
        {
            return cards[0];
        }
        public double GetBalance(Card card)
        {
            return card.Balance;
        }
        private double SetBalance(Card card, double setBalance)
        {
            card.Balance = setBalance;
            return setBalance;
        }
        public double GetCash(Card card, double cash)
        {
            if (cash <= card.Balance)
            {
                card.Balance -= cash;
                SetBalance(card, card.Balance);
            }
            else
            {
                ++countBadSum;
                ++countBadCommands;
                BlockMenu = blocker.BlockBadSum(countBadSum);
            }
            return card.Balance;
        }
        public void CheckPinCode(Card card)
        {
            do
            {   ++countCommands;
                BlockMenu = (blocker.BlockTimeLimitState(true) || blocker.BlockTimeLimitSassion(false))? true : false;
                userPinCode = enterUserData.ChackPinCodeSimbols();
                if (userPinCode != card.PinCode)
                {
                    ++countBadPinCode;
                    ++countBadCommands;
                    card.BlockCard = blocker.BlockCardPinCode(countBadPinCode);
                }
                else card.BlockCard = false;
            }
            while (userPinCode != card.PinCode);
        }
        public void Exit(Card card)
        {
            inOutManeger.OutputMasseger("BYE ", card.IDUser);
        }
        public void Run()
        {
            blocker.BlockTimeLimitSassion(true);
            blocker.BlockTimeLimitState(true);
            inOutManeger.OutputMasseger("INSERT");
        }
        public MainMenu (Card card)
        {
            Run();
            CheckPinCode(card);
            if (!card.BlockCard && !BlockMenu) inOutManeger.OutputMasseger("MENU");
            else while (true) Console.ReadLine();
        }
        public MainMenu() { }
        public void Operations(Card card)
        {
            while (!card.BlockCard && !BlockMenu)
            {
                ++countCommands;
                BlockMenu = (blocker.BlockBadCommand(countBadCommands) || blocker.BlockTimeLimitState(true) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                enterUserData = enterUserData.ChackCommandSimbols();
                Enum.TryParse(enterUserData, true, out userCommand);
                switch (userCommand)
                {
                    case UserCommand.BALANCE:
                        inOutManeger.OutputMasseger(GetBalance(card).ToString());
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        break;
                    case UserCommand.CASH:
                        GetCash(card, cash.ChackSumSimbols());
                        inOutManeger.OutputMasseger(card.Balance.ToString());
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        break;
                    case UserCommand.EXIT:
                        Exit(card);
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        break;
                    default:
                        ++countBadCommands;
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        break;
                }
            }
            while (true)
            {
                inOutManeger.OutputMasseger("Menu blocked");
                Console.ReadKey();
            } 
        }
    }
}
