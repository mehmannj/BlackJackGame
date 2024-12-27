using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    public class Card
    {
        public string Suit;
        public int Rank;
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public int GetBlackJackValue()
        {
            if (Rank > 10) return 10;
            return Rank;

        }
        public string GetImageFilename()
        {
            string rank = Rank.ToString();
            if (Rank == 1) rank = "A";
            if (Rank == 11) rank = "J";
            if (Rank == 12) rank = "Q";
            if (Rank == 13) rank = "K";

            return rank + Suit + ".jpg";

        }
    }

}
