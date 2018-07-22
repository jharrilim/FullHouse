using FullHouse.Cards;

using System;

using System.Collections.Generic;
using System.Reactive.Linq;

namespace FullHouse.Players
{
    public abstract class Player
    {
        public bool IsDealer { get; set; }
        public bool IsCurrentPlayer { get; set; }

        public string Name { get; }
        public Hand Hand { get; }

        public Table CurrentTable { get; }

        public event EventHandler RequestDraw;
        public event EventHandler EndTurn;
        public event EventHandler<CardPlayedEventArgs> CardPlayed;

        protected Player(string name)
        {
            Name = name;
            Hand = new Hand();
            CurrentTable = null;
        }

        public void ShowHand() => Hand.IsVisible = true;

        public void HideHand() => Hand.IsVisible = false;

        public void PlayCard(Card card) => CardPlayed(this, new CardPlayedEventArgs { Card = card });
    }
}
