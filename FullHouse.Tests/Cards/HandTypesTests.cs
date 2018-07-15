using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

using FullHouse.Cards;
using FullHouse.Players;

namespace FullHouse.Tests.Cards
{
    public class HandTypesTests
    {

        public static readonly TheoryData<List<Card>> RoyalFlush = new TheoryData<List<Card>>
        {
            new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Ace),
                new Card(Suit.Clubs, CardNumber.Ten),
                new Card(Suit.Clubs, CardNumber.Jack),
                new Card(Suit.Clubs, CardNumber.Queen),
                new Card(Suit.Clubs, CardNumber.King)
            }
        };

        public static readonly TheoryData<List<Card>> StraightFlush = new TheoryData<List<Card>>
        {
            new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Seven),
                new Card(Suit.Clubs, CardNumber.Eight),
                new Card(Suit.Clubs, CardNumber.Nine),
                new Card(Suit.Clubs, CardNumber.Ten),
                new Card(Suit.Clubs, CardNumber.Jack)
            }
        };

        public static readonly TheoryData<List<Card>> MixedSuitsRoyalStraight = new TheoryData<List<Card>>
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

        public static readonly TheoryData<List<Card>> MixedNumberFlush = new TheoryData<List<Card>>
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

        public static readonly TheoryData<List<Card>> MixedSuitsStraight = new TheoryData<List<Card>>
        {
            new List<Card>
            {
                new Card(Suit.Clubs, CardNumber.Two),
                new Card(Suit.Diamonds, CardNumber.Three),
                new Card(Suit.Clubs, CardNumber.Four),
                new Card(Suit.Spades, CardNumber.Five),
                new Card(Suit.Hearts, CardNumber.Six)
            }
        };

        [Theory]
        [MemberData(nameof(RoyalFlush))]
        public void IsRoyalFlush_WithRoyalFlush_ShouldMatch(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);

            Assert.True(hand.IsRoyalFlush());
        }

        [Theory]
        [MemberData(nameof(MixedSuitsRoyalStraight))]
        public void IsRoyalFlush_WithNonMatchingSuits_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsRoyalFlush());
        }

        [Theory]
        [MemberData(nameof(MixedNumberFlush))]
        public void IsRoyalFlush_WithWrongNumbers_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsRoyalFlush());
        }

        [Theory]
        [MemberData(nameof(RoyalFlush))]
        [MemberData(nameof(StraightFlush))]
        public void IsStraightFlush_WithStraight_ShouldReturnTrue(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.True(hand.IsStraightFlush());
        }

        [Theory]
        [MemberData(nameof(MixedNumberFlush))]
        public void IsStraightFlush_WithNonStraightData_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsStraightFlush());
        }

        [Theory]
        [MemberData(nameof(MixedSuitsRoyalStraight))]
        [MemberData(nameof(MixedSuitsStraight))]
        [MemberData(nameof(RoyalFlush))]
        public void IsStraight_WithStraightData_ShouldReturnTrue(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.True(hand.IsStraight());
        }

        [Theory]
        [MemberData(nameof(MixedNumberFlush))]
        public void IsStraight_WithNonStraightData_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsStraight());
        }


        [Theory]
        [MemberData(nameof(MixedNumberFlush))]
        [MemberData(nameof(RoyalFlush))]
        public void IsFlush_WithFlushData_ShouldReturnTrue(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.True(hand.IsFlush());
        }

        [Theory]
        [MemberData(nameof(MixedSuitsStraight))]
        [MemberData(nameof(MixedSuitsRoyalStraight))]
        public void IsFlush_WithNonFlushData_ShouldReturnFalse(List<Card> cards)
        {
            Hand hand = new Hand();
            hand.Cards.AddRange(cards);
            Assert.False(hand.IsFlush());
        }
    }
}
