using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Player
    {
        const int n = 5;
        Card[] cards = new Card[n];

        private void generatePlayer()
        {
            for(int i = 0; i < cards.Length; i++)
                cards[i] = Deck.TransferCard();
        }
        public Player() {generatePlayer();}

        public override string? ToString()
        {
            String output = "";
            for(int i = 0; i < n; i++)
                output += $"{cards[i].ToString()}\n";
            return output;
        }
    }

    

}
