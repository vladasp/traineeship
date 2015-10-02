using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    public class Card
    {
        private double balance;
        private int pinCode = 1234;
        private string IDuser;
        private bool blockCard;
        
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public int PinCode
        {
            get { return pinCode; }
        }
        public string IDUser
        {
            get { return IDuser; }
            set { IDuser = value; }
        }
        public bool BlockCard
        {
            get { return blockCard; }
            set { blockCard = value; }
        }
        public Card() { }
    }
}
