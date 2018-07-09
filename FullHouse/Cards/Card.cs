using System;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    public class Card
    {
        public CardNumber Value { get; }
        public Suit Suit { get; }

        public Card(Suit suit, CardNumber value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
