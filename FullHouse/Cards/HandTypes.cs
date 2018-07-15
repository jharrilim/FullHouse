using FullHouse.Players;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    public static class HandTypes
    {
        private static readonly string royalFlush = Convert.ToString(
            Convert.ToInt32((
                CardNumber.Ten   |
                CardNumber.Jack  |
                CardNumber.Queen |
                CardNumber.King  |
                CardNumber.Ace
        )), 2);

        public static bool IsRoyalFlush(this Hand hand)
        {
            if (hand.Cards.Count <= 0)
                return false;

            Suit s = hand.Cards.First().Suit;

            foreach (var card in hand.Cards)
            {
                if (card.Suit != s)
                    return false;
            }

            return Convert.ToString(
                hand.Cards.Sum(card => Convert.ToInt32(card.Value)),
                2
            ) == royalFlush;
        }
    }
}
