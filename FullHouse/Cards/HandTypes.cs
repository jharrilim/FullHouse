using FullHouse.Players;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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

        public static bool IsRoyalFlush(this List<Card> cards)
        {
            if (cards.Count <= 0)
                return false;

            return IsFlush(cards) &&
                cards.Sum(card => Convert.ToInt32(card.Value)) == royalStraight;
        }

        public static bool IsStraightFlush(this List<Card> hand) => IsStraight(hand) && IsFlush(hand);

        public static bool IsFlush(this List<Card> cards)
        {
            var counts = from c in cards
                         group c by c.Suit into grp
                         select grp.Count();
            return counts.Any(count => count >= 5);
        }

        public static bool IsStraight(this List<Card> cards)
        {

            int handTotal = cards.Sum(card => Convert.ToInt32(card.Value));

            if ((handTotal & wheel) == wheel || (handTotal & royalStraight) == royalStraight)
                return true;

            string b_cards = Convert.ToString(handTotal, 2);
            bool foundOne = false;
            int count = 0;

            foreach (char c in b_cards)
            {
                if(c == '1')
                {
                    foundOne = true;
                    count++;
                }
                else
                {
                    if (foundOne && count < 5)
                    {
                        foundOne = false;
                        count = 0;
                    }
                }

                if (count == 5)
                    return true;
            }

            return count >= 5;
        }

        public static bool IsFourOfAKind(this List<Card> cards) => CountMatches(cards) == 4;

        public static bool IsThreeOfAKind(this List<Card> cards) => CountMatches(cards) == 3;

        public static bool IsPair(this List<Card> cards) => CountMatches(cards) == 2;

        private static int CountMatches(List<Card> cards)
        {
            return cards.GroupBy(c => c.Value)
                .Select(grp => grp.Count())
                .Max();
        }
    }
}
