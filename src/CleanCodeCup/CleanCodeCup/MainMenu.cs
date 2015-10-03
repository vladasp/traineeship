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
            DataInputOutputManager.OutputMessager("BYE ", card.IDUser);
        }
        public void Run()
        {
            blocker.BlockTimeLimitSassion(true);
            blocker.BlockTimeLimitState(true);
            DataInputOutputManager.OutputMessenger("INSERT");
        }
        public MainMenu (Card card)
        {
            Run();
            CheckPinCode(card);
            if (!card.BlockCard && !BlockMenu) DataInputOutputManager.OutputMessenger("MENU");
            else while (card.BlockCard && BlockMenu) DataInputOutputManager.InputMessenger();
        }
        public MainMenu() { }
        public void Operations(Card card, ManagerATM managarATM)
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
                        DataInputOutputManager.OutputMessenger(GetBalance(card).ToString());
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        managarATM.cardInput = (BlockMenu || card.BlockCard) ? false : true;
                        break;
                    case UserCommand.CASH:
                        GetCash(card, cash.CheckSumSimbols());
                        DataInputOutputManager.OutputMessenger(card.Balance.ToString());
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        managarATM.cardInput = (BlockMenu || card.BlockCard) ? false : true;
                        break;
                    case UserCommand.EXIT:
                        Exit(card);
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        managarATM.cardInput = (BlockMenu || card.BlockCard) ? false : true;
                        break;
                    default:
                        ++countBadCommands;
                        BlockMenu = (blocker.BlockTimeLimitState(false) || blocker.BlockTimeLimitSassion(false) || blocker.BlockCommandLimit(countCommands)) ? true : false;
                        managarATM.cardInput = (BlockMenu || card.BlockCard) ? false : true;
                        break;
                }
            }
            while (!managarATM.cardInput)
            {
                DataInputOutputManager.OutputMessenger("Menu blocked");
                DataInputOutputManager.InputMessenger();
                managarATM.cardInput = true;
                blocker.BlockTimeLimitSassion(true);
                blocker.BlockTimeLimitState(true);
                card.BlockCard = false;
                BlockMenu = false;
                managarATM.StartMainMenu(card);
            } 
        }
    }
}
