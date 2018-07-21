using System;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{
    /// <summary>
    /// Ranks go from lowest(High) to highest (RoyalFlush).
    /// </summary>
    public enum HandTypeRank
    {
        High,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}
