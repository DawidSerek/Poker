using System;
using System.Drawing;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dealer.ShuffleDeck();
            /*Console.WriteLine(Deck.ToString());*/

            Card
                c1 = new Card(9),
                c2 = new Card(10),
                c3 = new Card(11),
                c4 = new Card(12),
                c5 = new Card(14);

            Console.WriteLine( (
                c1.ToString(), 
                c2.ToString(), 
                c3.ToString(), 
                c4.ToString(), 
                c5.ToString() )
            );

            Card[] testHand = {c1,c2,c3,c4,c5};

            Console.WriteLine(
                    Dealer.Evaluate(testHand)
            );
        }
    }

    

}