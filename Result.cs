using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Result
    {
        private string outcome;
        private List<Card> playerHand;
        private List<Card> dealerHand;

        public Result(string outcome, List<Card> playerHand, List<Card> dealerHand)
        {
            this.outcome = outcome;
            this.playerHand = playerHand;
            this.dealerHand = dealerHand;
        }

        public string GetOutcome => outcome;
    }
}
