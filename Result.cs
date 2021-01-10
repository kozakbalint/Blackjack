using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Result
    {
        private Card[] playerHand; 
        private Card[] dealerHand;
        private string outcome;

        public Result(Card[] playerHand, Card[] dealerHand, string outcome)
        {
            this.playerHand = playerHand;
            this.dealerHand = dealerHand;
            this.outcome = outcome;
        }
    }
}
