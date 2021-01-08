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

        private void DealCard(int cardNum, bool toPlayer)
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

        private int computeCardValue(bool isPlayer)
        {
            int sumCardValue = 0;
            if (isPlayer)
            {
                for (int i = 0; i < playerHand.Count; i++)
                {
                    switch (playerHand[i].MyValue)
                    {
                        case VALUE.TWO:
                            sumCardValue += 2;
                            break;
                        case VALUE.THREE:
                            sumCardValue += 3;
                            break;
                        case VALUE.FOUR:
                            sumCardValue += 4;
                            break;
                        case VALUE.FIVE:
                            sumCardValue += 5;
                            break;
                        case VALUE.SIX:
                            sumCardValue += 6;
                            break;
                        case VALUE.SEVEN:
                            sumCardValue += 7;
                            break;
                        case VALUE.EIGHT:
                            sumCardValue += 8;
                            break;
                        case VALUE.NINE:
                            sumCardValue += 9;
                            break;
                        case VALUE.TEN:
                            sumCardValue += 10;
                            break;
                        case VALUE.KING:
                            sumCardValue += 10;
                            break;
                        case VALUE.QUEEN:
                            sumCardValue += 10;
                            break;
                        case VALUE.JACK:
                            sumCardValue += 10;
                            break;
                        case VALUE.ACE:
                            sumCardValue += 11;
                            break;
                        default:
                            break;
                    }
                }
                return sumCardValue;
            }
            else
            {
                for (int i = 0; i < dealerHand.Count; i++)
                {
                    switch (dealerHand[i].MyValue)
                    {
                        case VALUE.TWO:
                            sumCardValue += 2;
                            break;
                        case VALUE.THREE:
                            sumCardValue += 3;
                            break;
                        case VALUE.FOUR:
                            sumCardValue += 4;
                            break;
                        case VALUE.FIVE:
                            sumCardValue += 5;
                            break;
                        case VALUE.SIX:
                            sumCardValue += 6;
                            break;
                        case VALUE.SEVEN:
                            sumCardValue += 7;
                            break;
                        case VALUE.EIGHT:
                            sumCardValue += 8;
                            break;
                        case VALUE.NINE:
                            sumCardValue += 9;
                            break;
                        case VALUE.TEN:
                            sumCardValue += 10;
                            break;
                        case VALUE.KING:
                            sumCardValue += 10;
                            break;
                        case VALUE.QUEEN:
                            sumCardValue += 10;
                            break;
                        case VALUE.JACK:
                            sumCardValue += 10;
                            break;
                        case VALUE.ACE:
                            sumCardValue += 11;
                            break;
                        default:
                            break;
                    }
                }
                return sumCardValue;
            }
            
        }
    }
}
