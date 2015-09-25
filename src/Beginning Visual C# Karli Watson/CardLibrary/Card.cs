using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Card: ICloneable
    {
        public readonly Suit suit;
        public readonly Rank rank;
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        private Card()
        {
        }
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// Флаг для применения козырных карт. При значении true козырные 
        /// карты должны цениться больше, чем карты других мастей.
        /// </summary> 
        public static bool useTrumps = false;
        /// <summary>
        /// Козырная масть, которая должна использоваться в случае,
        /// если useTrumps равно true.
        /// </summary>
        public static Suit trump = Suit.Club;
        /// <summary>
        /// Флаг, определяющий то, являются ли тузы старше королей или младше двоек.
        /// </summary>
        public static bool isAceHigh = true;
    }
}
