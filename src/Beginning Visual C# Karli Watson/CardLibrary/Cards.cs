using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CardLibrary
{
    public class Cards: CollectionBase, ICloneable
    {
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }
        public Cards()
        {
        }
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }
        /// <summary>
        /// Вспомогательный метод для копирования экземпляров карт в другой 
        /// экземпляр Cards — используемый в Deck.Shuffle(). В данной реализации  
        /// предполагается, что размеры исходной и целевой коллекций совпадают.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        /// <summary>
        /// Выполнение проверки на предмет наличия в коллекции определенной карты.
        /// Эта проверка предусматривает вызов метода Contains из
        /// ArrayList для коллекции, к которой получается 
        /// доступ через свойство InnerList.
        /// </summary>
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in List)
            {
                newCards.Add(sourceCard.Clone() as Card);
            }
            return newCards;
        }
    }
}
