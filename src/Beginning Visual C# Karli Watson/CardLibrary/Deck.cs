using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public delegate void LastCardDrawnHandler(Deck currentDeck);
    public class Deck: ICloneable
    {
        public event LastCardDrawnHandler LastCardDrawn;
        private Cards cards = new Cards();
        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        private Deck(Cards newCards)
        {
            cards = newCards;
        }
        /// <summary>
        /// Конструктор не по умолчанию. Позволяет назначать тузы старшими.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }
        /// <summary>
        /// Конструктор не по умолчанию. Позволяет использовать козырную масть.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Конструктор не по умолчанию. Позволяет назначать тузы старшими 
        /// и использовать козырную масть.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
    }
}
