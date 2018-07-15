using System;
using System.Collections.Generic;
using System.Text;

namespace FullHouse.Cards
{

    public enum CardNumber
    {
        Ace   = 1 << 1,
        Two   = 1 << 2,
        Three = 1 << 3,
        Four  = 1 << 4,
        Five  = 1 << 5,
        Six   = 1 << 6,
        Seven = 1 << 7,
        Eight = 1 << 8,
        Nine  = 1 << 9,
        Ten   = 1 << 10,
        Jack  = 1 << 11,
        Queen = 1 << 12,
        King  = 1 << 13

    }
}
