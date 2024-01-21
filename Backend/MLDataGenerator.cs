using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PokerWinForms.Backend;


/*
 * Utility class. Used to either test methods within "Dealer" class, 
 * or to generate input values for ML model
 */


namespace PokerWinForms
{
    internal class MLDataGenerator
    {
        //display game emulation for debug purposes
        public static void GenerateGame()
        {
            Dealer.ShuffleDeck();

            //generate hands & table
            List<Card> hand1 = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(Deck.CurrentCardLayout[i]);
                hand1.Add(Deck.CurrentCardLayout[i]);
            }
            Console.WriteLine("vs");
            List<Card> hand2 = new List<Card>();
            for (int i = 2; i < 4; i++)
            {
                Console.WriteLine(Deck.CurrentCardLayout[i]);
                hand2.Add(Deck.CurrentCardLayout[i]);
            }
            Console.WriteLine("table");
            List<Card> table = new List<Card>();
            for (int i = 4; i < 9; i++)
            {
                Console.WriteLine(Deck.CurrentCardLayout[i]);
                table.Add(Deck.CurrentCardLayout[i]);
            }
            Console.WriteLine("\n");

            //evaluate hands
            Outcome hand1outcome = Dealer.nthEvaluateInit(hand1.Concat(table).ToList());
            Outcome hand2outcome = Dealer.nthEvaluateInit(hand2.Concat(table).ToList());

            //display outcome both as string and int
            Console.WriteLine(hand1outcome);
            Console.WriteLine(Dealer.EvaluateOutputToInt(hand1outcome));
            Console.WriteLine(hand2outcome);
            Console.WriteLine(Dealer.EvaluateOutputToInt(hand2outcome));

            //name the outcome
            switch (Dealer.OutcomeComparator(hand1outcome, hand2outcome))
            {
                case 0:
                    Console.WriteLine("tie");
                    break;
                case 1:
                    Console.WriteLine("player 1 won");
                    break;
                case -1:
                    Console.WriteLine("player 2 won");
                    break;
            }
        }
        //generate csv/emulated games in mass form
        public static void GenerateGames(int n, bool isCsv, string csvPath = "D:\\Programowanie\\VS\\PO\\Poker\\output.csv")
        {
            for (int i = 0; i < n; i++)
            {
                if (!isCsv)
                    GenerateCsv(csvPath);
                else
                    GenerateGame();
                Console.WriteLine("\n\n");
            }
        }
        public static void GenerateCsv(string csvPath, int size = 10)
        {
            List<List<int>> rows = new List<List<int>>();
            StringBuilder csvContent = new StringBuilder();

            int[] handSizes = { 0, 3, 4, 5 };
            for (int i = 0; i < size; i++)
                foreach (int h in handSizes)
                    csvContent.AppendLine(
                        string.Join(";", GenerateCsvData(h))
                    );

            File.WriteAllText(csvPath, csvContent.ToString());
        }
        //utility method to prepare data for GenerateCsv method
        public static List<int> GenerateCsvData(int tableSize = 5)
        {
            if (tableSize == 0) tableSize = 5;

            Dealer.ShuffleDeck();

            //generate hands
            List<Card> hand1 = new List<Card>();
            for (int i = 0; i < 2; i++)
                hand1.Add(Deck.CurrentCardLayout[i]);
            List<Card> hand2 = new List<Card>();
            for (int i = 2; i < 4; i++)
                hand2.Add(Deck.CurrentCardLayout[i]);
            List<Card> table = new List<Card>();
            for (int i = 4; i < tableSize + 4; i++)
                table.Add(Deck.CurrentCardLayout[i]);

            //evaluate hands
            Outcome hand1outcome = Dealer.nthEvaluateInit(hand1.Concat(table).ToList());
            Outcome hand2outcome = Dealer.nthEvaluateInit(hand2.Concat(table).ToList());

            //organize data into list
            List<int> OutputRow = new List<int>();
            new List<int> {
                Dealer.EvaluateOutputToInt(hand1outcome),
                hand1outcome.HandUtility,
                Dealer.OutcomeComparator(hand1outcome, hand2outcome)
            };

            return OutputRow;
        }
    }
}
