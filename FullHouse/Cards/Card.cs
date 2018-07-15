using System;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    public class Card : IComparable, IComparable<Card>
    {
        public CardNumber Value { get; }
        public Suit Suit { get; }

        public Card(Suit suit, CardNumber value)
        {
            Suit = suit;
            Value = value;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Card otherCard = obj as Card;

            if (otherCard == null)
                throw new ArgumentException($"Unable to compare. Object is not of type Card: {obj.ToString()}");

            return CompareTo(otherCard);
        }

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;

            if (Value > other.Value)
                return 1;

            if (Value < other.Value)
                return -1;

            return 0;
        }
    }
}
