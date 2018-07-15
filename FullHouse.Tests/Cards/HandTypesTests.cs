using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

using FullHouse.Cards;
using FullHouse.Players;
using Xunit.Extensions;

namespace FullHouse.Tests.Cards
{
    public class HandTypesTests
    {
        public static readonly TheoryData<List<Card>> MixedSuitsData = new TheoryData<List<Card>>
        {
            new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Ace),
                new Card(Suit.Hearts, CardNumber.Jack),
                new Card(Suit.Clubs, CardNumber.Ten),
                new Card(Suit.Diamonds, CardNumber.King),
                new Card(Suit.Spades, CardNumber.Queen)
            }
        };

        public static readonly TheoryData<List<Card>> MixedNumberData = new TheoryData<List<Card>>
        {
            new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Two),
                new Card(Suit.Clubs, CardNumber.Jack),
                new Card(Suit.Clubs, CardNumber.Ten),
                new Card(Suit.Clubs, CardNumber.King),
                new Card(Suit.Clubs, CardNumber.Queen)
            }
        };

        private readonly ITestOutputHelper testOutputHelper;

        public HandTypesTests(ITestOutputHelper toh)
        {
            testOutputHelper = toh;
        }

        [Fact]
        public void IsRoyalFlush_ShouldMatch()
        {
            List<Card> actualCards = new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Ace),
                new Card(Suit.Clubs, CardNumber.Jack),
                new Card(Suit.Clubs, CardNumber.Ten),
                new Card(Suit.Clubs, CardNumber.King),
                new Card(Suit.Clubs, CardNumber.Queen)
            };
            Hand hand = new Hand();
            hand.Cards.AddRange(actualCards);

            Assert.True(hand.IsRoyalFlush());
        }

        [Theory]
        [MemberData(nameof(MixedSuitsData))]
        public void IsRoyalFlush_WithNonMatchingSuits_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsRoyalFlush());
        }

        [Theory]
        [MemberData(nameof(MixedNumberData))]
        public void IsRoyalFlush_WithWrongNumbers_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsRoyalFlush());
        }
    }
}
