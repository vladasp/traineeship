using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    class ManegerATM
    {
        DataInputOutputManeger Masseger = new DataInputOutputManeger();
        List<Card> cards = new List<Card>();
        bool cardInput;
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
        public ManegerATM(object card)
        {
            StartATM(card);
            if (!cardInput) Masseger.OutputMasseger("Cant get card.");
        }
    }
}
