using FullHouse.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace FullHouse.Tests.Cards
{
    public class DeckTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public DeckTests(ITestOutputHelper toh) => testOutputHelper = toh;

        [Fact]
        public void Shuffle_ShouldGenerateRandom()
        {
            // There is a 1 in 52! chance that this fails. Probably not happening.
            Deck deck = new Deck();
            var cards = deck.Cards;
            testOutputHelper.WriteLine("Before:\n");
            testOutputHelper.WriteLine(cards
                .ToList()
                .Aggregate<Card, string>(
                    new String(""),
                    (seed, card) => seed + $"({card.Suit.ToString()} : {card.Value.ToString()}) "
                )
            );

            Assert.NotEqual(cards, deck.Shuffle().Cards);
            testOutputHelper.WriteLine("After:\n");
            testOutputHelper.WriteLine(deck.Cards
                .ToList()
                .Aggregate<Card, string>(
                    new String(""),
                    (seed, card) => seed + $"({card.Suit.ToString()} : {card.Value.ToString()}) "
                )
            );

        }
    }
}
