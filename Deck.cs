using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerWinForms
{
    public class Deck
    {
        public static List<Card> CurrentCardLayout = new List<Card>();

        static Deck()
        {
            for (int i = 1; i <= 52; i++)
                CurrentCardLayout.Add(new Card(i));
        }
        public static Card TransferCard()
        {
            Card transferedCard = CurrentCardLayout.Last();
            CurrentCardLayout.RemoveAt(CurrentCardLayout.Count - 1);
            return transferedCard;
        }

        public override string ToString()
        {
            string output = string.Empty;
            for (int i = 0; i < CurrentCardLayout.Count; i++)
                output += $"{CurrentCardLayout[i].ToString()}\n";
            return output;
        }

    }
}
