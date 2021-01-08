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
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            KING,
            QUEEN,
            JACK,
            ACE
        }

        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }
    }
}
