using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal static class Dealer
    {
        public static List<Player> Players = new List<Player>();
        public static void AddPlayer() => Players.Add(new Player());

        public static void ShuffleDeck()
        {
            for(int i = 0; i < 100; i++) {
                Random rand = new Random();
                int deckCount = Deck.CurrentCardLayout.Count;

                int RandomIndex1 = (int)rand.Next(deckCount);
                int RandomIndex2 = (int)rand.Next(deckCount);

                Card temp = Deck.CurrentCardLayout[RandomIndex1];

                Deck.CurrentCardLayout[RandomIndex1] = Deck.CurrentCardLayout[RandomIndex2];
                Deck.CurrentCardLayout[RandomIndex2] = temp;
            }
        }


    }
}
