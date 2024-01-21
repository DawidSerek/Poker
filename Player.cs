using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerWinForms
{
    public class Player
    {
        Card[] cards = new Card[2];

        public Player()
        {
            for (int i = 0; i < cards.Length; i++)
                cards[i] = Deck.TransferCard();
        }
        public override string? ToString()
        {
            String output = "";
            for (int i = 0; i < 2; i++)
                output += $"{cards[i].ToString()}\n";
            return output;
        }
    }



}
