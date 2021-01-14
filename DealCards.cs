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
        }

        public void StartDeal()
        {
            DealCard(2, true);
            DealCard(1, false);
        }
        public void ClearPlayerHand()
        {
            playerHand.Clear();
        }

        public void ClearDealerHand()
        {
            dealerHand.Clear();
        }

        public void DealCard(int cardNum, bool toPlayer)
        {
            if (lastCardIndex+10 > GetDeckNumber)
            {
                fillDeck();
                shuffleCards();
                lastCardIndex = 0;
            }
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

        public int calculateCardValue(bool isPlayer)
        {
            try
            {
                int sumCardValue = 0;
                if (isPlayer)
                {
                    for (int i = 0; i < playerHand.Count; i++)
                    {
                        sumCardValue += (int)playerHand[i].MyValue;
                    }
                    if ((playerHand.Where(x => x.MyValue == VALUE.ACE).Count() == 1 && sumCardValue > 21) || (playerHand.Where(x => x.MyValue == VALUE.ACE).Count() == 2 && sumCardValue > 21))
                    {
                        return sumCardValue - 10;
                    }
                    else
                    {
                        return sumCardValue;
                    }

                }
                else
                {
                    for (int i = 0; i < dealerHand.Count; i++)
                    {
                        sumCardValue += (int)dealerHand[i].MyValue;
                    }
                    if ((dealerHand.Where(x => x.MyValue == VALUE.ACE).Count() == 1 && sumCardValue > 21) || (dealerHand.Where(x => x.MyValue == VALUE.ACE).Count() == 2 && sumCardValue > 21))
                    {
                        return sumCardValue - 10;
                    }
                    else
                    {
                        return sumCardValue;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
