using FullHouse.Cards;
using FullHouse.Players;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace FullHouse
{
    public class Table
    {
        private readonly Deck deck;
        private readonly List<Card> cardsOnTable;


        // Closest thing to a ConcurrentHashSet. The byte is a meaningless dummy value.
        private ConcurrentDictionary<Player, byte> players;

        public int MaxSeats { get; }

        public event EventHandler TableFilled;

        public Table(int seats = 6)
        { 
            MaxSeats = seats;
            deck = new Deck();
            cardsOnTable = new List<Card>();
            players = new ConcurrentDictionary<Player, byte>();
        }

        public bool JoinTable(Player player)
        {
            if (players.ContainsKey(player) || players.Count >= MaxSeats)
                return false;

            bool result = players.TryAdd(player, Byte.MinValue);
            player.CardPlayed += PlayCard;
            if (result)
            {
                if(players.Count == MaxSeats)
                    TableFilled(this, new EventArgs());
                return result;
            }

            return false;
        }

        private void PlayCard(object sender, CardPlayedEventArgs e)
        {
            Player player = sender as Player;

            if (player.IsCurrentPlayer)
            {
#if DEBUG
                if (cardsOnTable.Contains(e.Card))
                    throw new Exception("There shouldn't be duplicate cards");
#endif
                cardsOnTable.Add(player.Hand.Play(e.Card));
            }
        }

        public void DealCard()
        {
            throw new NotImplementedException();
        }

        public void LeaveTable(Player player)
        {
            byte _ = 0;
            players.TryRemove(player, out _);
        }

    }
}
