using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class CardOutOfRangeException: Exception
    {
        private Cards deckContents;
        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }
        public CardOutOfRangeException(Cards sourceDeckContents) :
             base("There are only 52 cards in the deck.")
        // В колоде есть только 52 карты
        {
            deckContents = sourceDeckContents;
        }
    }
}
