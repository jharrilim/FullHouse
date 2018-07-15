using FullHouse.Players;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    public static class HandTypes
    {
        private static readonly int royalStraight = Convert.ToInt32((
            CardNumber.Ten
            | CardNumber.Jack
            | CardNumber.Queen
            | CardNumber.King
            | CardNumber.Ace
        ));

        private static readonly int wheel = Convert.ToInt32((
            CardNumber.Ace
            | CardNumber.Two
            | CardNumber.Three
            | CardNumber.Four
            | CardNumber.Five
        ));

        public static bool IsRoyalFlush(this Hand hand)
        {
            if (hand.Count <= 0)
                return false;

            return IsFlush(hand) &&
                hand.Cards.Sum(card => Convert.ToInt32(card.Value)) == royalStraight;
        }

        public static bool IsStraightFlush(this Hand hand) => IsStraight(hand) && IsFlush(hand);

        public static bool IsFlush(this Hand hand)
        {
            Suit suit = hand.Cards.First().Suit;

            foreach (var card in hand.Cards)
            {
                if (card.Suit != suit)
                    return false;
            }

            return true;
        }

        public static bool IsStraight(this Hand hand)
        {
            if (hand.Count > 5)
                return false;

            int handTotal = hand.Cards.Sum(card => Convert.ToInt32(card.Value));

            if (handTotal == wheel)
                return true;

            string b_cards = Convert.ToString(handTotal, 2);
            bool foundOne = false;
            int count = 0;

            foreach (char c in b_cards)
            {
                if(c == '1')
                {
                    foundOne |= true;
                    count++;
                }
                else
                {
                    if (foundOne && count < 5)
                        return false;
                }
            }

            return count == 5;
        }

        public static bool IsFourOfAKind(this Hand hand)
        {
            var counts = from c in hand.Cards
                    group c by c.Value into grp
                    select grp.Count();

            foreach (var count in counts)
            {
                if (count >= 4)
                    return true;
            }

            return false;
        }
    }
}
