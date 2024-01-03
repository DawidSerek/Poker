using System;
using System.Drawing;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dealer.ShuffleDeck();
            Console.WriteLine(Deck.ToString());
            
        }
    }

    

}