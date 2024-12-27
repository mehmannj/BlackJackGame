using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{

    public class BlackJackEngine
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> PlayerHand = new List<Card>();
        public List<Card> DealerHand = new List<Card>();

        public void Init()
        {
            string[] suits = { "H", "D", "C", "S" };
            int[] ranks = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // 1=Ace, 11=Jack, 12=Queen, 13=King

            foreach (String suit in suits)
            {
                foreach (int rank in ranks)
                {
                    Deck.Add(new Card(suit, rank));
                }
            }

            // Shuffle the deck
            ShuffleDeck();
        }
        private void ShuffleDeck()
        {
            Random random = new Random();
            Deck = Deck.OrderBy(x => random.Next()).ToList();
        }

        public void ShowDeck()
        {
            foreach (Card card in Deck)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public void DealToPlayer()
        {
            Card card = Deck[0];
            PlayerHand.Add(card);
            Deck.RemoveAt(0);

        }

        internal int getPlayerSum()
        {
            int sum = 0;
            foreach (Card card in PlayerHand)
            {

                sum += card.GetBlackJackValue();
            }
            return sum;
        }
       

        public void DealToDealer()
        {
            while (getDealerSum() < 17)
            {
                Card card = Deck[0];
                DealerHand.Add(card);
                Deck.RemoveAt(0);
            }
        }

        

        public int getDealerSum()
        {
            return CalculateHandValue(DealerHand);
        }

        private int CalculateHandValue(List<Card> hand)
        {
            int sum = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                sum += card.GetBlackJackValue();
                if (card.Rank == 1)
                {
                    aceCount++;
                }
            }

            while (sum > 21 && aceCount > 0)
            {
                sum -= 10;
                aceCount--;
            }

            return sum;
        }
    }
}

