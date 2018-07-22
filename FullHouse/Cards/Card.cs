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

            if (Suit > other.Suit)
                return 1;

            if (Suit < other.Suit)
                return -1;

            return 0;
        }

        public override int GetHashCode()
        {
            int hash = 31;
            hash *= Value.GetHashCode();
            hash *= Suit.GetHashCode();
            return hash;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Card other = obj as Card;

            if (other == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (other.Suit == Suit && other.Value == Value)
                return true;

            return false;

        }

        public static bool operator ==(Card left, Card right) => left.Equals(right);

        public static bool operator !=(Card left, Card right) => !left.Equals(right);

        public static bool operator >(Card left, Card right) => left.CompareTo(right) == 1;

        public static bool operator <(Card left, Card right) => left.CompareTo(right) == -1;

        public override string ToString()
        {
            return $"Suit: {Suit.ToString()} Value: {Value.ToString()}";
        }
    }
}
