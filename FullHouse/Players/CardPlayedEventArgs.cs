using FullHouse.Cards;
using System;

namespace FullHouse.Players
{
    public class CardPlayedEventArgs : EventArgs
    {
        public Card Card { get; set; }
    }
}