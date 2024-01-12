using System;
using System.Drawing;
using System.Security;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MLDataGenerator.GenerateGames(10);


            /* Dealer.ShuffleDeck();
             console.writeline(deck.tostring());*/

            /*List<int>[] InputHands =
            {
                new List<int>{ 1,2,3,4,5 },
                new List < int > { 9, 10, 11, 12, 13 },
                new List < int > { 13, 14, 2, 3, 4 },
                new List < int > { 1, 14, 27, 2, 15 },
                new List < int > { 1, 15, 3, 4, 5 },
                new List < int > { 1, 14, 27, 8, 9 },
                new List < int > { 1, 14, 2, 15, 9 },
                new List < int > { 1, 14, 7, 3, 22 },
                new List < int > { 4, 33, 6, 21, 9 },
            };

            foreach (List<int> InputHand in InputHands)
            {
                Card
                c1 = new Card(InputHand[0]),
                c2 = new Card(InputHand[1]),
                c3 = new Card(InputHand[2]),
                c4 = new Card(InputHand[3]),
                c5 = new Card(InputHand[4]);

                Console.WriteLine((
                    c1.ToString(),
                    c2.ToString(),
                    c3.ToString(),
                    c4.ToString(),
                    c5.ToString())
                );

                List<Card> testHand = new List<Card>{ c1, c2, c3, c4, c5 };

                Console.WriteLine(
                        Dealer.Evaluate(testHand)
                );
            }*/

            /*MLDataGenerator.GenerateCsv(100000);*/
        }
    }
}