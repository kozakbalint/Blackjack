using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        public enum SUIT
        {
            CLUBS,
            DIAMONDS,
            HEARTS,
            SPADES
        }

        public enum VALUE
        {
            TWO = 2,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            KING = 10,
            QUEEN = 10,
            JACK = 10,
            ACE = 11
        }

        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
    }
}
