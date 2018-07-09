using FullHouse.Cards;
using System;
using System.Collections.Generic;

namespace FullHouse.Players
{
    public class Hand
    {
        public bool IsVisible { get; internal set; }

        public List<Card> Cards { get; }

        internal Card Play(Card card)
        {
            Cards.Remove(card);
            return card;
        }
    }
}