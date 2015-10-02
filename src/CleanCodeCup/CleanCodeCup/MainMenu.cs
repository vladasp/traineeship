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
        DataInputOutputManager inOutManager = new DataInputOutputManager();
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
                userPinCode = enterUserData.CheckPinCodeSimbols();
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
            inOutManager.OutputMessager("BYE ", card.IDUser);
        }
        public void Run()
        {
            blocker.BlockTimeLimitSassion(true);
            blocker.BlockTimeLimitState(true);
            inOutManager.OutputMessager("INSERT");
        }
        public MainMenu (Card card)
        {
            Run();
            CheckPinCode(card);
            if (!card.BlockCard && !BlockMenu) inOutManager.OutputMessager("MENU");
            else while (true) inOutManager.InputMessanger();
        }
        public MainMenu() { }
        public void Operations(Card card)
        {
            while (!card.BlockCard && !BlockMenu)
            {
                ++countCommands;
                BlockMenu = (blocker.BlockBadCommand(countBadCommands) || blocker.BlockTimeLimitState(true) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                enterUserData = enterUserData.CheckCommandSimbols();
                Enum.TryParse(enterUserData, true, out userCommand);
                switch (userCommand)
                {
                    case UserCommand.BALANCE:
                        inOutManager.OutputMessager(GetBalance(card).ToString());
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        break;
                    case UserCommand.CASH:
                        GetCash(card, cash.CheckSumSimbols());
                        inOutManager.OutputMessager(card.Balance.ToString());
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
                inOutManager.OutputMessager("Menu blocked");
                inOutManager.InputMessanger();
            } 
        }
    }
}
