using System;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    static class CardSet
    {
        public static IEnumerable<Card> DefaultSet()
        {
            var set = new List<Card>();

            foreach(Suit suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                foreach(CardNumber value in (CardNumber[]) Enum.GetValues(typeof(CardNumber)))
                {
                    set.Add(new Card(suit, value));
                }
            }

            return set;
        }
    }
}
