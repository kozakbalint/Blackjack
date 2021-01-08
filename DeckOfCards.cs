using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DeckOfCards : Card
    {
        const int NUMBER_OF_CARDS = 52;
        private Card[] deck;

        public DeckOfCards()
        {
            deck = new Card[NUMBER_OF_CARDS];
        }

        public Card[] GetDeck => deck;

        public void fillDeck()
        {
            int i = 0;
            foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { MySuit = suit, MyValue = value };
                    i++;
                }
            }
            shuffleCards();
        }

        public void shuffleCards()
        {
            Random r = new Random();
            Card tmp;
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < NUMBER_OF_CARDS; j++)
                {
                    int secondCard = r.Next(13);
                    tmp = deck[j];
                    deck[j] = deck[secondCard];
                    deck[secondCard] = tmp;
                }
            }
        }
    }
}
