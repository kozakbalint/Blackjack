using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DealCards : DeckOfCards
    {
        private List<Card> playerHand;
        private List<Card> dealerHand;
        private int lastCardIndex = 0;

        public List<Card> GetPlayerHand => playerHand;
        public List<Card> GetDealerHand => dealerHand;

        public DealCards()
        {
            playerHand = new List<Card>();
            dealerHand = new List<Card>();
            fillDeck();
            DealCard(2, true);
            DealCard(1, false);
            foreach (var item in playerHand)
            {
                Console.WriteLine(item.MyValue + "of" + item.MySuit);
            }
            foreach (var item in dealerHand)
            {
                Console.WriteLine(item.MyValue + "of" + item.MySuit);
            }
        }

        public void DealCard(int cardNum, bool toPlayer)
        {
            if (toPlayer)
            {
                for (int i = 0; i < cardNum; i++)
                {
                    playerHand.Add(GetDeck[lastCardIndex]);
                    lastCardIndex++;
                }
            }
            else
            {
                for (int i = 0; i < cardNum; i++)
                {
                    dealerHand.Add(GetDeck[lastCardIndex]);
                    lastCardIndex++;
                }
            }
        }

        public int computeCardValue(bool isPlayer)
        {
            int sumCardValue = 0;
            if (isPlayer)
            {
                for (int i = 0; i < playerHand.Count; i++)
                {
                    sumCardValue += (int)playerHand[i].MyValue;
                }
                return sumCardValue;
            }
            else
            {
                for (int i = 0; i < dealerHand.Count; i++)
                {
                    sumCardValue += (int)dealerHand[i].MyValue;
                }
                return sumCardValue;
            }
            
        }
    }
}
