using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    public class ManagerATM
    {
        List<Card> cards = new List<Card>();
        public bool cardInput;
        public void StartATM(object card)
        {
            if (card is Card) cardInput = true;
        }
        public Card GetAllCards(Card card)
        {
            cards.Add(card);
            return cards[0];
        }
        public MainMenu StartMainMenu(Card card)
        {
            MainMenu mainMenu = new MainMenu(GetAllCards(card));
            return mainMenu;
        }
        public ManagerATM(object card)
        {
            StartATM(card);
            if (!cardInput) DataInputOutputManager.OutputMessager("Cant get card.");
        }
    }
}
