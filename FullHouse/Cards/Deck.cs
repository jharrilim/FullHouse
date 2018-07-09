using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullHouse.Cards
{
    public class Deck
    {
        private Stack<Card> cards;

        public IEnumerable<Card> Cards { get { return cards; } }

        public Deck()
        {
            cards = new Stack<Card>(CardSet.DefaultSet());
        }

        public Card Draw()
        {
            return cards.Pop();
        }

        public Deck Shuffle()
        {
            Random rnd = new Random();
            List<Card> cardsPrev = cards.ToList();
            Stack<Card> cardsNew = new Stack<Card>();
            cards.ToList().ForEach(_ =>
            {
                int nextRnd = rnd.Next(0, cardsPrev.Count);
                cardsNew.Push(cardsPrev[nextRnd]);
                cardsPrev.RemoveAt(nextRnd);
            });

            cards = cardsNew;

            return this;
        }

    }
}
