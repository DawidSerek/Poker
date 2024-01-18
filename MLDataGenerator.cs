using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PokerWinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PokerWinForms
{
    internal class MLDataGenerator
    {
        public static void GenerateGame()
        {
            Dealer.ShuffleDeck();
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

            Outcome hand1outcome = Dealer.nthEvaluateInit(hand1.Concat(table).ToList());
            Outcome hand2outcome = Dealer.nthEvaluateInit(hand2.Concat(table).ToList());

            Console.WriteLine(hand1outcome);
            Console.WriteLine(Dealer.EvaluateOutputToInt(hand1outcome));
            Console.WriteLine(hand2outcome);
            Console.WriteLine(Dealer.EvaluateOutputToInt(hand2outcome));

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
        public static void GenerateGames(int n)
        {
            for (int i = 0; i < n; i++)
            {
                GenerateGame();
                Console.WriteLine("\n\n");
            }
        }


        public static void GenerateCsv(int size = 10)
        {
            List<List<int>> rows = new List<List<int>>();

            StringBuilder csvContent = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                csvContent.AppendLine(string.Join(";", GenerateCsvData(0)));
                csvContent.AppendLine(string.Join(";", GenerateCsvData(3)));
                csvContent.AppendLine(string.Join(";", GenerateCsvData(4)));
                csvContent.AppendLine(string.Join(";", GenerateCsvData(5)));
            }

            File.WriteAllText("D:\\Programowanie\\VS\\PO\\Poker\\output.csv", csvContent.ToString());
        }

        public static List<int> GenerateCsvData(int tableSize = 5)
        {
            bool isSecretlyZero = tableSize == 0;
            if (tableSize == 0) tableSize = 5;

            Dealer.ShuffleDeck();
            List<Card> hand1 = new List<Card>();

            for (int i = 0; i < 2; i++)
                hand1.Add(Deck.CurrentCardLayout[i]);

            List<Card> hand2 = new List<Card>();
            for (int i = 2; i < 4; i++)
                hand2.Add(Deck.CurrentCardLayout[i]);

            List<Card> table = new List<Card>();
            for (int i = 4; i < tableSize + 4; i++)
                table.Add(Deck.CurrentCardLayout[i]);

            Outcome hand1outcome = Dealer.nthEvaluateInit(hand1.Concat(table).ToList());
            Outcome hand2outcome = Dealer.nthEvaluateInit(hand2.Concat(table).ToList());

            /*foreach (Card card in hand1) Console.WriteLine(card.Id);
            foreach (Card card in table) Console.WriteLine(card.Id);
            Console.WriteLine(Dealer.OutcomeComparator(hand1outcome, hand2outcome));*/

            List<int> OutputRow = new List<int>();

            /*foreach (Card card in hand1) OutputRow.Add(card.Id);*/

            /*if (!isSecretlyZero)
                foreach (Card card in table) OutputRow.Add(card.Id);
            else
                for (int i = 0; i < 5; i++) OutputRow.Add(0);*/

            /*for (int i = 0; i < 5 - tableSize; i++) OutputRow.Add(0);*/
            OutputRow.Add(Dealer.EvaluateOutputToInt(hand1outcome));
            OutputRow.Add(hand1outcome.HandUtility);
            OutputRow.Add(Dealer.OutcomeComparator(hand1outcome, hand2outcome));

            return OutputRow;
        }


    }
}
