using FullHouse.Cards;
using System;
using System.Collections.Generic;

namespace FullHouse.Players
{
    public class Hand
    {
        public bool IsVisible { get; internal set; }
        public int Count { get => Cards.Count; }
        public List<Card> Cards { get; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        internal Card Play(Card card)
        {
            Cards.Remove(card);
            return card;
        }
    }
}